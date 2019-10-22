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
    public class FireExtinguishingEquipmentsController : Controller
    {
        private IgnisModel db = new IgnisModel();

        // GET: FireExtinguishingEquipments
        public ActionResult Index()
        {
            return View(DataFilter.GetFireExtingushingEquipments(TempData.Peek("Id")+""));
        }

        // GET: FireExtinguishingEquipments/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FireExtinguishingEquipment fireExtinguishingEquipment = db.FireExtinguishingEquipments.Find(id);
            if (fireExtinguishingEquipment == null)
            {
                return HttpNotFound();
            }

            string basePath = Server.MapPath(Constants.FIRE_EXTINGUISHING_EQUIPMENTS_UPLOAD_BASE_PATH + fireExtinguishingEquipment.Id + "/");
            if (Directory.Exists(basePath))
            {
                TempData["Images"] = FileHelper.GetImages(fireExtinguishingEquipment.Id + "", basePath);
            }

            return View(fireExtinguishingEquipment);
        }

        // GET: FireExtinguishingEquipments/Create
        public ActionResult Create()
        {
            ViewBag.FireExtinguishingEquipmentTypeId = new SelectList(db.FireExtinguishingEquipmentTypes, "Id", "Name");
            ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("Id") + ""), "Id", "Name");
            return View();
        }

        // POST: FireExtinguishingEquipments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateofPurchase,Status,Quantity,FireExtinguishingEquipmentTypeId,FireStationId")] FireExtinguishingEquipment fireExtinguishingEquipment,
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
                        ViewBag.FireExtinguishingEquipmentTypeId = new SelectList(db.FireExtinguishingEquipmentTypes, "Id", "Name", fireExtinguishingEquipment.FireExtinguishingEquipmentTypeId);
                        ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("Id") + ""), "Id", "Name", fireExtinguishingEquipment.FireStationId);
                        return View(fireExtinguishingEquipment);
                    }
                }

                fireExtinguishingEquipment.Id = Guid.NewGuid();

                string basePath = Server.MapPath(Constants.FIRE_EXTINGUISHING_EQUIPMENTS_UPLOAD_BASE_PATH + fireExtinguishingEquipment.Id + "/");
                FileHelper.SaveFiles(image, basePath);


                db.FireExtinguishingEquipments.Add(fireExtinguishingEquipment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FireExtinguishingEquipmentTypeId = new SelectList(db.FireExtinguishingEquipmentTypes, "Id", "Name", fireExtinguishingEquipment.FireExtinguishingEquipmentTypeId);
            ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("Id") + ""), "Id", "Name", fireExtinguishingEquipment.FireStationId);
            return View(fireExtinguishingEquipment);
        }

        // GET: FireExtinguishingEquipments/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FireExtinguishingEquipment fireExtinguishingEquipment = db.FireExtinguishingEquipments.Find(id);
            if (fireExtinguishingEquipment == null)
            {
                return HttpNotFound();
            }
            ViewBag.FireExtinguishingEquipmentTypeId = new SelectList(db.FireExtinguishingEquipmentTypes, "Id", "Name", fireExtinguishingEquipment.FireExtinguishingEquipmentTypeId);
            ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("Id") + ""), "Id", "Name", fireExtinguishingEquipment.FireStationId);
            return View(fireExtinguishingEquipment);
        }

        // POST: FireExtinguishingEquipments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateofPurchase,Status,Quantity,FireExtinguishingEquipmentTypeId,FireStationId")] FireExtinguishingEquipment fireExtinguishingEquipment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fireExtinguishingEquipment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FireExtinguishingEquipmentTypeId = new SelectList(db.FireExtinguishingEquipmentTypes, "Id", "Name", fireExtinguishingEquipment.FireExtinguishingEquipmentTypeId);
            ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("Id") + ""), "Id", "Name", fireExtinguishingEquipment.FireStationId);
            return View(fireExtinguishingEquipment);
        }

        // GET: FireExtinguishingEquipments/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FireExtinguishingEquipment fireExtinguishingEquipment = db.FireExtinguishingEquipments.Find(id);
            if (fireExtinguishingEquipment == null)
            {
                return HttpNotFound();
            }
            return View(fireExtinguishingEquipment);
        }

        // POST: FireExtinguishingEquipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            FireExtinguishingEquipment fireExtinguishingEquipment = db.FireExtinguishingEquipments.Find(id);
            db.FireExtinguishingEquipments.Remove(fireExtinguishingEquipment);
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
