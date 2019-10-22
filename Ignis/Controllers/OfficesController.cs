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
    public class OfficesController : Controller
    {
        private IgnisModel db = new IgnisModel();

        // GET: Offices
        public ActionResult Index()
        {
            return View(DataFilter.GetOffices(TempData.Peek("Id") + ""));
        }

        // GET: Offices/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Office office = db.Offices.Find(id);
            string basePath = Server.MapPath(Constants.OFFICE_UPLOAD_BASE_PATH + office.Id + "/");
            if (Directory.Exists(basePath))
            {
                TempData["Images"] = FileHelper.GetImages(office.Id + "", basePath);
            }
            if (office == null)
            {
                return HttpNotFound();
            }
            return View(office);
        }

        // GET: Offices/Create
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

        // POST: Offices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,FireStationId")] Office office, IEnumerable<HttpPostedFileBase> image)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in image)
                {
                    string error;
                    if (!FileHelper.CheckIfFileIsImage(item, out error))
                    {
                        ModelState.AddModelError("", error);
                        ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("Id") + ""), "Id", "Name", office.FireStationId);
                        return View(office);
                    }
                }

                office.Id = Guid.NewGuid();
                string basePath = Server.MapPath(Constants.OFFICE_UPLOAD_BASE_PATH + office.Id + "/");
                FileHelper.SaveFiles(image, basePath);

                db.Offices.Add(office);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("Id") + ""), "Id", "Name", office.FireStationId);
            return View(office);
        }

        // GET: Offices/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Office office = db.Offices.Find(id);
            if (office == null)
            {
                return HttpNotFound();
            }
            ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("Id") + ""), "Id", "Name", office.FireStationId);
            return View(office);
        }

        // POST: Offices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,FireStationId")] Office office)
        {
            if (ModelState.IsValid)
            {
                db.Entry(office).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("Id") + ""), "Id", "Name", office.FireStationId);
            return View(office);
        }

        // GET: Offices/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Office office = db.Offices.Find(id);
            if (office == null)
            {
                return HttpNotFound();
            }
            return View(office);
        }

        // POST: Offices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Office office = db.Offices.Find(id);
            db.Offices.Remove(office);
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
