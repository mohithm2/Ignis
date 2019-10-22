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
    public class HousesController : Controller
    {
        private IgnisModel db = new IgnisModel();

        // GET: Houses
        public ActionResult Index()
        {
            return View(DataFilter.GetHouses(TempData.Peek("Id")+""));
        }

        // GET: Houses/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = db.Houses.Find(id);
            string basePath = Server.MapPath(Constants.HOUSE_UPLOAD_BASE_PATH + house.Id + "/");
            if (Directory.Exists(basePath))
            {
                TempData["Images"] = FileHelper.GetImages(house.Id + "", basePath);
            }
            if (house == null)
            {
                return HttpNotFound();
            }
            return View(house);
        }

        // GET: Houses/Create
        public ActionResult Create(Guid? id)
        {
            if (id.HasValue)
            {
                ViewBag.ResidentialQuarterId = new SelectList(DataFilter.GetResidentialQuarters(TempData.Peek("Id") + ""), "Id", "Name", id.Value);
            }
            else
            {
                ViewBag.ResidentialQuarterId = new SelectList(DataFilter.GetResidentialQuarters(TempData.Peek("Id") + ""), "Id", "Name");
            }
            return View();
        }

        // POST: Houses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Number,NumberOfBedrooms,OccupantDesignation,Status,ResidentialQuarterId")] House house, IEnumerable<HttpPostedFileBase> image)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in image)
                {
                    string error;
                    if (!FileHelper.CheckIfFileIsImage(item, out error))
                    {
                        ModelState.AddModelError("", error);
                        ViewBag.ResidentialQuarterId = new SelectList(DataFilter.GetResidentialQuarters(TempData.Peek("Id") + ""), "Id", "Name", house.ResidentialQuarterId);
                        return View(house);
                    }
                }

                house.Id = Guid.NewGuid();
                house.ResidentialQuarter = db.ResidentialQuarters.Find(house.ResidentialQuarterId);
                string basePath = Server.MapPath(Constants.HOUSE_UPLOAD_BASE_PATH + house.Id + "/");
                FileHelper.SaveFiles(image, basePath);
                db.Houses.Add(house);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ResidentialQuarterId = new SelectList(DataFilter.GetResidentialQuarters(TempData.Peek("Id") + ""), "Id", "Name", house.ResidentialQuarterId);
            return View(house);
        }

        // GET: Houses/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = db.Houses.Find(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            ViewBag.ResidentialQuarterId = new SelectList(DataFilter.GetResidentialQuarters(TempData.Peek("Id") + ""), "Id", "Name", house.ResidentialQuarterId);
            return View(house);
        }

        // POST: Houses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Number,NumberOfBedrooms,OccupantDesignation,Status,ResidentialQuarterId")] House house)
        {
            if (ModelState.IsValid)
            {
                db.Entry(house).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ResidentialQuarterId = new SelectList(DataFilter.GetResidentialQuarters(TempData.Peek("Id") + ""), "Id", "Name", house.ResidentialQuarterId);
            return View(house);
        }

        // GET: Houses/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = db.Houses.Find(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            return View(house);
        }

        // POST: Houses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            House house = db.Houses.Find(id);
            db.Houses.Remove(house);
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
