using BusinessLayer;
using MVC_LMS.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC_LMS.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(User_Details u)
        {
            RegistrationBL reg = new RegistrationBL();
            string student = JsonConvert.SerializeObject(u);
            string result = await reg.Register(student);
            if (result == "true")
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}