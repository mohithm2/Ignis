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
    public class HoblisController : Controller
    {
        private IgnisModel db = new IgnisModel();

        // GET: Hoblis
        public ActionResult Index()
        {
            return View(DataFilter.GetHoblis(TempData.Peek("Id")+ ""));
        }

        // GET: Hoblis/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hobli hobli = db.Hoblis.Find(id);
            if (hobli == null)
            {
                return HttpNotFound();
            }
            return View(hobli);
        }

        // GET: Hoblis/Create
        public ActionResult Create()
        {
            ViewBag.TalukId = new SelectList(DataFilter.GetTaluks(TempData.Peek("Id") + ""), "Id", "Name");
            return View();
        }

        // POST: Hoblis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,TalukId")] Hobli hobli)
        {
            if (ModelState.IsValid)
            {
                hobli.Id = Guid.NewGuid();
                db.Hoblis.Add(hobli);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TalukId = new SelectList(DataFilter.GetTaluks(TempData.Peek("Id") + ""), "Id", "Name", hobli.TalukId);
            return View(hobli);
        }

        // GET: Hoblis/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hobli hobli = db.Hoblis.Find(id);
            if (hobli == null)
            {
                return HttpNotFound();
            }
            ViewBag.TalukId = new SelectList(DataFilter.GetTaluks(TempData.Peek("Id") + ""), "Id", "Name", hobli.TalukId);
            return View(hobli);
        }

        // POST: Hoblis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,TalukId")] Hobli hobli)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hobli).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TalukId = new SelectList(DataFilter.GetTaluks(TempData.Peek("Id") + ""), "Id", "Name", hobli.TalukId);
            return View(hobli);
        }

        // GET: Hoblis/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hobli hobli = db.Hoblis.Find(id);
            if (hobli == null)
            {
                return HttpNotFound();
            }
            return View(hobli);
        }

        // POST: Hoblis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Hobli hobli = db.Hoblis.Find(id);
            db.Hoblis.Remove(hobli);
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
