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
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService iSubjectService;

        public SubjectsController()
        {
            iSubjectService = new SubjectService();
        }

        // GET: api/Subjects
        [HttpGet]
        public IActionResult GetSubjects()
        {
            return Ok(iSubjectService.GetSubjects());
        }

        // GET: api/Subjects/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Subject>> GetSubject(string id)
        //{
        //    var subject = await _context.Subjects.FindAsync(id);

        //    if (subject == null)
        //    {
        //        return NotFound();
        //    }

        //    return subject;
        //}

        // PUT: api/Subjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutSubject(string id, Subject subject)
        //{
        //    if (id != subject.SubjectId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(subject).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!SubjectExists(id))
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

        // POST: api/Subjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Subject>> PostSubject(Subject subject)
        //{
        //    _context.Subjects.Add(subject);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (SubjectExists(subject.SubjectId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetSubject", new { id = subject.SubjectId }, subject);
        //}

        // DELETE: api/Subjects/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteSubject(string id)
        //{
        //    var subject = await _context.Subjects.FindAsync(id);
        //    if (subject == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Subjects.Remove(subject);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool SubjectExists(string id)
        //{
        //    return _context.Subjects.Any(e => e.SubjectId == id);
        //}
    }
}
