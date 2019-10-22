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
    public class ZoneRangesController : Controller
    {
        private IgnisModel db = new IgnisModel();

        // GET: ZoneRanges
        public ActionResult Index()
        {
            return View(DataFilter.GetZoneRanges(TempData.Peek("Id")+""));
        }

        // GET: ZoneRanges/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZoneRange zoneRange = db.ZoneRanges.Find(id);
            if (zoneRange == null)
            {
                return HttpNotFound();
            }
            return View(zoneRange);
        }

        // GET: ZoneRanges/Create
        public ActionResult Create()
        {
            ViewBag.RangeId = new SelectList(DataFilter.GetRanges(TempData.Peek("Id") + ""), "Id", "Name");
            ViewBag.ZoneId = new SelectList(DataFilter.GetZones(TempData.Peek("Id") + ""), "Id", "Name");
            return View();
        }

        // POST: ZoneRanges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ZoneId,RangeId")] ZoneRange zoneRange)
        {
            if (ModelState.IsValid)
            {
                zoneRange.Id = Guid.NewGuid();
                db.ZoneRanges.Add(zoneRange);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RangeId = new SelectList(DataFilter.GetRanges(TempData.Peek("Id") + ""), "Id", "Name", zoneRange.RangeId);
            ViewBag.ZoneId = new SelectList(DataFilter.GetZones(TempData.Peek("Id") + ""), "Id", "Name", zoneRange.ZoneId);
            return View(zoneRange);
        }

        // GET: ZoneRanges/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZoneRange zoneRange = db.ZoneRanges.Find(id);
            if (zoneRange == null)
            {
                return HttpNotFound();
            }
            ViewBag.RangeId = new SelectList(DataFilter.GetRanges(TempData.Peek("Id") + ""), "Id", "Name", zoneRange.RangeId);
            ViewBag.ZoneId = new SelectList(DataFilter.GetZones(TempData.Peek("Id") + ""), "Id", "Name", zoneRange.ZoneId);
            return View(zoneRange);
        }

        // POST: ZoneRanges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ZoneId,RangeId")] ZoneRange zoneRange)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zoneRange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RangeId = new SelectList(DataFilter.GetRanges(TempData.Peek("Id") + ""), "Id", "Name", zoneRange.RangeId);
            ViewBag.ZoneId = new SelectList(DataFilter.GetZones(TempData.Peek("Id") + ""), "Id", "Name", zoneRange.ZoneId);
            return View(zoneRange);
        }

        // GET: ZoneRanges/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZoneRange zoneRange = db.ZoneRanges.Find(id);
            if (zoneRange == null)
            {
                return HttpNotFound();
            }
            return View(zoneRange);
        }

        // POST: ZoneRanges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ZoneRange zoneRange = db.ZoneRanges.Find(id);
            db.ZoneRanges.Remove(zoneRange);
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
