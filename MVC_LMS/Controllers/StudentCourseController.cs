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
    public class StudentCourseController : Controller
    {
        // GET: StudentCourse
        CourseBL courseBL = new CourseBL();
        StudentProgressBL studentProgressBL = new StudentProgressBL();
        public async Task<ActionResult> Index()
        {
            string Courses = await courseBL.GetCourses();
            List<Cours> cust = JsonConvert.DeserializeObject<List<Cours>>(Courses);
            return View(cust);
        }

        public async Task<ActionResult> Details(int id)
        {
            string Courses = await courseBL.GetCourses();
            List<Cours> cust = JsonConvert.DeserializeObject<List<Cours>>(Courses);
            return View(cust.Find(c => c.CourseID == id));
        }
        
        public async Task<ActionResult> Enroll(int id)
        {
            Student_Progress sp = new Student_Progress();
            sp.CourseID = id;
            sp.UserName = Session["username"].ToString();
            string add = JsonConvert.SerializeObject(sp);
            string result = await studentProgressBL.EnrollNow(add);
            if (result == "true")
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Enrolled Succesfully'); window.location.href = '/StudentCourse/Index'</script>");
            }
            return Content("<script language='javascript' type='text/javascript'>alert('You have already enrolled this course'); window.location.href = '/StudentCourse/Details/"+id.ToString()+"'</script>");
        }


    }
}
