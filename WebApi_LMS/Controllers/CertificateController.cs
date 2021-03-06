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
    public class CertificateController : ApiController
    {
        DBHelper dBHelper = new DBHelper();

        public List<Cours> Get()
        {
            return dBHelper.GetCourses();
        }

        [HttpPut]
        public bool Edit(Student_Progress c)
        {
            return dBHelper.EditCertificate(c);
        }
    }
}
