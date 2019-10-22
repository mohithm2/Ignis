using Ignis.DAL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ignis.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (User.IsInRole("admin"))
            {
                return RedirectToAction("AdminHome", "Home");
            }
            else if (User.IsInRole("ig"))
            {
                return RedirectToAction("IgHome", "Home");
            }
            else if (User.IsInRole("cfo"))
            {
                return RedirectToAction("CfoHome", "Home");
            }
            else if (User.IsInRole("dfo"))
            {
                return RedirectToAction("DfoHome", "Home");
            }
            else if (User.IsInRole("rfo"))
            {
                return RedirectToAction("RfoHome", "Home");
            }
            else if (User.IsInRole("zfo"))
            {
                return RedirectToAction("ZfoHome", "Home");
            }
            return View();
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public ActionResult CfoHome()
        {
            IgnisModel model = new IgnisModel();
            TempData["FireStationName"] = model.FireStations.Find(model.Users.Find(
                Guid.Parse(User.Identity.GetUserId())).InfrastructureId).Name;
            TempData["Id"] = model.Users.Find(Guid.Parse(
                User.Identity.GetUserId())).InfrastructureId;
            return View();
        }

        [Authorize]
        public ActionResult DfoHome()
        {
            IgnisModel model = new IgnisModel();
            TempData["DistrictName"] = model.Districts.Find(model.Users.Find(
                Guid.Parse(User.Identity.GetUserId())).InfrastructureId).Name;
            TempData["Id"] = model.Users.Find(Guid.Parse(
                User.Identity.GetUserId())).InfrastructureId;
            return View();
        }

        [Authorize]
        public ActionResult RfoHome()
        {
            IgnisModel model = new IgnisModel();
            TempData["RangeName"] = model.Ranges.Find(model.Users.Find(
                Guid.Parse(User.Identity.GetUserId())).InfrastructureId).Name;
            TempData["Id"] = model.Users.Find(Guid.Parse(
                User.Identity.GetUserId())).InfrastructureId;
            return View();
        }

        [Authorize]
        public ActionResult ZfoHome()
        {
            IgnisModel model = new IgnisModel();
            TempData["ZoneName"] = model.Zones.Find(model.Users.Find(
                Guid.Parse(User.Identity.GetUserId())).InfrastructureId).Name;
            TempData["Id"] = model.Users.Find(Guid.Parse(
                User.Identity.GetUserId())).InfrastructureId;
            return View();
        }

        [Authorize]
        public ActionResult AdminHome()
        {
            return View();
        }

        [Authorize]
        public ActionResult IgHome()
        {
            return View();
        }
    }
}