using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ignis.DAL;
using Ignis.Models;
using Ignis.Util;
using System.IO;
using System.Globalization;

namespace Ignis.Controllers
{
    [Authorize]
    public class VehiclesController : Controller
    {
        private IgnisModel db = new IgnisModel();

        // GET: Vehicles
        public ActionResult Index()
        {
            return View(DataFilter.GetVehicles(TempData.Peek("Id") + ""));
        }

        // GET: Vehicles/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }

            string basePath = Server.MapPath(Constants.VEHICLE_UPLOAD_BASE_PATH + vehicle.Id + "/");
            if (Directory.Exists(basePath))
            {
                TempData["Images"] = FileHelper.GetImages(vehicle.Id + "", basePath);
            }

            return View(vehicle);
        }

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(
                TempData.Peek("Id") + ""), "Id", "Name");
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Make,Model,RegistrationNumber,Cost,DateOfPurchase,EngineNumber,CapacityFuelTank,TaxCard,SanctionOrderNumber,SanctionDate,TheoreticalMileage,KilometersCovered,Usage,CapacityOfAttachement,FireStationId,PhotoNoth,PhotoSouth,PhotoEast,PhotoWest")] Vehicle vehicle,
            IEnumerable<HttpPostedFileBase> image)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in image)
                {
                    string error;
                    if (!FileHelper.CheckIfFileIsImage(item, out error))
                    {
                        ModelState.AddModelError("", error);
                        ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("Id") + ""), "Id", "Name", vehicle.FireStationId);
                        return View(vehicle);
                    }
                }
                vehicle.Id = Guid.NewGuid();

                string basePath = Server.MapPath(Constants.VEHICLE_UPLOAD_BASE_PATH + vehicle.Id + "/");
                FileHelper.SaveFiles(image, basePath);

                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("Id") + ""), "Id", "Name", vehicle.FireStationId);
            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("Id") + ""), "Id", "Name", vehicle.FireStationId);
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Make,Model,RegistrationNumber,Cost,DateOfPurchase,EngineNumber,CapacityFuelTank,TaxCard,SanctionOrderNumber,SanctionDate,TheoreticalMileage,KilometersCovered,Usage,CapacityOfAttachement,FireStationId")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("Id") + ""), "Id", "Name", vehicle.FireStationId);
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
