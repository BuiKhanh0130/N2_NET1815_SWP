using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using DAOs;
using Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversationsController : ControllerBase
    {
        private readonly IConversationService iConversationService;

        public ConversationsController()
        {
            iConversationService = new ConversationService();
        }

        // GET: api/Conversations
        [HttpGet]
        public IActionResult GetConversations()
        {
            return Ok(iConversationService.GetConversations());
        }

        // GET: api/Conversations/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Conversation>> GetConversation(string id)
        //{
        //    var conversation = await _context.Conversations.FindAsync(id);

        //    if (conversation == null)
        //    {
        //        return NotFound();
        //    }

        //    return conversation;
        //}

        //// PUT: api/Conversations/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutConversation(string id, Conversation conversation)
        //{
        //    if (id != conversation.ConversationId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(conversation).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ConversationExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Conversations
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Conversation>> PostConversation(Conversation conversation)
        //{
        //    _context.Conversations.Add(conversation);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (ConversationExists(conversation.ConversationId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetConversation", new { id = conversation.ConversationId }, conversation);
        //}

        //// DELETE: api/Conversations/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteConversation(string id)
        //{
        //    var conversation = await _context.Conversations.FindAsync(id);
        //    if (conversation == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Conversations.Remove(conversation);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool ConversationExists(string id)
        //{
        //    return _context.Conversations.Any(e => e.ConversationId == id);
        //}
    }
}
