using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess_CF;
using Requirement_Task_Web.Models;
namespace Requirement_Task_Web.Controllers
{
    public class DashboardController : Controller
    {
        public ActionResult Create() {
            var job = (UserInfo)Session["user"];
            if (job is null) {
                ViewBag.Position = null;
                return View();
            }
            ViewBag.Position = job.Job;

            return View();
        }
        [HttpPost]
        public ActionResult Create(NewRequestModel req) {
            var user =(UserInfo) Session["user"];
            //For login
            if (user is null) {
            ViewBag.Position = null;
                return View();
            }
            ViewBag.Position = user.Job;
            var req2 = new NewRequest() { Skill=req.Skill, Id = req.Id, Name = req.Name, Start = req.Start, End = req.End, ProjManID = user.Id };
            
            Data.CreateRequest(req2);
            ViewBag.alert = "alert('Request Created Successfully')";
            return View();
        }

        public ActionResult ViewReq() {
            var user = (UserInfo)Session["user"];
            //For login
            if (user is null) {
                ViewBag.Position = null;
                return View();
            }
            ViewBag.Position = user.Job;
            ViewBag.UserName = user.Name;
            ViewBag.Job = user.Job;
            return View(Data.ViewCreatedRequest());
        }

        public ActionResult Approve(int Id) {

            return View();
        }
        [HttpPost]
        public ActionResult Approve() {
            return View();
        }
    }
}