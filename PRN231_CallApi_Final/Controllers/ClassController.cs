using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Prn231_FinalProject.Models;

namespace PRN231_CallApi_Final.Controllers
{
    public class ClassController : Controller
    {
        public async Task<IActionResult> Index(int? studentId)
        {
            List<Slot> lstSlots = new List<Slot>();
            Student student = new Student();
            List<WeekDay> lstWeekDay = new List<WeekDay>();
            Subject sub= new Subject();
            List<SlotDate> lstSlotDate = new List<SlotDate>();
            string? datefrom="";
            string? dateto="";
            int classId=0;
            string link = "http://localhost:5000/api/Slot";
            string linkClass = "http://localhost:5000/api/Class?studentId="+studentId;
            string linkWeekDays= "http://localhost:5000/api/WeekDays";

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(link))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        lstSlots = JsonConvert.DeserializeObject<List<Slot>>(data);
                    }
                }
            }

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(linkWeekDays))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        lstWeekDay = JsonConvert.DeserializeObject<List<WeekDay>>(data);
                    }
                }
            }

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(linkClass))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        student = JsonConvert.DeserializeObject<Student>(data);
                    }
                }
            }

                foreach (StudentClass studentClass in student.StudentClasses)
                {
                     sub = studentClass.Class.Subject;
                     classId = studentClass.Class.ClassId;
                     datefrom = studentClass.Class.DateFrom.GetValueOrDefault().ToString("yyyy-MM-dd");
                     dateto = studentClass.Class.DateTo.GetValueOrDefault().ToString("yyyy-MM-dd");
                if (studentClass != null)
                    {
                        foreach (ClassSlotDate classSlot in studentClass.Class.ClassSlotDates)
                        {
                            lstSlotDate.Add(classSlot.SlotDate);
                        }
                    }
                }
            ViewBag.Slots = lstSlots;
            ViewBag.Subject = sub;
            ViewBag.WeekDays = lstWeekDay;
            ViewBag.SlotDate = lstSlotDate;
            ViewBag.TimeFrom =  datefrom;
            ViewBag.TimeTo = dateto;
            ViewBag.ClassId = classId;
            return View(sub);
        }

        public async Task<IActionResult> GetClassId(int? classId)
        {
            Class classes = new Class();

            string linkClass = "http://localhost:5000/api/Class/id?classId=" + classId;

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(linkClass))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        classes = JsonConvert.DeserializeObject<Class>(data);
                    }
                }
            }
            ViewBag.Class = classes;

            return View(classes);
        }

        [HttpPost]
        public async Task<IActionResult> GetSlotDate(int? numberId, int? slotId)
        {
            try
            {
                string linkClass = "http://localhost:5000/api/Slot?id="+numberId+"&slotDateId="+slotId ;

                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.PutAsJsonAsync(linkClass,slotId))
                    {
                        if (res.IsSuccessStatusCode)
                        {
                            using (HttpContent content = res.Content)
                            {
                                return RedirectToAction("Index", new { studentId=1 });
                            }
                        }
                        else
                        {
                            return BadRequest();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        public async Task<IActionResult> StudentInClass(int? classId)
        {
            Class classes = new Class();
            List<Student> students = new List<Student>();

            string linkClass = "http://localhost:5000/api/Class/student?classId=" + classId;

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(linkClass))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        classes = JsonConvert.DeserializeObject<Class>(data);
                    }
                }
            }

            foreach (StudentClass studentClass in classes.StudentClasses)
            {
                students.Add(studentClass.Student);
            }
                ViewBag.Student = students;
                ViewBag.Class = classes;

            return View(students);
        }
    }
}
