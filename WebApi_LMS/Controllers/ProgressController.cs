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
    public class ProgressController : ApiController
    {
        DBHelper dBHelper = new DBHelper();

        public List<Student_Progress> Get()
        {
            Configuration.Formatters.Remove(Configuration.Formatters.XmlFormatter);
            return dBHelper.GetStudentProgresses();
        }
        [HttpPut]
        public bool Edit(Student_Progress c)
        {
            return dBHelper.EditProgress(c);
        }
    }
}
