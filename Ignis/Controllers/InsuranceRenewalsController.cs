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
    public class InsuranceRenewalsController : Controller
    {
        private IgnisModel db = new IgnisModel();

        // GET: InsuranceRenewals
        public ActionResult Index()
        {
            return View(DataFilter.GetInsuranceRenewals(TempData.Peek("Id")+""));
        }

        // GET: InsuranceRenewals/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsuranceRenewal insuranceRenewal = db.InsuranceRenewals.Find(id);
            if (insuranceRenewal == null)
            {
                return HttpNotFound();
            }
            return View(insuranceRenewal);
        }

        // GET: InsuranceRenewals/Create
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


        // POST: InsuranceRenewals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateOfPayment,AmountPaid,ExpiryDate,VehicleId")] InsuranceRenewal insuranceRenewal)
        {
            if (ModelState.IsValid)
            {
                insuranceRenewal.Id = Guid.NewGuid();
                db.InsuranceRenewals.Add(insuranceRenewal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VehicleId = new SelectList(DataFilter.GetVehicles(TempData.Peek("Id") + ""), "Id", "RegistrationNumber", insuranceRenewal.VehicleId);
            return View(insuranceRenewal);
        }

        // GET: InsuranceRenewals/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsuranceRenewal insuranceRenewal = db.InsuranceRenewals.Find(id);
            if (insuranceRenewal == null)
            {
                return HttpNotFound();
            }
            ViewBag.VehicleId = new SelectList(DataFilter.GetVehicles(TempData.Peek("Id") + ""), "Id", "RegistrationNumber", insuranceRenewal.VehicleId);
            return View(insuranceRenewal);
        }

        // POST: InsuranceRenewals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateOfPayment,AmountPaid,ExpiryDate,VehicleId")] InsuranceRenewal insuranceRenewal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insuranceRenewal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VehicleId = new SelectList(DataFilter.GetVehicles(TempData.Peek("Id") + ""), "Id", "RegistrationNumber", insuranceRenewal.VehicleId);
            return View(insuranceRenewal);
        }

        // GET: InsuranceRenewals/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsuranceRenewal insuranceRenewal = db.InsuranceRenewals.Find(id);
            if (insuranceRenewal == null)
            {
                return HttpNotFound();
            }
            return View(insuranceRenewal);
        }

        // POST: InsuranceRenewals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            InsuranceRenewal insuranceRenewal = db.InsuranceRenewals.Find(id);
            db.InsuranceRenewals.Remove(insuranceRenewal);
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
