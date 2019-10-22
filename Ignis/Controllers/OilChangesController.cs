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
    public class OilChangesController : Controller
    {
        private IgnisModel db = new IgnisModel();

        // GET: OilChanges
        public ActionResult Index()
        {
            return View(DataFilter.GetOilChanges(TempData.Peek("Id")+""));
        }

        // GET: OilChanges/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OilChange oilChange = db.OilChanges.Find(id);
            if (oilChange == null)
            {
                return HttpNotFound();
            }
            return View(oilChange);
        }

        // GET: OilChanges/Create
        public ActionResult Create(Guid? id)
        {
            ViewBag.OilTypeId = new SelectList(db.OilTypes, "Id", "Name");
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

        // POST: OilChanges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OdometerReading,RoadRunKilometer,PumpRunKilometer,DateOfChange,OilTypeId,VehicleId")] OilChange oilChange)
        {
            if (ModelState.IsValid)
            {
                oilChange.Id = Guid.NewGuid();
                db.OilChanges.Add(oilChange);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OilTypeId = new SelectList(db.OilTypes, "Id", "Name", oilChange.OilTypeId);
            ViewBag.VehicleId = new SelectList(DataFilter.GetVehicles(TempData.Peek("Id") + ""), "Id", "RegistrationNumber", oilChange.VehicleId);
            return View(oilChange);
        }

        // GET: OilChanges/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OilChange oilChange = db.OilChanges.Find(id);
            if (oilChange == null)
            {
                return HttpNotFound();
            }
            ViewBag.OilTypeId = new SelectList(db.OilTypes, "Id", "Name", oilChange.OilTypeId);
            ViewBag.VehicleId = new SelectList(DataFilter.GetVehicles(TempData.Peek("Id") + ""), "Id", "RegistrationNumber", oilChange.VehicleId);
            return View(oilChange);
        }

        // POST: OilChanges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OdometerReading,RoadRunKilometer,PumpRunKilometer,DateOfChange,OilTypeId,VehicleId")] OilChange oilChange)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oilChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OilTypeId = new SelectList(db.OilTypes, "Id", "Name", oilChange.OilTypeId);
            ViewBag.VehicleId = new SelectList(DataFilter.GetVehicles(TempData.Peek("Id") + ""), "Id", "RegistrationNumber", oilChange.VehicleId);
            return View(oilChange);
        }

        // GET: OilChanges/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OilChange oilChange = db.OilChanges.Find(id);
            if (oilChange == null)
            {
                return HttpNotFound();
            }
            return View(oilChange);
        }

        // POST: OilChanges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            OilChange oilChange = db.OilChanges.Find(id);
            db.OilChanges.Remove(oilChange);
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
