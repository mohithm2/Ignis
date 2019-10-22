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
    public class TelephoneRoomsController : Controller
    {
        private IgnisModel db = new IgnisModel();

        // GET: TelephoneRooms
        public ActionResult Index()
        {            
            return View(DataFilter.GetTelephoneRooms(TempData.Peek("Id")+""));
        }

        // GET: TelephoneRooms/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TelephoneRoom telephoneRoom = db.TelephoneRooms.Find(id);
            string basePath = Server.MapPath(Constants.TELEPHONE_ROOM_UPLOAD_BASE_PATH + telephoneRoom.Id + "/");
            if (Directory.Exists(basePath))
            {
                TempData["Images"] = FileHelper.GetImages(telephoneRoom.Id + "", basePath);
            }
            if (telephoneRoom == null)
            {
                return HttpNotFound();
            }
            return View(telephoneRoom);
        }

        // GET: TelephoneRooms/Create
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

        // POST: TelephoneRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,FireStationId")] TelephoneRoom telephoneRoom, IEnumerable<HttpPostedFileBase> image)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in image)
                {
                    string error;
                    if (!FileHelper.CheckIfFileIsImage(item, out error))
                    {
                        ModelState.AddModelError("", error);
                        ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("Id") + ""), "Id", "Name", telephoneRoom.FireStationId);
                        return View(telephoneRoom);
                    }
                }

                telephoneRoom.Id = Guid.NewGuid();
                string basePath = Server.MapPath(Constants.TELEPHONE_ROOM_UPLOAD_BASE_PATH + telephoneRoom.Id + "/");
                FileHelper.SaveFiles(image, basePath);

                db.TelephoneRooms.Add(telephoneRoom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("Id") + ""), "Id", "Name", telephoneRoom.FireStationId);
            return View(telephoneRoom);
        }

        // GET: TelephoneRooms/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TelephoneRoom telephoneRoom = db.TelephoneRooms.Find(id);
            if (telephoneRoom == null)
            {
                return HttpNotFound();
            }
            ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("Id") + ""), "Id", "Name", telephoneRoom.FireStationId);
            return View(telephoneRoom);
        }

        // POST: TelephoneRooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,FireStationId")] TelephoneRoom telephoneRoom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telephoneRoom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("Id") + ""), "Id", "Name", telephoneRoom.FireStationId);
            return View(telephoneRoom);
        }

        // GET: TelephoneRooms/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TelephoneRoom telephoneRoom = db.TelephoneRooms.Find(id);
            if (telephoneRoom == null)
            {
                return HttpNotFound();
            }
            return View(telephoneRoom);
        }

        // POST: TelephoneRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            TelephoneRoom telephoneRoom = db.TelephoneRooms.Find(id);
            db.TelephoneRooms.Remove(telephoneRoom);
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
