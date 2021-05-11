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
    public class StudentProgressController : ApiController
    {
        public List<Student_Progress> Get()
        {
            Configuration.Formatters.Remove(Configuration.Formatters.XmlFormatter);
            DBHelper dBHelper = new DBHelper();
            return dBHelper.GetStudentProgresses();
        }
    }
}
