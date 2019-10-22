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
    public class RangeDistrictsController : Controller
    {
        private IgnisModel db = new IgnisModel();

        // GET: RangeDistricts
        public ActionResult Index()
        {
            return View(DataFilter.GetRangeDistricts(TempData.Peek("Id")+""));
        }

        // GET: RangeDistricts/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RangeDistrict rangeDistrict = db.RangeDistricts.Find(id);
            if (rangeDistrict == null)
            {
                return HttpNotFound();
            }
            return View(rangeDistrict);
        }

        // GET: RangeDistricts/Create
        public ActionResult Create()
        {
            ViewBag.DistrictId = new SelectList(DataFilter.GetDistricts(TempData.Peek("Id") + ""), "Id", "Name");
            ViewBag.RangeId = new SelectList(DataFilter.GetRanges(TempData.Peek("Id") + ""), "Id", "Name");
            return View();
        }

        // POST: RangeDistricts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RangeId,DistrictId")] RangeDistrict rangeDistrict)
        {
            if (ModelState.IsValid)
            {
                rangeDistrict.Id = Guid.NewGuid();
                db.RangeDistricts.Add(rangeDistrict);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DistrictId = new SelectList(DataFilter.GetDistricts(TempData.Peek("Id") + ""), "Id", "Name", rangeDistrict.DistrictId);
            ViewBag.RangeId = new SelectList(DataFilter.GetRanges(TempData.Peek("Id") + ""), "Id", "Name", rangeDistrict.RangeId);
            return View(rangeDistrict);
        }

        // GET: RangeDistricts/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RangeDistrict rangeDistrict = db.RangeDistricts.Find(id);
            if (rangeDistrict == null)
            {
                return HttpNotFound();
            }
            ViewBag.DistrictId = new SelectList(DataFilter.GetDistricts(TempData.Peek("Id") + ""), "Id", "Name", rangeDistrict.DistrictId);
            ViewBag.RangeId = new SelectList(DataFilter.GetRanges(TempData.Peek("Id") + ""), "Id", "Name", rangeDistrict.RangeId);
            return View(rangeDistrict);
        }

        // POST: RangeDistricts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RangeId,DistrictId")] RangeDistrict rangeDistrict)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rangeDistrict).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DistrictId = new SelectList(DataFilter.GetDistricts(TempData.Peek("Id") + ""), "Id", "Name", rangeDistrict.DistrictId);
            ViewBag.RangeId = new SelectList(DataFilter.GetRanges(TempData.Peek("Id") + ""), "Id", "Name", rangeDistrict.RangeId);
            return View(rangeDistrict);
        }

        // GET: RangeDistricts/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RangeDistrict rangeDistrict = db.RangeDistricts.Find(id);
            if (rangeDistrict == null)
            {
                return HttpNotFound();
            }
            return View(rangeDistrict);
        }

        // POST: RangeDistricts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            RangeDistrict rangeDistrict = db.RangeDistricts.Find(id);
            db.RangeDistricts.Remove(rangeDistrict);
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
