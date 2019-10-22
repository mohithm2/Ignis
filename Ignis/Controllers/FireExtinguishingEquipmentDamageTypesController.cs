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
    public class FireExtinguishingEquipmentDamageTypesController : Controller
    {
        private IgnisModel db = new IgnisModel();

        // GET: FireExtinguishingEquipmentDamageTypes
        public ActionResult Index()
        {
            return View(db.FireExtinguishingEquipmentDamageTypes.ToList());
        }

        // GET: FireExtinguishingEquipmentDamageTypes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FireExtinguishingEquipmentDamageType fireExtinguishingEquipmentDamageType = db.FireExtinguishingEquipmentDamageTypes.Find(id);
            if (fireExtinguishingEquipmentDamageType == null)
            {
                return HttpNotFound();
            }
            return View(fireExtinguishingEquipmentDamageType);
        }

        // GET: FireExtinguishingEquipmentDamageTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FireExtinguishingEquipmentDamageTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,IsMajor")] FireExtinguishingEquipmentDamageType fireExtinguishingEquipmentDamageType)
        {
            if (ModelState.IsValid)
            {
                fireExtinguishingEquipmentDamageType.Id = Guid.NewGuid();
                db.FireExtinguishingEquipmentDamageTypes.Add(fireExtinguishingEquipmentDamageType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fireExtinguishingEquipmentDamageType);
        }

        // GET: FireExtinguishingEquipmentDamageTypes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FireExtinguishingEquipmentDamageType fireExtinguishingEquipmentDamageType = db.FireExtinguishingEquipmentDamageTypes.Find(id);
            if (fireExtinguishingEquipmentDamageType == null)
            {
                return HttpNotFound();
            }
            return View(fireExtinguishingEquipmentDamageType);
        }

        // POST: FireExtinguishingEquipmentDamageTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,IsMajor")] FireExtinguishingEquipmentDamageType fireExtinguishingEquipmentDamageType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fireExtinguishingEquipmentDamageType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fireExtinguishingEquipmentDamageType);
        }

        // GET: FireExtinguishingEquipmentDamageTypes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FireExtinguishingEquipmentDamageType fireExtinguishingEquipmentDamageType = db.FireExtinguishingEquipmentDamageTypes.Find(id);
            if (fireExtinguishingEquipmentDamageType == null)
            {
                return HttpNotFound();
            }
            return View(fireExtinguishingEquipmentDamageType);
        }

        // POST: FireExtinguishingEquipmentDamageTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            FireExtinguishingEquipmentDamageType fireExtinguishingEquipmentDamageType = db.FireExtinguishingEquipmentDamageTypes.Find(id);
            db.FireExtinguishingEquipmentDamageTypes.Remove(fireExtinguishingEquipmentDamageType);
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
