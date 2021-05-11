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
    public class StudentController : Controller
    {

        StudentBL studentBL = new StudentBL();

        public async Task<ActionResult> Index()
        {
            string Students = await studentBL.GetStudents();
            List<User_Details> cust = JsonConvert.DeserializeObject<List<User_Details>>(Students);
            return View(cust);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(User_Details u)
        {
            u.Category = "Student";
            string student = JsonConvert.SerializeObject(u);
            string result = await studentBL.AddS(student);
            if (result == "true")
            {
                string Students = await studentBL.GetStudents();
                List<User_Details> cust = JsonConvert.DeserializeObject<List<User_Details>>(Students);
                return View("Index", cust);
            }
            return View();
        }

        public async Task<ActionResult> Edit(int id)
        {
            string Students = await studentBL.GetStudents();
            List<User_Details> cust = JsonConvert.DeserializeObject<List<User_Details>>(Students);
            foreach(var i in cust)
            {
                if(i.UserID == id)
                {
                    return View(i);
                }
            }
            return View();

        }

        [HttpPost]
        public async Task<ActionResult> Edit(User_Details u)
        {
            string student = JsonConvert.SerializeObject(u);
            string result = await studentBL.EditS(student);
            if (result == "true")
            {
                string Students = await studentBL.GetStudents();
                List<User_Details> cust = JsonConvert.DeserializeObject<List<User_Details>>(Students);
                return View("Index", cust);
            }
            return View();
        }
        public async Task<ActionResult> Delete(int id)
        {
            string ud = await studentBL.GetStudents();
            List<User_Details> cust = JsonConvert.DeserializeObject<List<User_Details>>(ud);
            return View(cust.Find(c => c.UserID == id));
        }

        [HttpPost]
        public async Task<ActionResult> Delete(User_Details c)
        {
            string userData = JsonConvert.SerializeObject(c.UserID);
            string result = await studentBL.DeleteS(c.UserID);
            if (result == "true")
            {
                string ud = await studentBL.GetStudents();
                List<User_Details> userList = JsonConvert.DeserializeObject<List<User_Details>>(ud);
                return View("Index", userList);
            }
            return View();
        }

        public async Task<ActionResult> Details(int id)
        {
            string st = await studentBL.GetStudents();
            List<User_Details> cust = JsonConvert.DeserializeObject<List<User_Details>>(st);
            return View(cust.Find(c => c.UserID == id));
        }
    }
}