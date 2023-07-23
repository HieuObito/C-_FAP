using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Prn231_FinalProject.Models;

namespace PRN231_CallApi_Final.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetUser(string username, string password)
        {
            string link = "http://localhost:5000/api/Account";
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(link + "/" + username + "/" + password))
                {
                    if (res.IsSuccessStatusCode)
                    {
                        string jsonResult = await res.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<Account>(jsonResult);
                        string role = result.RoleId.GetValueOrDefault().ToString();

                        HttpContext.Session.SetString("User", JsonConvert.SerializeObject(result));
                        HttpContext.Session.SetString("AccId", result.AccountId.ToString());
                        HttpContext.Session.SetString("Email", result.User);
                        HttpContext.Session.SetString("Pass", result.Password);
                        HttpContext.Session.SetString("Role", role);

                        ViewData["User"] = result.User;
                        ViewData["Role"] = role;
                        if (role.Equals("1"))
                        {
                            return Redirect($"/Home");
                        }
                        return Redirect($"/Admin");
                    }
                    else
                    {
                        ViewData["Error"] = "Kiểm tra lại thông tin đăng nhập.";
                        return View("Index");
                    }
                }
            }
        }
    }
}
