using BusinessObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Security.Claims;

namespace API.Services
{
    public interface ICurrentUserService
    {
        Guid GetUserId();
        String getUserEmail();
        Task<Account> GetUser();
    }

    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<Account> _userManager;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor, IActionContextAccessor actionContextAccessor,
            UserManager<Account> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public Guid GetCurrentUserId()
        {
            throw new NotImplementedException();
        }
        public Guid GetUserId()
        {
            return Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirst("UserId")?.Value);
        }
        public String getUserEmail()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
        }

        public async Task<Account> GetUser()
        {
            var userId = GetUserId();
            return await _userManager.FindByIdAsync(userId.ToString());
        }
    }
}
