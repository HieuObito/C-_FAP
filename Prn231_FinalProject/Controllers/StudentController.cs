using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prn231_FinalProject.Models;

namespace Prn231_FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private PRN231_ProjectContext context = new PRN231_ProjectContext();
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                    var data = context.Students.ToList();
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

        [HttpGet("getStudents")]
        public IActionResult GetStudentInClass()
        {
            try
            {
                using (PRN231_ProjectContext context = new PRN231_ProjectContext())
                {
                    var data = context.StudentClasses.Include(s=>s.Class).Include(s=>s.Student).ToList();
                    if (data == null)
                    {
                        return NotFound();
                    }
                    return Ok(data);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("id")]
        public IActionResult GetProfileStudent(int? id)
        {
            try
            {
                using (PRN231_ProjectContext context = new PRN231_ProjectContext())
                {
                    var data = context.Students.SingleOrDefault(s => s.StudentId== id);
                    if (data == null)
                    {
                        return NotFound();
                    }
                    return Ok(data);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Post(Student stu)
        {
            try
            {
                using (PRN231_ProjectContext context = new PRN231_ProjectContext())
                {
                    context.Students.Add(stu);
                    context.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put(int id,Student stu)
        {
            try
            {
                using (PRN231_ProjectContext context = new PRN231_ProjectContext())
                {
                    var foundStudent = context.Students.Where(s=>s.StudentId==id).SingleOrDefault();
                    if (foundStudent == null)
                    {
                        return NotFound();
                    }
                    foundStudent.StudentName = stu.StudentName;
                    foundStudent.StudentDesc = stu.StudentDesc;
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        //Delete 
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                using (PRN231_ProjectContext context = new PRN231_ProjectContext())
                {
                    var foundStudent = context.Students.Where(s => s.StudentId == id).SingleOrDefault();
                    if (foundStudent == null)
                    {
                        return NotFound();
                    }
                    context.Students.Remove(foundStudent);
                    context.SaveChanges();
                    return Ok();
                }

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}

