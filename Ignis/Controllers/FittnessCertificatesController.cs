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
    public class FittnessCertificatesController : Controller
    {
        private IgnisModel db = new IgnisModel();

        // GET: FittnessCertificates
        public ActionResult Index()
        {
            return View(DataFilter.GetFittnessCertificates(TempData.Peek("Id")+""));
        }

        // GET: FittnessCertificates/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FittnessCertificate fittnessCertificate = db.FittnessCertificates.Find(id);
            if (fittnessCertificate == null)
            {
                return HttpNotFound();
            }
            return View(fittnessCertificate);
        }

        // GET: FittnessCertificates/Create
        public ActionResult Create(Guid? id)
        {
            if (id.HasValue)
            {
                ViewBag.VehicleId = new SelectList(DataFilter.GetVehicles(TempData.Peek("Id") + ""), "Id", "RegistrationNumber", id.Value);
            }
            else
            {
                ViewBag.VehicleId = new SelectList(DataFilter.GetVehicles(TempData.Peek("Id") + ""), "Id", "RegistrationNumber");
            }
            return View();
        }

        // POST: FittnessCertificates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IssueDate,Comment,VehicleId")] FittnessCertificate fittnessCertificate)
        {
            if (ModelState.IsValid)
            {
                fittnessCertificate.Id = Guid.NewGuid();
                db.FittnessCertificates.Add(fittnessCertificate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VehicleId = new SelectList(DataFilter.GetVehicles(TempData.Peek("Id") + ""), "Id", "RegistrationNumber", fittnessCertificate.VehicleId);
            return View(fittnessCertificate);
        }

        // GET: FittnessCertificates/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FittnessCertificate fittnessCertificate = db.FittnessCertificates.Find(id);
            if (fittnessCertificate == null)
            {
                return HttpNotFound();
            }
            ViewBag.VehicleId = new SelectList(DataFilter.GetVehicles(TempData.Peek("Id") + ""), "Id", "RegistrationNumber", fittnessCertificate.VehicleId);
            return View(fittnessCertificate);
        }

        // POST: FittnessCertificates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IssueDate,Comment,VehicleId")] FittnessCertificate fittnessCertificate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fittnessCertificate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VehicleId = new SelectList(DataFilter.GetVehicles(TempData.Peek("Id") + ""), "Id", "RegistrationNumber", fittnessCertificate.VehicleId);
            return View(fittnessCertificate);
        }

        // GET: FittnessCertificates/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FittnessCertificate fittnessCertificate = db.FittnessCertificates.Find(id);
            if (fittnessCertificate == null)
            {
                return HttpNotFound();
            }
            return View(fittnessCertificate);
        }

        // POST: FittnessCertificates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            FittnessCertificate fittnessCertificate = db.FittnessCertificates.Find(id);
            db.FittnessCertificates.Remove(fittnessCertificate);
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
