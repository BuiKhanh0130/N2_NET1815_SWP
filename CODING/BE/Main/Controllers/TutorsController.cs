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
using NuGet.Protocol;
using Repositories;
using BusinessObjects.Models.TutorModel;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorsController : ControllerBase
    {
        private readonly ITutorService iTutorService;
        private readonly IAccountService iAccountService;
        private readonly IFeedbackService iFeedbackService;
        private readonly IGradeService iGradeService;
        private readonly ISubjectGroupService iSubjectGroupService;
        private readonly ISubjectService iSubjectService;
        private readonly ISubjectTutorService iSubjectTutorService;


        public TutorsController(IAccountService accountService)
        {
            iTutorService = new TutorService();
            iAccountService = accountService;
            iFeedbackService = new FeedbackService();
            iGradeService = new GradeService();
            iSubjectGroupService = new SubjectGroupService();
            iSubjectService = new SubjectService();
            iSubjectTutorService = new SubjectTutorService();
        }

        // GET: api/Tutors
        [HttpGet]
        public IActionResult FilterTutor([FromQuery] RequestSearchTutorModel requestSearchTutorModel)
        {
            var sortBy = requestSearchTutorModel.SortContent != null ? requestSearchTutorModel.SortContent?.sortTutorBy.ToString() : null;
            var sortType = requestSearchTutorModel.SortContent != null ? requestSearchTutorModel.SortContent?.sortTutorType.ToString() : null;

            //List tutors active 
            var allTutor = iTutorService.Filter(requestSearchTutorModel);

            // ----------------------TÌM KIẾM THEO TÊN GIẢNG VIÊN----------------------- 
            var allAccount = iAccountService.GetAccounts().Where(ac => ac.FullName.Contains(requestSearchTutorModel.Search) && ac.IsActive == true);

            // ---------------------TÌM KIẾM THEO TÊN NHÓM MÔN HỌC------------------------ 

            var allSubjectGroup = iSubjectGroupService.GetSubjectGroups().Where(su => su.SubjectName.Contains(requestSearchTutorModel.Search));

            if (allSubjectGroup.Count() <= 0)
            {
                allSubjectGroup = iSubjectGroupService.GetSubjectGroups();
            }
            else if (allAccount.Count() <= 0)
            {
                allAccount = iAccountService.GetAccounts();
            }
            else if (allAccount.Count() <= 0 && allSubjectGroup.Count() <= 0)
            {
                allAccount = null;
                allSubjectGroup = null;
            }

            IEnumerable<Subject> allSubject = iSubjectService.GetSubjects();

            // Trường hợp chọn grade
            if (!string.IsNullOrEmpty(requestSearchTutorModel.GradeId))
            {
                allSubject = allSubject.Where(s => s.GradeId == requestSearchTutorModel.GradeId);
            }// kết thúc


            IEnumerable<Subject> subjects = from sg in allSubjectGroup
                                            join s in allSubject
                                            on sg.SubjectGroupId equals s.SubjectGroupId
                                            select s;

            var allSubjectTutor = iSubjectTutorService.GetAllSubjectTutors();

            //Lấy danh sách giảng viên dạy môn học tìm kiếm
            IEnumerable<Tutor> list = from st in allSubjectTutor
                                      join s in subjects
                                      on st.SubjectId equals s.SubjectId
                                      join t in allTutor
                                      on st.TutorId equals t.TutorId
                                      select t;

            list = list.Distinct();


            //_____TẠO DANH SÁCH KẾT QUẢ_____
            var query = (from a in allAccount
                         join t in list
                         on a.Id equals t.AccountId
                         select new ResponseSearchTutorModel
                         {
                             TutorID = t.TutorId,
                             FullName = a.FullName,
                             Photo = t.Photo,
                             HourlyRate = t.HourlyRate,
                             Start = iFeedbackService.TotalStart(t.TutorId),
                             Ratings = iFeedbackService.TotalRate(t.TutorId),
                             Headline = t.Headline,
                             Description = t.Description,
                             TopFeedback = iFeedbackService.GetFeedbacks(t.TutorId).Select(s => s.Description).LastOrDefault(),
                         });

            query = iTutorService.Sorting(query, sortBy, sortType, requestSearchTutorModel.pageIndex, requestSearchTutorModel.pageSize);

            return Ok(query);
        }

        ////// GET: api/Tutors/5
        //[HttpGet("{id}")]
        //public IActionResult GetTutor(string id)
        //{
        //    var tutor = iTutorService.GetTutor(id);
        //    return Ok(tutor);
        //}

        //// PUT: api/Tutors/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTutor(string id, Tutor tutor)
        //{
        //    if (id != tutor.TutorId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(tutor).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TutorExists(id))
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

        //// POST: api/Tutors
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Tutor>> PostTutor(Tutor tutor)
        //{
        //    _context.Tutors.Add(tutor);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (TutorExists(tutor.TutorId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetTutor", new { id = tutor.TutorId }, tutor);
        //}

        //// DELETE: api/Tutors/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteTutor(string id)
        //{
        //    var tutor = await _context.Tutors.FindAsync(id);
        //    if (tutor == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Tutors.Remove(tutor);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool TutorExists(string id)
        //{
        //    return _context.Tutors.Any(e => e.TutorId == id);
        //}
    }
}
