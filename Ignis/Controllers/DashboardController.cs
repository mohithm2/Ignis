using Ignis.Models;
using Ignis.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ignis.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult GetNumberOfVehicles()
        {
            return Content(DataFilter.GetVehicles(TempData.Peek("Id") + "").Count() + "");
        }

        public ActionResult GetNumberOfFireStation()
        {
            return Content(DataFilter.GetFireStations(TempData.Peek("Id") + "").Count() + "");
        }

        public ActionResult GetNumberOfVehicleEquipment()
        {
            return Content(DataFilter.GetVehicleEquipments(TempData.Peek("Id") + "").Count() + "");
        }

        public ActionResult GetNumberOfFireExtinguishingEquipment()
        {
            return Content(DataFilter.GetFireExtingushingEquipments(TempData.Peek("Id") + "").Count() + "");
        }

        public ActionResult GetOpenTickets()
        {
            List<DamageStatus> statues = TicketHelper.GetDamageStatuses(TempData.Peek("Id") + "");
            return Content(statues.Where(x => (x.Action == Models.DamageAction.Approve || x.Action == Models.DamageAction.Open) && (statues.Where(y => y.CaseId == x.CaseId && y.Action == DamageAction.Closed).Count() == 0)).Count() + "");
        }

        public ActionResult GetNotifications()
        {
            return Content("0");
        }
    }
}