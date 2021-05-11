using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLayer.Models;
using BusinessLayer;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MVC_LMS.Models;

namespace MVCLayer.Controllers
{
    public class LoginController : Controller
    {

        // GET: Login
        public ActionResult Index()
        {

            this.Session["token"] = "i was called";
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Index(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {

                LoginBL loginBL = new LoginBL();
                loginModel.grant_type = "UserPassword";

                string request = JsonConvert.SerializeObject(loginModel);
                string token = await loginBL.Login(request);
                MyAccessToken myToken = JsonConvert.DeserializeObject<MyAccessToken>(token);
                Session["token"] = myToken.access_token;
                Session["loggedIn"] = "true";
                Session["UserName"] = loginModel.UserName;
                StudentBL studentBL = new StudentBL();
                string Users = await studentBL.GetStudents();
                List<User_Details> user = JsonConvert.DeserializeObject<List<User_Details>>(Users);
                foreach (User_Details u in user)
                {
                    if (u.UserName == loginModel.UserName && u.Category == "Admin")
                    {
                        return RedirectToAction("Index", "AdminHome");
                    }
                    else if (u.UserName == loginModel.UserName && u.Category == "Student")
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                return RedirectToAction("Error", "Login");
            }
            return View("Index");
        }

        public ActionResult Error(string response)
        {
            ViewBag.response = response;
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return View();
        }
    }
}