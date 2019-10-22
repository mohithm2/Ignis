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
    public class CountsController : Controller
    {
        private IgnisModel db = new IgnisModel();

        // GET: Counts
        public ActionResult Index()
        {
            var counts = db.Counts.Include(c => c.FireStation).Include(c => c.Rank);
            return View(counts.ToList());
        }

        // GET: Counts/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Count count = db.Counts.Find(id);
            if (count == null)
            {
                return HttpNotFound();
            }
            return View(count);
        }

        // GET: Counts/Create
        public ActionResult Create()
        {
            ViewBag.FireStationId = new SelectList(db.FireStations, "Id", "Name");
            ViewBag.RankId = new SelectList(db.Ranks, "Id", "RankName");
            return View();
        }

        // POST: Counts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Sanctioned,Alloted,RankId,FireStationId")] Count count)
        {
            if (ModelState.IsValid)
            {
                count.Id = Guid.NewGuid();
                db.Counts.Add(count);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FireStationId = new SelectList(db.FireStations, "Id", "Name", count.FireStationId);
            ViewBag.RankId = new SelectList(db.Ranks, "Id", "RankName", count.RankId);
            return View(count);
        }

        // GET: Counts/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Count count = db.Counts.Find(id);
            if (count == null)
            {
                return HttpNotFound();
            }
            ViewBag.FireStationId = new SelectList(db.FireStations, "Id", "Name", count.FireStationId);
            ViewBag.RankId = new SelectList(db.Ranks, "Id", "RankName", count.RankId);
            return View(count);
        }

        // POST: Counts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Sanctioned,Alloted,RankId,FireStationId")] Count count)
        {
            if (ModelState.IsValid)
            {
                db.Entry(count).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FireStationId = new SelectList(db.FireStations, "Id", "Name", count.FireStationId);
            ViewBag.RankId = new SelectList(db.Ranks, "Id", "RankName", count.RankId);
            return View(count);
        }

        // GET: Counts/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Count count = db.Counts.Find(id);
            if (count == null)
            {
                return HttpNotFound();
            }
            return View(count);
        }

        // POST: Counts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Count count = db.Counts.Find(id);
            db.Counts.Remove(count);
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
