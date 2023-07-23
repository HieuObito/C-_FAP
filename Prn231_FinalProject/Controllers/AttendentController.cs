using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prn231_FinalProject.Models;

namespace Prn231_FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendentController : Controller
    {
        private PRN231_ProjectContext context = new PRN231_ProjectContext();
        [HttpGet]
        public IActionResult Get(int? classId)
        {
            try
            {
                var data = context.Mentors.Include(s => s.Classes).ThenInclude(s=>s.StudentClasses).ThenInclude(s=>s.Student).ToList();
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
