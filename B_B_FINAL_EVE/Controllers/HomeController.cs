using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using B_B_FINAL_EVE.Controllers;
using B_B_FINAL_EVE.Models;

namespace B_B_FINAL_EVE.Controllers
{
    public class HomeController : Controller
    {
        BloodBankEveningEntities db = new BloodBankEveningEntities();
        public ActionResult Index()
        {
            var grp = db.BloodGroups.ToList();
            var dst = db.Districts.ToList();
            var abt = db.Posts.Where(p => p.CategoryId ==1 && p.Status == true).ToList().Take(3);
            var vul = db.Posts.Where(p => p.CategoryId == 2 && p.Status == true).ToList();

            ViewBag.groups = grp;
            ViewBag.districts = dst;
            ViewBag.about_us = abt;
            ViewBag.video_url = vul;
            return View();
        }
    }
}