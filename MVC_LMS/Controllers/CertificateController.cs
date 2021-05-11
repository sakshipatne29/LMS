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
    public class CertificateController : Controller
    {

        StudentProgressBL studentProgressBL = new StudentProgressBL();
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
            //s.CertificateStatus = Generated;
            s.UserName = Session["username"].ToString();
            string course = JsonConvert.SerializeObject(s);
            string result = await studentProgressBL.EditCerti(course);
            if (result == "true")
            {
                string certi = await studentProgressBL.GetStudent_Progresses();
                List<Student_Progress> cust = JsonConvert.DeserializeObject<List<Student_Progress>>(certi);
                return View("Index", cust);
            }
            return Content("<script language='javascript' type='text/javascript'>alert('You are not eligible for certificate... Score 85 and above and give Test.'); window.location.href = '/Certificate/index/" + "'</script>");

            //return View();
        }
    }            
}