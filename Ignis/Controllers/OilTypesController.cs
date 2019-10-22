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
    public class OilTypesController : Controller
    {
        private IgnisModel db = new IgnisModel();

        // GET: OilTypes
        public ActionResult Index()
        {
            return View(db.OilTypes.ToList());
        }

        // GET: OilTypes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OilType oilType = db.OilTypes.Find(id);
            if (oilType == null)
            {
                return HttpNotFound();
            }
            return View(oilType);
        }

        // GET: OilTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OilTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] OilType oilType)
        {
            if (ModelState.IsValid)
            {
                oilType.Id = Guid.NewGuid();
                db.OilTypes.Add(oilType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oilType);
        }

        // GET: OilTypes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OilType oilType = db.OilTypes.Find(id);
            if (oilType == null)
            {
                return HttpNotFound();
            }
            return View(oilType);
        }

        // POST: OilTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] OilType oilType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oilType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oilType);
        }

        // GET: OilTypes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OilType oilType = db.OilTypes.Find(id);
            if (oilType == null)
            {
                return HttpNotFound();
            }
            return View(oilType);
        }

        // POST: OilTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            OilType oilType = db.OilTypes.Find(id);
            db.OilTypes.Remove(oilType);
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
