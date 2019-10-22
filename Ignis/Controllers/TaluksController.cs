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
    public class TaluksController : Controller
    {
        private IgnisModel db = new IgnisModel();

        // GET: Taluks
        public ActionResult Index()
        {
            return View(DataFilter.GetTaluks(TempData.Peek("Id") + ""));
        }

        // GET: Taluks/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Taluk taluk = db.Taluks.Find(id);
            if (taluk == null)
            {
                return HttpNotFound();
            }
            return View(taluk);
        }

        // GET: Taluks/Create
        public ActionResult Create()
        {
            ViewBag.DistrictId = new SelectList(DataFilter.GetDistricts(TempData.Peek("Id") + ""), "Id", "Name");
            return View();
        }

        // POST: Taluks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,DistrictId")] Taluk taluk)
        {
            if (ModelState.IsValid)
            {
                taluk.Id = Guid.NewGuid();
                db.Taluks.Add(taluk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DistrictId = new SelectList(DataFilter.GetDistricts(TempData.Peek("Id") + ""), "Id", "Name", taluk.DistrictId);
            return View(taluk);
        }

        // GET: Taluks/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Taluk taluk = db.Taluks.Find(id);
            if (taluk == null)
            {
                return HttpNotFound();
            }
            ViewBag.DistrictId = new SelectList(DataFilter.GetDistricts(TempData.Peek("Id") + ""), "Id", "Name", taluk.DistrictId);
            return View(taluk);
        }

        // POST: Taluks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,DistrictId")] Taluk taluk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taluk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DistrictId = new SelectList(DataFilter.GetDistricts(TempData.Peek("Id") + ""), "Id", "Name", taluk.DistrictId);
            return View(taluk);
        }

        // GET: Taluks/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Taluk taluk = db.Taluks.Find(id);
            if (taluk == null)
            {
                return HttpNotFound();
            }
            return View(taluk);
        }

        // POST: Taluks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Taluk taluk = db.Taluks.Find(id);
            db.Taluks.Remove(taluk);
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
