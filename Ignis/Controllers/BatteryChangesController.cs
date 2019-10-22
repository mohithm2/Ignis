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

namespace Ignis.Controllers
{
    [Authorize]
    public class BatteryChangesController : Controller
    {
        private IgnisModel db = new IgnisModel();

        // GET: BatteryChanges
        public ActionResult Index()
        {
            return View(DataFilter.GetBatteryChanges(TempData.Peek("id")+""));
        }

        // GET: BatteryChanges/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BatteryChange batteryChange = db.BatteryChanges.Find(id);
            if (batteryChange == null)
            {
                return HttpNotFound();
            }
            return View(batteryChange);
        }

        // GET: BatteryChanges/Create
        public ActionResult Create(Guid? id)
        {
            if (id.HasValue)
            {
                ViewBag.VehicleId = new SelectList(DataFilter.GetVehicles(TempData.Peek("Id") + ""), "Id", "RegistrationNumber", id.Value);
            }
            else
            {
                ViewBag.VehicleId = new SelectList(DataFilter.GetVehicles(TempData.Peek("Id") + ""), "Id", "RegistrationNumber");
            }
            return View();
        }

        // POST: BatteryChanges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OdometerReading,RoadRunKilometer,PumpRunKilometer,DateOfChange,VehicleId")] BatteryChange batteryChange)
        {
            if (ModelState.IsValid)
            {
                batteryChange.Id = Guid.NewGuid();
                db.BatteryChanges.Add(batteryChange);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VehicleId = new SelectList(DataFilter.GetVehicles(TempData.Peek("id") + ""), "Id", "RegistrationNumber", batteryChange.VehicleId);
            return View(batteryChange);
        }

        // GET: BatteryChanges/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BatteryChange batteryChange = db.BatteryChanges.Find(id);
            if (batteryChange == null)
            {
                return HttpNotFound();
            }
            ViewBag.VehicleId = new SelectList(DataFilter.GetVehicles(TempData.Peek("id") + ""), "Id", "RegistrationNumber", batteryChange.VehicleId);
            return View(batteryChange);
        }

        // POST: BatteryChanges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OdometerReading,RoadRunKilometer,PumpRunKilometer,DateOfChange,VehicleId")] BatteryChange batteryChange)
        {
            if (ModelState.IsValid)
            {
                db.Entry(batteryChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VehicleId = new SelectList(DataFilter.GetVehicles(TempData.Peek("id") + ""), "Id", "RegistrationNumber", batteryChange.VehicleId);
            return View(batteryChange);
        }

        // GET: BatteryChanges/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BatteryChange batteryChange = db.BatteryChanges.Find(id);
            if (batteryChange == null)
            {
                return HttpNotFound();
            }
            return View(batteryChange);
        }

        // POST: BatteryChanges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            BatteryChange batteryChange = db.BatteryChanges.Find(id);
            db.BatteryChanges.Remove(batteryChange);
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
