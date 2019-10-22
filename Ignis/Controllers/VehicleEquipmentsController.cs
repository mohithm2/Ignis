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
    public class VehicleEquipmentsController : Controller
    {
        private IgnisModel db = new IgnisModel();

        // GET: VehicleEquipments
        public ActionResult Index()
        {
            return View(DataFilter.GetVehicleEquipments(TempData.Peek("Id")+""));
        }

        // GET: VehicleEquipments/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleEquipment vehicleEquipment = db.VehicleEquipments.Find(id);
            if (vehicleEquipment == null)
            {
                return HttpNotFound();
            }

            string basePath = Server.MapPath(Constants.VEHICLE_EQUIPMENTS_UPLOAD_BASE_PATH + vehicleEquipment.Id + "/");
            if (Directory.Exists(basePath))
            {
                TempData["Images"] = FileHelper.GetImages(vehicleEquipment.Id + "", basePath);
            }

            return View(vehicleEquipment);
        }

        // GET: VehicleEquipments/Create
        public ActionResult Create()
        {
            ViewBag.VehicleId = new SelectList(DataFilter.GetVehicles(TempData.Peek("Id") + ""), "Id", "Name");
            ViewBag.VehicleEquipmentTypeId = new SelectList(db.VehicleEquipmentTypes, "Id", "Name");
            return View();
        }

        // POST: VehicleEquipments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateofPurchase,Status,Quantity,VehicleId,VehicleEquipmentTypeId")] VehicleEquipment vehicleEquipment,
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
                        ViewBag.VehicleId = new SelectList(DataFilter.GetVehicles(TempData.Peek("Id") + ""), "Id", "Name", vehicleEquipment.VehicleId);
                        ViewBag.VehicleEquipmentTypeId = new SelectList(db.VehicleEquipmentTypes, "Id", "Name", vehicleEquipment.VehicleEquipmentTypeId);
                        return View(vehicleEquipment);
                    }
                }

                vehicleEquipment.Id = Guid.NewGuid();

                string basePath = Server.MapPath(Constants.VEHICLE_EQUIPMENTS_UPLOAD_BASE_PATH + vehicleEquipment.Id + "/");
                FileHelper.SaveFiles(image, basePath);

                db.VehicleEquipments.Add(vehicleEquipment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VehicleId = new SelectList(DataFilter.GetVehicles(TempData.Peek("Id") + ""), "Id", "Name", vehicleEquipment.VehicleId);
            ViewBag.VehicleEquipmentTypeId = new SelectList(db.VehicleEquipmentTypes, "Id", "Name", vehicleEquipment.VehicleEquipmentTypeId);
            return View(vehicleEquipment);
        }

        // GET: VehicleEquipments/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleEquipment vehicleEquipment = db.VehicleEquipments.Find(id);
            if (vehicleEquipment == null)
            {
                return HttpNotFound();
            }
            ViewBag.VehicleId = new SelectList(DataFilter.GetVehicles(TempData.Peek("Id") + ""), "Id", "Name", vehicleEquipment.VehicleId);
            ViewBag.VehicleEquipmentTypeId = new SelectList(db.VehicleEquipmentTypes, "Id", "Name", vehicleEquipment.VehicleEquipmentTypeId);
            return View(vehicleEquipment);
        }

        // POST: VehicleEquipments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateofPurchase,Status,Quantity,VehicleId,VehicleEquipmentTypeId")] VehicleEquipment vehicleEquipment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicleEquipment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VehicleId = new SelectList(DataFilter.GetVehicles(TempData.Peek("Id") + ""), "Id", "Name", vehicleEquipment.VehicleId);
            ViewBag.VehicleEquipmentTypeId = new SelectList(db.VehicleEquipmentTypes, "Id", "Name", vehicleEquipment.VehicleEquipmentTypeId);
            return View(vehicleEquipment);
        }

        // GET: VehicleEquipments/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleEquipment vehicleEquipment = db.VehicleEquipments.Find(id);
            if (vehicleEquipment == null)
            {
                return HttpNotFound();
            }
            return View(vehicleEquipment);
        }

        // POST: VehicleEquipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            VehicleEquipment vehicleEquipment = db.VehicleEquipments.Find(id);
            db.VehicleEquipments.Remove(vehicleEquipment);
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
