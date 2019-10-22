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

namespace Ignis.Controllers
{
    [Authorize]
    public class VehicleEquipmentTypesController : Controller
    {
        private IgnisModel db = new IgnisModel();

        // GET: VehicleEquipmentTypes
        public ActionResult Index()
        {
            return View(db.VehicleEquipmentTypes.ToList());
        }

        // GET: VehicleEquipmentTypes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleEquipmentType vehicleEquipmentType = db.VehicleEquipmentTypes.Find(id);
            if (vehicleEquipmentType == null)
            {
                return HttpNotFound();
            }
            return View(vehicleEquipmentType);
        }

        // GET: VehicleEquipmentTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleEquipmentTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Make,Model,YearOfManufacture,Cost,IsFuelRequired")] VehicleEquipmentType vehicleEquipmentType)
        {
            if (ModelState.IsValid)
            {
                vehicleEquipmentType.Id = Guid.NewGuid();
                db.VehicleEquipmentTypes.Add(vehicleEquipmentType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicleEquipmentType);
        }

        // GET: VehicleEquipmentTypes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleEquipmentType vehicleEquipmentType = db.VehicleEquipmentTypes.Find(id);
            if (vehicleEquipmentType == null)
            {
                return HttpNotFound();
            }
            return View(vehicleEquipmentType);
        }

        // POST: VehicleEquipmentTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Make,Model,YearOfManufacture,Cost,IsFuelRequired")] VehicleEquipmentType vehicleEquipmentType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicleEquipmentType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicleEquipmentType);
        }

        // GET: VehicleEquipmentTypes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleEquipmentType vehicleEquipmentType = db.VehicleEquipmentTypes.Find(id);
            if (vehicleEquipmentType == null)
            {
                return HttpNotFound();
            }
            return View(vehicleEquipmentType);
        }

        // POST: VehicleEquipmentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            VehicleEquipmentType vehicleEquipmentType = db.VehicleEquipmentTypes.Find(id);
            db.VehicleEquipmentTypes.Remove(vehicleEquipmentType);
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
