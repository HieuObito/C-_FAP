using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Prn231_FinalProject.Models;
using System.Text;

namespace PRN231_CallApi_Final.Controllers
{
    public class SubjectController : Controller
    {
        public async Task<IActionResult> Index(string? subjectCode)
        {
            //Subject subject = new Subject();
            //List<Class> classes = new List<Class>();

            //string linkClass = "http://localhost:5000/api/Subject/Subject?subjectName=" + subjectCode;

            //using (HttpClient client = new HttpClient())
            //{
            //    using (HttpResponseMessage res = await client.GetAsync(linkClass))
            //    {
            //        using (HttpContent content = res.Content)
            //        {
            //            string data = await content.ReadAsStringAsync();
            //            subject = JsonConvert.DeserializeObject<Subject>(data);
            //        }
            //    }
            //}
            //foreach (Class item in subject.Classes)
            //{
            //    classes.Add(item);
            //}

            ViewBag.Message = TempData["Message"];

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(StudentClass model)
        {
            string link = "http://localhost:5000/api/Subject/Subject";
            using (HttpClient client = new HttpClient())
            {
                var jsonContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                using (HttpResponseMessage res = await client.PostAsync(link, jsonContent))
                {
                    if (res.IsSuccessStatusCode)
                    {
                        TempData["Message"] = "Add Succesfully!";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["Message"] = "Add Fail";
                        return RedirectToAction("Index");
                    }
                }
            }
        }

    }
}
