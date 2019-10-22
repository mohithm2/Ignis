using Ignis.DAL;
using Ignis.Models;
using Ignis.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ignis.Controllers
{
    public class VehicleDamageController : Controller
    {

        private IgnisModel db = new IgnisModel();
        
        public ActionResult ReportDamage()
        {
            ViewBag.VehicleId = new SelectList(DataFilter.GetVehicles(TempData.Peek("Id")+""), "Id", "Name");
            ViewBag.VehicleDamageTypeId = new SelectList(db.VehicleDamageTypes, "Id", "Description");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReportDamage(VehicleDamage vehicleDamage, IEnumerable<HttpPostedFileBase> image)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in image)
                {
                    string error;
                    if (!FileHelper.CheckIfFileIsImage(item, out error))
                    {
                        ModelState.AddModelError("", error);
                        ViewBag.VehicleId = new SelectList(DataFilter.GetVehicles(TempData.Peek("Id") + ""), "Id", "Name");
                        ViewBag.VehicleDamageTypeId = new SelectList(db.VehicleDamageTypes, "Id", "Description");
                        return View(vehicleDamage);
                    }
                }

                vehicleDamage.Id = Guid.NewGuid();

                string basePath = Server.MapPath(Constants.VEHICLE_DAMAGE_UPLOAD_BASE_PATH + vehicleDamage.Id + "/");
                FileHelper.SaveFiles(image, basePath);

                db.Damages.Add(vehicleDamage);
                db.SaveChanges();

                VehicleDamageStatus status = new VehicleDamageStatus
                {
                    DateOfArrival = DateTime.Now,
                    Id = Guid.NewGuid(),
                    VehicleDamageId = vehicleDamage.Id,
                    Official = ChainOfCommandHelper.GetHigherOfficial()
                };
                status.CaseId = vehicleDamage.Id;
                db.DamageStatuses.Add(status);
                db.SaveChanges();

                return RedirectToAction("ViewOpenTickets");
            }

            ViewBag.VehicleId = new SelectList(DataFilter.GetVehicles(TempData.Peek("Id") + ""), "Id", "Name");
            ViewBag.VehicleDamageTypeId = new SelectList(db.VehicleDamageTypes, "Id", "Description");
            return View(vehicleDamage);
        }

        public ActionResult ViewOpenVehicleDamages()
        {
            Official currentOfficial = ChainOfCommandHelper.GetCurrentOfficial();
            return View(db.DamageStatuses.Where(x => x.Official == currentOfficial && x.DateOfLeaving == null).ToList());
        }

        public ActionResult ViewTickets()
        {
            List<Vehicle> vehicles = DataFilter.GetVehicles(TempData.Peek("Id") + "");
            List<VehicleDamageStatus> statuses = vehicles.SelectMany(x => x.VehicleDamages)
                .SelectMany(y => y.VehicleDamageStatuses).ToList();

            return View(statuses);
        }


        public ActionResult ViewVehicleDamage(Guid id)
        {
            Damage vehicleDamage = db.Damages.Find(id);

            string basePath = Server.MapPath(Constants.VEHICLE_DAMAGE_UPLOAD_BASE_PATH + vehicleDamage.Id + "/");
            if (Directory.Exists(basePath))
            {
                TempData["DamageImages"] = FileHelper.GetImages(vehicleDamage.Id + "", basePath);
            }

            return PartialView(vehicleDamage);
        }

        public ActionResult ViewFileMovement(Guid id)
        {
            return PartialView(db.DamageStatuses.Where(x => x.CaseId == id).ToList());
        }

        public ActionResult ViewVehicle(Guid id)
        {
            Vehicle vehicle = db.VehicleDamages.Where(x => x.Id == id).First().Vehicle;
            string basePath = Server.MapPath(Constants.VEHICLE_UPLOAD_BASE_PATH + vehicle.Id + "/");
            if (Directory.Exists(basePath))
            {
                TempData["VehicleImages"] = FileHelper.GetImages(vehicle.Id + "", basePath);
            }

            return PartialView(vehicle);
        }

        public ActionResult ViewPreviousDamages(Guid id)
        {
            VehicleDamage damage = db.VehicleDamages.Where(x => x.Id == id).First();            
            return PartialView(db.VehicleDamages
                .Where(x => x.VehicleId == damage.VehicleId && x.VehicleDamageTypeId == damage.VehicleDamageTypeId).ToList());
        }

        public ActionResult ViewTicket(Guid id)
        {
            VehicleDamageStatus status = db.VehicleDamagesStatus.Find(id);
            return View(status);
        }

        public ActionResult CloseTicket(Guid id)
        {
            TempData["StatusId"] = id;
            VehicleDamageStatus status = db.VehicleDamagesStatus.Find(id);

            VehicleRepair reapir = new VehicleRepair
            {
                Id = status.VehicleDamageId,
                VehicleDamage = status.VehicleDamage
            };

            return View(reapir);
        }

        [HttpPost]
        public ActionResult CloseTicket(VehicleRepair repair, IEnumerable<HttpPostedFileBase> image)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in image)
                {
                    string error;
                    if (!FileHelper.CheckIfFileIsImage(item, out error))
                    {
                        ModelState.AddModelError("", error);
                        return View(repair);
                    }
                }

                string basePath = Server.MapPath(Constants.VEHICLE_REPAIR_UPLOAD_BASE_PATH + repair.Id + "/");
                FileHelper.SaveFiles(image, basePath);

                VehicleDamageStatus status = db.VehicleDamagesStatus.Find(TempData.Peek("StatusId"));
                repair.Id = status.VehicleDamageId;
                db.VehicleRepairs.Add(repair);
                db.SaveChanges();

                status.Action = DamageAction.Closed;
                db.Entry(status).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("ViewClosedTickets");
            }

            return View(repair);
        }

        public ActionResult ViewClosedTickets()
        {
            List<Vehicle> vehicles = DataFilter.GetVehicles(TempData.Peek("Id") + "");
            List<VehicleDamageStatus> statuses = vehicles.SelectMany(x => x.VehicleDamages)
                .SelectMany(y => y.VehicleDamageStatuses).ToList();
            return View(statuses);
        }

        public ActionResult ViewOpenTickets()
        {
            List<Vehicle> vehicles = DataFilter.GetVehicles(TempData.Peek("Id") + "");
            List<VehicleDamageStatus> statuses = vehicles.SelectMany(x => x.VehicleDamages)
                .SelectMany(y => y.VehicleDamageStatuses).ToList();
            return View(statuses);
        }

        public ActionResult ViewRepair(Guid id)
        {
            string basePath = Server.MapPath(Constants.VEHICLE_REPAIR_UPLOAD_BASE_PATH + id + "/");
            if (Directory.Exists(basePath))
            {
                TempData["RapairImages"] = FileHelper.GetImages(id + "", basePath);
            }

            return PartialView(db.VehicleRepairs.Find(id));
        }

        public ActionResult ViewClosedTicket(Guid id)
        {
            VehicleDamageStatus status = db.VehicleDamagesStatus.Find(id);
            return View(status);
        }

        public ActionResult ViewDamage(Guid id)
        {
            return View();
        }

        public ActionResult ActOnDamage(Guid id)
        {
            DamageStatus status = db.DamageStatuses.Find(id);
            
            return View(status);
        }

        [HttpPost]
        public ActionResult ActOnDamage(VehicleDamageStatus status)
        {
            if(ModelState.IsValid)
            {
                if(status.Action == DamageAction.Open)
                {
                    ModelState.AddModelError("Action", "Action can not be open");
                    return View(status);
                }

                status.DateOfLeaving = DateTime.Now;
                db.Entry(status).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                if (status.Action == DamageAction.Elevate)
                {
                    VehicleDamageStatus newStatus = new VehicleDamageStatus
                    {
                        Id = Guid.NewGuid(),
                        CaseId = status.CaseId,
                        DateOfArrival = DateTime.Now,
                        Official = ChainOfCommandHelper.GetHigherOfficial(),
                        VehicleDamageId = status.VehicleDamageId
                    };
                    db.VehicleDamagesStatus.Add(newStatus);
                    db.SaveChanges();
                }
                else if(status.Action == DamageAction.Disapprove)
                {
                    VehicleDamageStatus newStatus =  db.VehicleDamagesStatus.Where(x => x.CaseId == status.CaseId).OrderByDescending(x => x.DateOfArrival).First();
                    newStatus.Action = DamageAction.Disapprove;
                    db.Entry(newStatus).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("ViewOpenVehicleDamages");
            }

            return View(status);
        }
    }
}