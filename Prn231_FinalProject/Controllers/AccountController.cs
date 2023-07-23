using Microsoft.AspNetCore.Mvc;
using Prn231_FinalProject.Models;

namespace Prn231_FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private PRN231_ProjectContext context = new PRN231_ProjectContext();
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                    var data = context.Accounts.ToList();
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
        public async Task<ActionResult<IEnumerable<Account>>> GetAccountId(int id)
        {
            try
            {
                    Account acount = context.Accounts.FirstOrDefault(u => u.AccountId == id);
                    return Ok(acount);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("{email}/{pass}")]
        public async Task<ActionResult<Account>> GetUsers(string email, string pass)
        {
            try
            {
                    Account account = context.Accounts.FirstOrDefault(u => u.User == email && u.Password == pass);
                    if (account == null)
                    {
                        return NotFound();
                    }
                    var users = context.Accounts.FirstOrDefault(u => u.User == email);
                    return users;
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
