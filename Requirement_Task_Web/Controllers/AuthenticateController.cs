using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess_CF;
using Requirement_Task_Web.Models;
namespace Requirement_Task_Web.Controllers
{
    public class AuthenticateController : Controller
    {
        public ActionResult Index() {
            //For login
            var job = (UserInfo)Session["user"];
            if (job is null) {
                ViewBag.Position = null;
                return View();
            }
            ViewBag.Position = job.Job;
            return View();
        }



        public ActionResult Login() {

            return View();
        }
        [HttpPost]
        public ActionResult Login(UserInfoModel user) {
            
            var user2 = new UserInfo() { Id = user.Id, Job = user.Job, Name = user.Name, Pass = user.Pass };
            var loggedInUser = Data.Authenticate(user2);
            if (!(loggedInUser is null)) {
                Session["user"] = loggedInUser;
                return Redirect("~/Authenticate/index");
            }
            ViewBag.Value = "alert('Invalid User')";
            return View();
        }

    }
}