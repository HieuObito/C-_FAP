using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Prn231_FinalProject.Models;

namespace PRN231_CallApi_Final.Controllers
{
    public class AdminController : Controller
    {
        public async Task<IActionResult> Index()
        {
            Mentor mentor = new Mentor();
            List<Student> students = new List<Student>();
            Class classess= new Class();
            string linkClass = "http://localhost:5000/api/Attendent?classId=1" ;

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(linkClass))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        mentor = JsonConvert.DeserializeObject<Mentor>(data);
                    }
                }
            }

            foreach (Class classes in mentor.Classes)
            {
                classess = classes;
                foreach(StudentClass stu in classes.StudentClasses)
                {
                        students.Add(stu.Student);
                }
            }
            ViewBag.Student = students;
            ViewBag.Class = classess;
            return View();
        }

    }
}
