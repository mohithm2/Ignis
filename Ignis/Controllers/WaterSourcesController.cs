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
    public class WaterSourcesController : Controller
    {
        private IgnisModel db = new IgnisModel();

        // GET: WaterSources
        public ActionResult Index()
        {
            return View(DataFilter.GetWaterSources(TempData.Peek("id")+""));
        }

        // GET: WaterSources/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WaterSource waterSource = db.WaterSources.Find(id);
            if (waterSource == null)
            {
                return HttpNotFound();
            }
            return View(waterSource);
        }

        // GET: WaterSources/Create
        public ActionResult Create(Guid? id)
        {
            if (id.HasValue)
            {
                ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("id") + ""), "Id", "Name", id.Value);
            }
            else
            {
                ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("id") + ""), "Id", "Name");
            }
            return View();
        }

        // POST: WaterSources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,IsOwned,Capacity,FireStationId")] WaterSource waterSource)
        {
            if (ModelState.IsValid)
            {
                waterSource.Id = Guid.NewGuid();
                db.WaterSources.Add(waterSource);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("id") + ""), "Id", "Name", waterSource.FireStationId);
            return View(waterSource);
        }

        // GET: WaterSources/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WaterSource waterSource = db.WaterSources.Find(id);
            if (waterSource == null)
            {
                return HttpNotFound();
            }
            ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("id") + ""), "Id", "Name", waterSource.FireStationId);
            return View(waterSource);
        }

        // POST: WaterSources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,IsOwned,Capacity,FireStationId")] WaterSource waterSource)
        {
            if (ModelState.IsValid)
            {
                db.Entry(waterSource).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("id") + ""), "Id", "Name", waterSource.FireStationId);
            return View(waterSource);
        }

        // GET: WaterSources/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WaterSource waterSource = db.WaterSources.Find(id);
            if (waterSource == null)
            {
                return HttpNotFound();
            }
            return View(waterSource);
        }

        // POST: WaterSources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            WaterSource waterSource = db.WaterSources.Find(id);
            db.WaterSources.Remove(waterSource);
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
