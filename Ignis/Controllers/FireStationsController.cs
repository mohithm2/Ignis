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
    [Authorize]
    public class FireStationsController : Controller
    {
        private IgnisModel db = new IgnisModel();

        // GET: FireStations
        public ActionResult Index()
        {
            return View(DataFilter.GetFireStations(TempData.Peek("Id")+""));
        }

        // GET: FireStations/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FireStation fireStation = db.FireStations.Find(id);
            if (fireStation == null)
            {
                return HttpNotFound();
            }

            string basePath = Server.MapPath(Constants.FIRE_STATION_UPLOAD_BASE_PATH + fireStation.Id + "/");
            if (Directory.Exists(basePath))
            {
                TempData["Images"] = FileHelper.GetImages(fireStation.Id + "", basePath);
            }

            return View(fireStation);
        }

        // GET: FireStations/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(DataFilter.GetHoblis(TempData.Peek("Id") + ""), "Id", "Name");
            return View();
        }

        // POST: FireStations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,NumberOfBays,SanctionNumber,Address,Latitude,Longitude,PhoneNumber,LandArea,DateOfEstablishment,CostOfEstablishment,SanctionedStrength,Status")] FireStation fireStation,
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
                        ViewBag.Id = new SelectList(DataFilter.GetHoblis(TempData.Peek("Id") + ""), "Id", "Name", fireStation.Id);
                        return View(fireStation);
                    }
                }

                //fireStation.Id = Guid.NewGuid();

                string basePath = Server.MapPath(Constants.FIRE_STATION_UPLOAD_BASE_PATH + fireStation.Id + "/");
                FileHelper.SaveFiles(image, basePath);

                db.FireStations.Add(fireStation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(DataFilter.GetHoblis(TempData.Peek("Id") + ""), "Id", "Name", fireStation.Id);
            return View(fireStation);
        }

        // GET: FireStations/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FireStation fireStation = db.FireStations.Find(id);
            if (fireStation == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(DataFilter.GetHoblis(TempData.Peek("Id") + ""), "Id", "Name", fireStation.Id);
            return View(fireStation);
        }

        // POST: FireStations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,NumberOfBays,SanctionNumber,Address,Latitude,Longitude,PhoneNumber,LandArea,DateOfEstablishment,CostOfEstablishment,SanctionedStrength,Status")] FireStation fireStation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fireStation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(DataFilter.GetHoblis(TempData.Peek("Id") + ""), "Id", "Name", fireStation.Id);
            return View(fireStation);
        }

        // GET: FireStations/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FireStation fireStation = db.FireStations.Find(id);
            if (fireStation == null)
            {
                return HttpNotFound();
            }
            return View(fireStation);
        }

        // POST: FireStations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            FireStation fireStation = db.FireStations.Find(id);
            db.FireStations.Remove(fireStation);
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
