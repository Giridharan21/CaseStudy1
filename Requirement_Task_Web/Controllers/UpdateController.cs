using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess_CF;
using Requirement_Task_Web.Models;

namespace Requirement_Task_Web.Controllers
{
    public class UpdateController : Controller
    {
        [HttpPost]
        public ActionResult Update(int Request_Id, int Executive_Id, int Trainer_Id) {
            var job = (UserInfo)Session["user"];
            if (job is null) {
                ViewBag.Position = null;
                return View();
            }
            ViewBag.Position = job.Job;
            Data.update(Request_Id, Executive_Id, Trainer_Id);
            //ViewBag.alert1 = "alert('Assigned Successfully')";

            return View();
        }

        [HttpGet]
        public ActionResult Update(string Id) {
            var job = (UserInfo)Session["user"];
            if (job is null) {
                ViewBag.Position = null;
                return View();
            }
            ViewBag.Position = job.Job;
            ViewBag.id = Id;
            return View();
        }


        public ActionResult Change() {
            return View();
        }
        [HttpPost]
        public ActionResult Change(int Request_Id, string Status) {
            var job = (UserInfo)Session["user"];
            if (job is null) {
                ViewBag.Position = null;
                return View();
            }
            ViewBag.Position = job.Job;
            Data.update(Request_Id, Status);
            ViewBag.alert2 = "alert('Changed Successfully')";
            return View();
        }
    }
}