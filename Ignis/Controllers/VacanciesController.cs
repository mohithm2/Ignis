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
    public class VacanciesController : Controller
    {
        private IgnisModel db = new IgnisModel();

        // GET: Vacancies
        public ActionResult Index()
        {
            var vacancies = db.Vacancies.Include(v => v.FireStation).Include(v => v.Rank);
            return View(vacancies.ToList());
        }

        // GET: Vacancies/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacancy vacancy = db.Vacancies.Find(id);
            if (vacancy == null)
            {
                return HttpNotFound();
            }
            return View(vacancy);
        }

        // GET: Vacancies/Create
        public ActionResult Create()
        {
            ViewBag.FireStationId = new SelectList(db.FireStations, "Id", "Name");
            ViewBag.RankId = new SelectList(db.Ranks, "Id", "RankName");
            return View();
        }

        // POST: Vacancies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Vacant,RankId,FireStationId")] Vacancy vacancy)
        {
            if (ModelState.IsValid)
            {
                vacancy.Id = Guid.NewGuid();
                db.Vacancies.Add(vacancy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FireStationId = new SelectList(db.FireStations, "Id", "Name", vacancy.FireStationId);
            ViewBag.RankId = new SelectList(db.Ranks, "Id", "RankName", vacancy.RankId);
            return View(vacancy);
        }

        // GET: Vacancies/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacancy vacancy = db.Vacancies.Find(id);
            if (vacancy == null)
            {
                return HttpNotFound();
            }
            ViewBag.FireStationId = new SelectList(db.FireStations, "Id", "Name", vacancy.FireStationId);
            ViewBag.RankId = new SelectList(db.Ranks, "Id", "RankName", vacancy.RankId);
            return View(vacancy);
        }

        // POST: Vacancies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Vacant,RankId,FireStationId")] Vacancy vacancy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacancy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FireStationId = new SelectList(db.FireStations, "Id", "Name", vacancy.FireStationId);
            ViewBag.RankId = new SelectList(db.Ranks, "Id", "RankName", vacancy.RankId);
            return View(vacancy);
        }

        // GET: Vacancies/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacancy vacancy = db.Vacancies.Find(id);
            if (vacancy == null)
            {
                return HttpNotFound();
            }
            return View(vacancy);
        }

        // POST: Vacancies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Vacancy vacancy = db.Vacancies.Find(id);
            db.Vacancies.Remove(vacancy);
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
