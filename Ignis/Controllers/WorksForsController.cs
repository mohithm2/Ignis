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

namespace Ignis.Controllers
{
    [Authorize]
    public class WorksForsController : Controller
    {
        private IgnisModel db = new IgnisModel();

        // GET: WorksFors
        public ActionResult Index()
        {
            var worksFors = db.WorksFors.Include(w => w.Employee).Include(w => w.FireStation);
            return View(worksFors.ToList());
        }

        // GET: WorksFors/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorksFor worksFor = db.WorksFors.Find(id);
            if (worksFor == null)
            {
                return HttpNotFound();
            }
            return View(worksFor);
        }

        // GET: WorksFors/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name");
            ViewBag.FireStationId = new SelectList(db.FireStations, "Id", "Name");
            return View();
        }

        // POST: WorksFors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartDate,End,NoOfYears,EmployeeId,FireStationId")] WorksFor worksFor)
        {
            if (ModelState.IsValid)
            {
                worksFor.Id = Guid.NewGuid();
                db.WorksFors.Add(worksFor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", worksFor.EmployeeId);
            ViewBag.FireStationId = new SelectList(db.FireStations, "Id", "Name", worksFor.FireStationId);
            return View(worksFor);
        }

        // GET: WorksFors/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorksFor worksFor = db.WorksFors.Find(id);
            if (worksFor == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", worksFor.EmployeeId);
            ViewBag.FireStationId = new SelectList(db.FireStations, "Id", "Name", worksFor.FireStationId);
            return View(worksFor);
        }

        // POST: WorksFors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartDate,End,NoOfYears,EmployeeId,FireStationId")] WorksFor worksFor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(worksFor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", worksFor.EmployeeId);
            ViewBag.FireStationId = new SelectList(db.FireStations, "Id", "Name", worksFor.FireStationId);
            return View(worksFor);
        }

        // GET: WorksFors/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorksFor worksFor = db.WorksFors.Find(id);
            if (worksFor == null)
            {
                return HttpNotFound();
            }
            return View(worksFor);
        }

        // POST: WorksFors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            WorksFor worksFor = db.WorksFors.Find(id);
            db.WorksFors.Remove(worksFor);
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
