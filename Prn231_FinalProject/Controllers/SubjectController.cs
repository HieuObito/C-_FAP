using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Prn231_FinalProject.DTO;
using Prn231_FinalProject.Models;

namespace Prn231_FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : Controller
    {
        private PRN231_ProjectContext context = new PRN231_ProjectContext();
        [HttpGet("Subject")]
        public IActionResult Get(string? subjectName)
        {
            try
            {
                var data = context.Subjects.Where(s => s.SubjectCode.Equals(subjectName)).Include(s => s.Classes).ToList();
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

        [HttpPost("Subject")]
        public IActionResult Post(StudentClassDTO stu)
        {
            try
            {
                StudentClass s = new StudentClass()
                {
                    StudentId = stu.StudentId,
                    ClassId = stu.ClassId

                };
     //           var config = new MapperConfiguration(config => config.AddProfile(new AutoMapperProfile()));

     //           var mapper = config.CreateMapper();
					//StudentClass result = mapper.Map<StudentClass>(stu);
					//context.StudentClasses.Add(result);

                context.StudentClasses.Add(s);

                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
