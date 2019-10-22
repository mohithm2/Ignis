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
    public class VehicleEquipmentDamageTypesController : Controller
    {
        private IgnisModel db = new IgnisModel();

        // GET: VehicleEquipmentDamageTypes
        public ActionResult Index()
        {
            return View(db.VehicleEquipmentDamageTypes.ToList());
        }

        // GET: VehicleEquipmentDamageTypes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleEquipmentDamageType vehicleEquipmentDamageType = db.VehicleEquipmentDamageTypes.Find(id);
            if (vehicleEquipmentDamageType == null)
            {
                return HttpNotFound();
            }
            return View(vehicleEquipmentDamageType);
        }

        // GET: VehicleEquipmentDamageTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleEquipmentDamageTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,IsMajor")] VehicleEquipmentDamageType vehicleEquipmentDamageType)
        {
            if (ModelState.IsValid)
            {
                vehicleEquipmentDamageType.Id = Guid.NewGuid();
                db.VehicleEquipmentDamageTypes.Add(vehicleEquipmentDamageType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicleEquipmentDamageType);
        }

        // GET: VehicleEquipmentDamageTypes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleEquipmentDamageType vehicleEquipmentDamageType = db.VehicleEquipmentDamageTypes.Find(id);
            if (vehicleEquipmentDamageType == null)
            {
                return HttpNotFound();
            }
            return View(vehicleEquipmentDamageType);
        }

        // POST: VehicleEquipmentDamageTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,IsMajor")] VehicleEquipmentDamageType vehicleEquipmentDamageType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicleEquipmentDamageType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicleEquipmentDamageType);
        }

        // GET: VehicleEquipmentDamageTypes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleEquipmentDamageType vehicleEquipmentDamageType = db.VehicleEquipmentDamageTypes.Find(id);
            if (vehicleEquipmentDamageType == null)
            {
                return HttpNotFound();
            }
            return View(vehicleEquipmentDamageType);
        }

        // POST: VehicleEquipmentDamageTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            VehicleEquipmentDamageType vehicleEquipmentDamageType = db.VehicleEquipmentDamageTypes.Find(id);
            db.VehicleEquipmentDamageTypes.Remove(vehicleEquipmentDamageType);
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
