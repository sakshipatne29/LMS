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
    public class StudentProgressController : Controller
    {
        public async Task<ActionResult> Index()
        {
            StudentProgressBL studProgressBL = new StudentProgressBL();
            string studProgress = await studProgressBL.GetStudent_Progresses();
            List<Student_Progress> cust = JsonConvert.DeserializeObject<List<Student_Progress>>(studProgress);

            return View(cust);
        }
    }
}