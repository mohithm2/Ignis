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
    public class TyreChangesController : Controller
    {
        private IgnisModel db = new IgnisModel();

        // GET: TyreChanges
        public ActionResult Index()
        {
            return View(DataFilter.GetTyreChanges(TempData.Peek("Id")+""));
        }

        // GET: TyreChanges/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TyreChange tyreChange = db.TyreChanges.Find(id);
            if (tyreChange == null)
            {
                return HttpNotFound();
            }
            return View(tyreChange);
        }

        // GET: TyreChanges/Create
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

        // POST: TyreChanges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OdometerReading,RoadRunKilometer,PumpRunKilometer,DateOfChange,VehicleId")] TyreChange tyreChange)
        {
            if (ModelState.IsValid)
            {
                tyreChange.Id = Guid.NewGuid();
                db.TyreChanges.Add(tyreChange);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VehicleId = new SelectList(DataFilter.GetVehicles(TempData.Peek("Id") + ""), "Id", "RegistrationNumber", tyreChange.VehicleId);
            return View(tyreChange);
        }

        // GET: TyreChanges/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TyreChange tyreChange = db.TyreChanges.Find(id);
            if (tyreChange == null)
            {
                return HttpNotFound();
            }
            ViewBag.VehicleId = new SelectList(DataFilter.GetVehicles(TempData.Peek("Id") + ""), "Id", "RegistrationNumber", tyreChange.VehicleId);
            return View(tyreChange);
        }

        // POST: TyreChanges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OdometerReading,RoadRunKilometer,PumpRunKilometer,DateOfChange,VehicleId")] TyreChange tyreChange)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tyreChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VehicleId = new SelectList(DataFilter.GetVehicles(TempData.Peek("Id") + ""), "Id", "RegistrationNumber", tyreChange.VehicleId);
            return View(tyreChange);
        }

        // GET: TyreChanges/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TyreChange tyreChange = db.TyreChanges.Find(id);
            if (tyreChange == null)
            {
                return HttpNotFound();
            }
            return View(tyreChange);
        }

        // POST: TyreChanges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            TyreChange tyreChange = db.TyreChanges.Find(id);
            db.TyreChanges.Remove(tyreChange);
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
