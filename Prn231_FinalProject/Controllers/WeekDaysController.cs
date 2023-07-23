using Microsoft.AspNetCore.Mvc;
using Prn231_FinalProject.Models;

namespace Prn231_FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeekDaysController : Controller
    {
        private PRN231_ProjectContext context = new PRN231_ProjectContext();
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var data = context.WeekDays.ToList();
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

