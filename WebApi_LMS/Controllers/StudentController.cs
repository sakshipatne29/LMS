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
    public class StudentController : ApiController
    {

        public List<User_Details> Get()
        {
            DBHelper dBHelper = new DBHelper();

            Configuration.Formatters.Remove(Configuration.Formatters.XmlFormatter);
            return dBHelper.GetUserDetails();
        }

        [HttpPost]
        public bool Post(User_Details u)
        {
            DBHelper dBHelper = new DBHelper();
            return dBHelper.AddUserDetails(u);
        }

        [HttpPut]
        public bool Edit(User_Details u)
        {
            DBHelper dBHelper = new DBHelper();
            return dBHelper.EditStudent(u);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            DBHelper dBHelper = new DBHelper();
            return dBHelper.DeleteStudent(id);
        }
    }
}
