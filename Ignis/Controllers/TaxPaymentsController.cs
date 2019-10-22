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
    public class TaxPaymentsController : Controller
    {
        private IgnisModel db = new IgnisModel();

        // GET: TaxPayments
        public ActionResult Index()
        {
            return View(DataFilter.GetTaxPayments(TempData.Peek("Id")+""));
        }

        // GET: TaxPayments/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaxPayment taxPayment = db.TaxPayments.Find(id);
            if (taxPayment == null)
            {
                return HttpNotFound();
            }
            return View(taxPayment);
        }

        // GET: TaxPayments/Create
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

        // POST: TaxPayments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PaymentDate,AmountPaid,ExpiryDate,VehicleId")] TaxPayment taxPayment)
        {
            if (ModelState.IsValid)
            {
                taxPayment.Id = Guid.NewGuid();
                db.TaxPayments.Add(taxPayment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VehicleId = new SelectList(DataFilter.GetVehicles(TempData.Peek("Id") + ""), "Id", "RegistrationNumber", taxPayment.VehicleId);
            return View(taxPayment);
        }

        // GET: TaxPayments/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaxPayment taxPayment = db.TaxPayments.Find(id);
            if (taxPayment == null)
            {
                return HttpNotFound();
            }
            ViewBag.VehicleId = new SelectList(DataFilter.GetVehicles(TempData.Peek("Id") + ""), "Id", "RegistrationNumber", taxPayment.VehicleId);
            return View(taxPayment);
        }

        // POST: TaxPayments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PaymentDate,AmountPaid,ExpiryDate,VehicleId")] TaxPayment taxPayment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taxPayment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VehicleId = new SelectList(DataFilter.GetVehicles(TempData.Peek("Id") + ""), "Id", "RegistrationNumber", taxPayment.VehicleId);
            return View(taxPayment);
        }

        // GET: TaxPayments/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaxPayment taxPayment = db.TaxPayments.Find(id);
            if (taxPayment == null)
            {
                return HttpNotFound();
            }
            return View(taxPayment);
        }

        // POST: TaxPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            TaxPayment taxPayment = db.TaxPayments.Find(id);
            db.TaxPayments.Remove(taxPayment);
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
