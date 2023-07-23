using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prn231_FinalProject.Models;

namespace Prn231_FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MentorController : Controller
    {
        private PRN231_ProjectContext _context = new PRN231_ProjectContext();
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                    var data = _context.Mentors.ToList();
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
        public IActionResult Post(Mentor mentor)
        {
            try
            {
                _context.Mentors.Add(mentor);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
