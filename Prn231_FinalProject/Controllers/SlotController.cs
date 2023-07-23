using Microsoft.AspNetCore.Mvc;
using Prn231_FinalProject.Models;

namespace Prn231_FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlotController : Controller
    {
        private PRN231_ProjectContext context = new PRN231_ProjectContext();
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                    var data = context.Slots.ToList();
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

        [HttpPut]
        public IActionResult Put(int id, int slotDateId)
        {
            try
            {
                    var foundClassSlotDate = context.SlotDates.Where(s => s.SlotDateId == id).SingleOrDefault();
                    if (foundClassSlotDate == null)
                    {
                        return NotFound();
                    }
                    foundClassSlotDate.SlotId=slotDateId;
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
