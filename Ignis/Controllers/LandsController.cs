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
using System.IO;

namespace Ignis.Controllers
{
    public class LandsController : Controller
    {
        private IgnisModel db = new IgnisModel();

        // GET: Lands
        public ActionResult Index()
        {
            return View(DataFilter.GetLands(TempData.Peek("Id")+""));
        }

        // GET: Lands/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Land land = db.Lands.Find(id);
            if (land == null)
            {
                return HttpNotFound();
            }

            string basePath = Server.MapPath(Constants.LANDS_UPLOAD_BASE_PATH + land.Id + "/");
            if (Directory.Exists(basePath))
            {
                TempData["Images"] = FileHelper.GetImages(land.Id + "", basePath);
            }

            return View(land);
        }

        // GET: Lands/Create
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

        // POST: Lands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Address,Area,DateOfPurchase,Cost,GovernmentSactionNumber,IsEncroached,FireStationId")] Land land,
            IEnumerable<HttpPostedFileBase> image)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in image)
                {
                    string error;
                    if (!FileHelper.CheckIfFileIsImage(item, out error))
                    {
                        ModelState.AddModelError("", error);
                        ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("Id") + ""), "Id", "Name", land.FireStationId);
                        return View(land);
                    }
                }

                land.Id = Guid.NewGuid();

                string basePath = Server.MapPath(Constants.LANDS_UPLOAD_BASE_PATH + land.Id + "/");
                FileHelper.SaveFiles(image, basePath);

                db.Lands.Add(land);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("Id") + ""), "Id", "Name", land.FireStationId);
            return View(land);
        }

        // GET: Lands/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Land land = db.Lands.Find(id);
            if (land == null)
            {
                return HttpNotFound();
            }
            ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("Id") + ""), "Id", "Name", land.FireStationId);
            return View(land);
        }

        // POST: Lands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Address,Area,DateOfPurchase,Cost,GovernmentSactionNumber,IsEncroached,FireStationId")] Land land)
        {
            if (ModelState.IsValid)
            {
                db.Entry(land).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("Id") + ""), "Id", "Name", land.FireStationId);
            return View(land);
        }

        // GET: Lands/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Land land = db.Lands.Find(id);
            if (land == null)
            {
                return HttpNotFound();
            }
            return View(land);
        }

        // POST: Lands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Land land = db.Lands.Find(id);
            db.Lands.Remove(land);
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
