using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using BusinessLayer;
using MVC_LMS.Models;

namespace MVC_LMS.Controllers
{
    public class ProgressController : Controller
    {
        public async Task<ActionResult> Index()
        {
            StudentProgressBL studProgressBL = new StudentProgressBL();
            string studProgress = await studProgressBL.GetStudent_Progresses();
            List<Student_Progress> cust = JsonConvert.DeserializeObject<List<Student_Progress>>(studProgress);

            return View(cust);
        }

        public async Task<ActionResult> Edit(int id)
        {
            StudentProgressBL studentProgressBL = new StudentProgressBL();
            string Courses = await studentProgressBL.GetStudent_Progresses();
            List<Student_Progress> cust = JsonConvert.DeserializeObject<List<Student_Progress>>(Courses);
            foreach (var i in cust)
            {
                if (i.CourseID == id && i.UserName == Session["username"].ToString())
                    return View(i);
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Student_Progress s)
        {
            StudentProgressBL studentProgressBL = new StudentProgressBL();
            //s.Test_scores = 100;
            s.UserName = Session["username"].ToString();
            string course = JsonConvert.SerializeObject(s);
            string result = await studentProgressBL.EditP(course);
            if (result == "true")
            {
                string progress = await studentProgressBL.GetStudent_Progresses();
                List<Student_Progress> cust = JsonConvert.DeserializeObject<List<Student_Progress>>(progress);
                return View("Index", cust);
            }
            return View();
        }
    }

}