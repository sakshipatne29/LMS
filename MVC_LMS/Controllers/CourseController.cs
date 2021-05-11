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
    public class CourseController : Controller
    {
        CourseBL courseBL = new CourseBL();

        // GET: Course
        public async Task<ActionResult> Index()
        {
            string Courses = await courseBL.GetCourses();
            List<Cours> cust = JsonConvert.DeserializeObject<List<Cours>>(Courses);
            return View(cust);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Cours c)
        {
            string course = JsonConvert.SerializeObject(c);
            string result = await courseBL.AddC(course);
            if (result == "true")
            {
                string Courses = await courseBL.GetCourses();
                List<Cours> cust = JsonConvert.DeserializeObject<List<Cours>>(Courses);
                return View("Index", cust);
            }
            return View();
        }


        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Cours c)
        {
            string course = JsonConvert.SerializeObject(c);
            string result = await courseBL.EditC(course);
            if (result == "true")
            {
                string Courses = await courseBL.GetCourses();
                List<Cours> cust = JsonConvert.DeserializeObject<List<Cours>>(Courses);
                return View("Index", cust);
            }
            return View();
        }

        public async Task<ActionResult> Delete(int id)
        {
            string Courses = await courseBL.GetCourses();
            List<Cours> cust = JsonConvert.DeserializeObject<List<Cours>>(Courses);
            return View(cust.Find(c => c.CourseID == id));
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Cours c)
        {
            CourseBL courseBL = new CourseBL();
            string userData = JsonConvert.SerializeObject(c.CourseID);
            string result = await courseBL.DeleteC(c.CourseID);
            if (result == "true")
            {
                string courses = await courseBL.GetCourses();
                List<Cours> userList = JsonConvert.DeserializeObject<List<Cours>>(courses);
                return View("Index", userList);
            }
            return View();
        }

        public async Task<ActionResult> Details(int id)
        {
            string Courses = await courseBL.GetCourses();
            List<Cours> cust = JsonConvert.DeserializeObject<List<Cours>>(Courses);
            ViewBag.Courseid = id;
            return View(cust.Find(c => c.CourseID == id));
        }

        [HttpPost]
        public async Task<ActionResult> Assign()
        {
            int cid = Convert.ToInt32(Request["txtCourseid"].ToString());
            string username = Request["txtUsername"].ToString();
            StudentProgressBL studentProgressBL = new StudentProgressBL();
            Student_Progress sp = new Student_Progress();
            sp.CourseID = cid;
            sp.UserName = username;
            string add = JsonConvert.SerializeObject(sp);
            string result = await studentProgressBL.EnrollNow(add);
            if (result == "true")
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Assigned Succesfully'); window.location.href = '/Course/Index'</script>");
            }
            return Content("<script language='javascript' type='text/javascript'>alert('Course Not Assigned. Please check username/CourseID'); window.location.href = '/Course/Details/" + cid.ToString() + "'</script>");
        }
    }
}