using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Prn231_FinalProject.Models;

namespace PRN231_CallApi_Final.Controllers
{
    public class StudentController : Controller
    {
        public async Task<IActionResult> Index(int? id)
        {
            Student student = new Student();

            string link = "http://localhost:5000/api/Student/id?id=1";
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(link))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        student = JsonConvert.DeserializeObject<Student>(data);
                    }
                }
            }
            ViewBag.Students = student;
            return View(student);
        }
    }
}
