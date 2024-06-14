using BusinessObjects.Models;
using BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using API.Services;
using Repositories;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private IAccountService _accountService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthenticateController(IJwtTokenService jwtTokenService, IAccountService accountService, ICurrentUserService currentUserService)
        {
            _accountService = accountService;
            _jwtTokenService = jwtTokenService;
            _currentUserService = currentUserService;
        }

        [AllowAnonymous]
        [HttpPost("signUp")]
        public async Task<IActionResult> SignUp(AccountDTO signUpModel)
        {
            var result = await _accountService.SignUpAsync(signUpModel);
            if (result == null)
            {
                return BadRequest("Email is existed");
            }
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }

            return StatusCode(500);
        }

        [AllowAnonymous]
        [HttpPost("signIn")]
        public async Task<IActionResult> SignIn(UserSignIn signIn)
        {
            var user = await _accountService.SignInAsync(signIn);
            if (user == null || !(user.IsActive))
            {
                return Unauthorized();
            }
            var userRoles = await _accountService.GetRolesAsync(user);
            var accessToken = _jwtTokenService.CreateToken(user, userRoles);
            var refreshToken = _jwtTokenService.CreateRefeshToken();
            user.RefreshToken = refreshToken;
            user.DateExpireRefreshToken = DateTime.Now.AddDays(7);
            var result = _accountService.UpdateAccounts(user);
            if (result)
            {
                return Ok(new { token = accessToken, refreshToken });

            }
            return BadRequest("Failed to update user's token");
        }

        [HttpDelete("signOut")]
        public async Task<IActionResult> SignOut()
        {
            var user = await _currentUserService.GetUser();
            if (user is null)
                return Unauthorized();
            user.RefreshToken = null;
            _accountService.UpdateAccounts(user);
            return Ok();
        }


        [HttpPost("refresh-token")]
        public async Task<IActionResult> refeshToken(string refreshToken)
        {
            var userId = _currentUserService.GetUserId();
            var user = await _accountService.GetAccountById(userId.ToString());
            if (user == null || !(user.IsActive) || user.RefreshToken != refreshToken || user.DateExpireRefreshToken < DateTime.UtcNow)
            {
                return BadRequest("Not permission");
            }
            var userRoles = await _accountService.GetRolesAsync(user);
            var newRefreshToken = _jwtTokenService.CreateRefeshToken();
            user.RefreshToken = newRefreshToken;
            user.DateExpireRefreshToken = DateTime.Now.AddDays(7);
            var token = _jwtTokenService.CreateToken(user, userRoles);
            _accountService.UpdateAccounts(user);
            return Ok(new { token = token, refreshToken = newRefreshToken });
        }
    }
}
