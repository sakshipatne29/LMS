using BusinessLayer;
using MVC_LMS.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC_LMS.Controllers
{
    public class TakeTestController : Controller
    {
        StudentProgressBL studentProgressBL = new StudentProgressBL();
        // GET: TakeTest
        public async Task<ActionResult> Index()
        {
            string Courses = await studentProgressBL.GetStudent_Progresses();
            List<Student_Progress> cust = JsonConvert.DeserializeObject<List<Student_Progress>>(Courses);
            return View(cust);
        }       

        public async Task<ActionResult> Edit(int id)
        {
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
            //s.Test_scores = 100;
            s.UserName = Session["username"].ToString();
            string course = JsonConvert.SerializeObject(s);
            string result = await studentProgressBL.EditC(course);
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