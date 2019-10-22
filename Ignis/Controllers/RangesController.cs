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
    public class RangesController : Controller
    {
        private IgnisModel db = new IgnisModel();

        // GET: Ranges
        public ActionResult Index()
        {
            return View(DataFilter.GetRanges(TempData.Peek("Id")+""));
        }

        // GET: Ranges/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Range range = db.Ranges.Find(id);
            if (range == null)
            {
                return HttpNotFound();
            }
            return View(range);
        }

        // GET: Ranges/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ranges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Range range)
        {
            if (ModelState.IsValid)
            {
                range.Id = Guid.NewGuid();
                db.Ranges.Add(range);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(range);
        }

        // GET: Ranges/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Range range = db.Ranges.Find(id);
            if (range == null)
            {
                return HttpNotFound();
            }
            return View(range);
        }

        // POST: Ranges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Range range)
        {
            if (ModelState.IsValid)
            {
                db.Entry(range).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(range);
        }

        // GET: Ranges/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Range range = db.Ranges.Find(id);
            if (range == null)
            {
                return HttpNotFound();
            }
            return View(range);
        }

        // POST: Ranges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Range range = db.Ranges.Find(id);
            db.Ranges.Remove(range);
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
