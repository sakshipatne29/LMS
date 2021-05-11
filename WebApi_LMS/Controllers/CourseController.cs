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
    public class CourseController : ApiController
    {
        DBHelper dBHelper = new DBHelper();

        public List<Cours> Get()
        {
            Configuration.Formatters.Remove(Configuration.Formatters.XmlFormatter);
            return dBHelper.GetCourses();
        }

        public bool Post(Cours c)
        {
            return dBHelper.AddCourse(c);
        }

        [HttpPut]
        public bool Edit(Cours c)
        {
            return dBHelper.EditCourse(c);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return dBHelper.DeleteCourse(id);
        }

        public bool Details(int id)
        {
            return dBHelper.DetailsCourse(id);
        }
    }
}
