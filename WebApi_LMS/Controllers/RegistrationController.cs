using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi_LMS.Controllers
{
    public class RegistrationController : ApiController
    {
        [HttpPost]
        public bool Post(User_Details u)
        {
            DBHelper dBHelper = new DBHelper();
            return dBHelper.AddRegistrationDetails(u);
        }
    }
}
