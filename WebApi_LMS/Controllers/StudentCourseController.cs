using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataLayer;
using System.Data.Entity;

namespace WebApi_LMS.Controllers
{
    public class StudentCourseController : ApiController
    {
        DBHelper dBHelper = new DBHelper();

        public List<Cours> Get()
        {
            return dBHelper.GetCourses();
        }

        [HttpGet]
        public bool Get(int id)
        {
            return dBHelper.DetailsCourse(id);
        }
        [HttpPost]
        public bool Post(Student_Progress sp)
        {
            DBHelper dBHelper = new DBHelper();
            return dBHelper.EnrollUser(sp);
        }
    }
}
