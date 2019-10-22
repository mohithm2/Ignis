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
    public class RequiredLandsController : Controller
    {
        private IgnisModel db = new IgnisModel();

        // GET: RequiredLands
        public ActionResult Index()
        {
            return View(DataFilter.GetRequiredLands(TempData.Peek("Id") + ""));
        }

        // GET: RequiredLands/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequiredLand requiredLand = db.RequiredLands.Find(id);
            if (requiredLand == null)
            {
                return HttpNotFound();
            }
            return View(requiredLand);
        }

        // GET: RequiredLands/Create
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

        // POST: RequiredLands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Address,Reason,PotentialCost,AreaRequired,FireStationId")] RequiredLand requiredLand)
        {
            if (ModelState.IsValid)
            {
                requiredLand.Id = Guid.NewGuid();
                db.RequiredLands.Add(requiredLand);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("Id") + ""), "Id", "Name", requiredLand.FireStationId);
            return View(requiredLand);
        }

        // GET: RequiredLands/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequiredLand requiredLand = db.RequiredLands.Find(id);
            if (requiredLand == null)
            {
                return HttpNotFound();
            }
            ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("Id") + ""), "Id", "Name", requiredLand.FireStationId);
            return View(requiredLand);
        }

        // POST: RequiredLands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Address,Reason,PotentialCost,AreaRequired,FireStationId")] RequiredLand requiredLand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requiredLand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("Id") + ""), "Id", "Name", requiredLand.FireStationId);
            return View(requiredLand);
        }

        // GET: RequiredLands/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequiredLand requiredLand = db.RequiredLands.Find(id);
            if (requiredLand == null)
            {
                return HttpNotFound();
            }
            return View(requiredLand);
        }

        // POST: RequiredLands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            RequiredLand requiredLand = db.RequiredLands.Find(id);
            db.RequiredLands.Remove(requiredLand);
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
