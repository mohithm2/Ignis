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
    public class FireExtinguishingEquipmentTypesController : Controller
    {
        private IgnisModel db = new IgnisModel();

        // GET: FireExtinguishingEquipmentTypes
        public ActionResult Index()
        {
            return View(db.FireExtinguishingEquipmentTypes.ToList());
        }

        // GET: FireExtinguishingEquipmentTypes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FireExtinguishingEquipmentType fireExtinguishingEquipmentType = db.FireExtinguishingEquipmentTypes.Find(id);
            if (fireExtinguishingEquipmentType == null)
            {
                return HttpNotFound();
            }
            return View(fireExtinguishingEquipmentType);
        }

        // GET: FireExtinguishingEquipmentTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FireExtinguishingEquipmentTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Make,Model,YearOfManufacture,Cost,IsFuelRequired")] FireExtinguishingEquipmentType fireExtinguishingEquipmentType)
        {
            if (ModelState.IsValid)
            {
                fireExtinguishingEquipmentType.Id = Guid.NewGuid();
                db.FireExtinguishingEquipmentTypes.Add(fireExtinguishingEquipmentType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fireExtinguishingEquipmentType);
        }

        // GET: FireExtinguishingEquipmentTypes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FireExtinguishingEquipmentType fireExtinguishingEquipmentType = db.FireExtinguishingEquipmentTypes.Find(id);
            if (fireExtinguishingEquipmentType == null)
            {
                return HttpNotFound();
            }
            return View(fireExtinguishingEquipmentType);
        }

        // POST: FireExtinguishingEquipmentTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Make,Model,YearOfManufacture,Cost,IsFuelRequired")] FireExtinguishingEquipmentType fireExtinguishingEquipmentType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fireExtinguishingEquipmentType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fireExtinguishingEquipmentType);
        }

        // GET: FireExtinguishingEquipmentTypes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FireExtinguishingEquipmentType fireExtinguishingEquipmentType = db.FireExtinguishingEquipmentTypes.Find(id);
            if (fireExtinguishingEquipmentType == null)
            {
                return HttpNotFound();
            }
            return View(fireExtinguishingEquipmentType);
        }

        // POST: FireExtinguishingEquipmentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            FireExtinguishingEquipmentType fireExtinguishingEquipmentType = db.FireExtinguishingEquipmentTypes.Find(id);
            db.FireExtinguishingEquipmentTypes.Remove(fireExtinguishingEquipmentType);
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
