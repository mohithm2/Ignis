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
    public class ResidentialQuartersController : Controller
    {
        private IgnisModel db = new IgnisModel();

        // GET: ResidentialQuarters
        public ActionResult Index()
        {
            return View(DataFilter.GetResidentialQuarters(TempData.Peek("Id")+""));
        }

        // GET: ResidentialQuarters/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResidentialQuarter residentialQuarter = db.ResidentialQuarters.Find(id);
            if (residentialQuarter == null)
            {
                return HttpNotFound();
            }
            return View(residentialQuarter);
        }

        // GET: ResidentialQuarters/Create
        public ActionResult Create(Guid? id)
        {
            if (id.HasValue)
            {
                ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("Id") + ""), "Id", "Name", id.Value);
            }
            else
            {
                ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("Id") + ""), "Id", "Name");
            }
            return View();
        }

        // POST: ResidentialQuarters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,FireStationId")] ResidentialQuarter residentialQuarter)
        {
            if (ModelState.IsValid)
            {
                residentialQuarter.Id = Guid.NewGuid();
                db.ResidentialQuarters.Add(residentialQuarter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("Id") + ""), "Id", "Name", residentialQuarter.FireStationId);
            return View(residentialQuarter);
        }

        // GET: ResidentialQuarters/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResidentialQuarter residentialQuarter = db.ResidentialQuarters.Find(id);
            if (residentialQuarter == null)
            {
                return HttpNotFound();
            }
            ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("Id") + ""), "Id", "Name", residentialQuarter.FireStationId);
            return View(residentialQuarter);
        }

        // POST: ResidentialQuarters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,FireStationId")] ResidentialQuarter residentialQuarter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(residentialQuarter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("Id") + ""), "Id", "Name", residentialQuarter.FireStationId);
            return View(residentialQuarter);
        }

        // GET: ResidentialQuarters/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResidentialQuarter residentialQuarter = db.ResidentialQuarters.Find(id);
            if (residentialQuarter == null)
            {
                return HttpNotFound();
            }
            return View(residentialQuarter);
        }

        // POST: ResidentialQuarters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ResidentialQuarter residentialQuarter = db.ResidentialQuarters.Find(id);
            db.ResidentialQuarters.Remove(residentialQuarter);
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
