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
    public class VehicleDamageTypesController : Controller
    {
        private IgnisModel db = new IgnisModel();

        // GET: VehicleDamageTypes
        public ActionResult Index()
        {
            return View(db.VehicleDamageTypes.ToList());
        }

        // GET: VehicleDamageTypes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleDamageType vehicleDamageType = db.VehicleDamageTypes.Find(id);
            if (vehicleDamageType == null)
            {
                return HttpNotFound();
            }
            return View(vehicleDamageType);
        }

        // GET: VehicleDamageTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleDamageTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,IsMajor")] VehicleDamageType vehicleDamageType)
        {
            if (ModelState.IsValid)
            {
                vehicleDamageType.Id = Guid.NewGuid();
                db.VehicleDamageTypes.Add(vehicleDamageType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicleDamageType);
        }

        // GET: VehicleDamageTypes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleDamageType vehicleDamageType = db.VehicleDamageTypes.Find(id);
            if (vehicleDamageType == null)
            {
                return HttpNotFound();
            }
            return View(vehicleDamageType);
        }

        // POST: VehicleDamageTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,IsMajor")] VehicleDamageType vehicleDamageType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicleDamageType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicleDamageType);
        }

        // GET: VehicleDamageTypes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleDamageType vehicleDamageType = db.VehicleDamageTypes.Find(id);
            if (vehicleDamageType == null)
            {
                return HttpNotFound();
            }
            return View(vehicleDamageType);
        }

        // POST: VehicleDamageTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            VehicleDamageType vehicleDamageType = db.VehicleDamageTypes.Find(id);
            db.VehicleDamageTypes.Remove(vehicleDamageType);
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
