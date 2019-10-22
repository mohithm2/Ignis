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
    public class BuildingDamageTypesController : Controller
    {
        private IgnisModel db = new IgnisModel();

        // GET: BuildingDamageTypes
        public ActionResult Index()
        {
            return View(db.BuildingDamageTypes.ToList());
        }

        // GET: BuildingDamageTypes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuildingDamageTypes buildingDamageTypes = db.BuildingDamageTypes.Find(id);
            if (buildingDamageTypes == null)
            {
                return HttpNotFound();
            }
            return View(buildingDamageTypes);
        }

        // GET: BuildingDamageTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BuildingDamageTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,IsMajor")] BuildingDamageTypes buildingDamageTypes)
        {
            if (ModelState.IsValid)
            {
                buildingDamageTypes.Id = Guid.NewGuid();
                db.BuildingDamageTypes.Add(buildingDamageTypes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(buildingDamageTypes);
        }

        // GET: BuildingDamageTypes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuildingDamageTypes buildingDamageTypes = db.BuildingDamageTypes.Find(id);
            if (buildingDamageTypes == null)
            {
                return HttpNotFound();
            }
            return View(buildingDamageTypes);
        }

        // POST: BuildingDamageTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,IsMajor")] BuildingDamageTypes buildingDamageTypes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buildingDamageTypes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(buildingDamageTypes);
        }

        // GET: BuildingDamageTypes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuildingDamageTypes buildingDamageTypes = db.BuildingDamageTypes.Find(id);
            if (buildingDamageTypes == null)
            {
                return HttpNotFound();
            }
            return View(buildingDamageTypes);
        }

        // POST: BuildingDamageTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            BuildingDamageTypes buildingDamageTypes = db.BuildingDamageTypes.Find(id);
            db.DamageTypes.Remove(buildingDamageTypes);
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
