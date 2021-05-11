using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi_LMS.Controllers
{
    public class TakeTestController : ApiController
    {
        public List<Student_Progress> Get()
        {
            Configuration.Formatters.Remove(Configuration.Formatters.XmlFormatter);
            DBHelper dBHelper = new DBHelper();
            return dBHelper.GetStudentProgresses();
        }
        [HttpPut]
        public bool Edit(Student_Progress c)
        {
            DBHelper dBHelper = new DBHelper();
            return dBHelper.EditTest(c);
        }
    }
}
