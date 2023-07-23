using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prn231_FinalProject.Models;

namespace Prn231_FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private PRN231_ProjectContext _context = new PRN231_ProjectContext();

        [HttpGet]
        public IActionResult Get(int ?studentId)
        {
            try
            {
                var data = _context.Students.Where(s => s.StudentId == studentId)
               .Include(s => s.StudentClasses).ThenInclude(s => s.Class)
               .ThenInclude(s => s.ClassSlotDates).ThenInclude(s => s.SlotDate)
               .ThenInclude(s => s.Slot)
               .Include(s => s.StudentClasses)
                    .ThenInclude(s => s.Class)
                      .ThenInclude(s => s.ClassSlotDates)
                         .ThenInclude(s => s.SlotDate)
                             .ThenInclude(s => s.Date)
                             .Include(s => s.StudentClasses)
                    .Include(s => s.StudentClasses).ThenInclude(s => s.Class)
                    .ThenInclude(s => s.Subject)
                .FirstOrDefault();
                //           var data = _context.Students
                //.Where(s => s.StudentId == 1)
                //.Select(s => new
                //{
                //    Student = s,
                //    StudentClasses = s.StudentClasses.Select(sc => new
                //    {
                //        Class = sc.Class,
                //        ClassSlotDates = sc.Class.ClassSlotDates.Select(csd => new
                //        {
                //            SlotDate = csd.SlotDate,
                //            Slot = csd.Slot,
                //            SlotDates = csd.Slot.SlotDates.Select(sd => sd.Date)
                //        })
                //    })
                //})
                //.FirstOrDefault();

                if (data == null)
                    {
                        return NotFound();
                    }
                    return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("id")]
        public IActionResult GetClassById(int? classId)
        {
            try
            {
                var data = _context.Classes.Where(s => s.ClassId == classId).Include(s => s.Mentor).Include(s=>s.Subject).SingleOrDefault();
                if (data == null)
                {
                    return NotFound();
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("student")]
        public IActionResult GetStudentInClass(int? classId)
        {
            try
            {
                var data = _context.Classes.Where(s => s.ClassId == classId).Include(s => s.StudentClasses).ThenInclude(s=> s.Student).SingleOrDefault();
                if (data == null)
                {
                    return NotFound();
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("Slot")]
        public IActionResult ChangeSlotDate(int? slotDateId)
        {
            try
            {
                var data = _context.Students
               .Include(s => s.StudentClasses).ThenInclude(s => s.Class)
               .ThenInclude(s => s.ClassSlotDates).ThenInclude(s => s.SlotDate)
               .Include(s => s.StudentClasses)
                    .ThenInclude(s => s.Class)
                      .ThenInclude(s => s.ClassSlotDates)
                         .ThenInclude(s => s.SlotDate)
                             .ThenInclude(s => s.Date)
                             .Include(s => s.StudentClasses)
                    .Include(s => s.StudentClasses)
                .FirstOrDefault();

                if (data == null)
                {
                    return NotFound();
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Post(Class clas)
        {
            try
            {
                _context.Classes.Add(clas);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("SlotDate")]
        public IActionResult GetSlotDateOfClass(int? classId)
        {
            try
            {
                var data = _context.Classes.Where(s => s.ClassId == classId).Include(s => s.ClassSlotDates)
                    .ThenInclude(s => s.SlotDate).ThenInclude(s=>s.Slot)
                    .Include(s => s.ClassSlotDates).ThenInclude(s => s.SlotDate)
               .ThenInclude(s => s.Date)
                    .SingleOrDefault();
                if (data == null)
                {
                    return NotFound();
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
