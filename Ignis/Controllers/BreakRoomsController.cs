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
    public class BreakRoomsController : Controller
    {
        private IgnisModel db = new IgnisModel();

        // GET: BreakRooms
        public ActionResult Index()
        {
            return View(DataFilter.GetBreakRooms(TempData.Peek("Id") + ""));
        }

        // GET: BreakRooms/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BreakRoom breakRoom = db.BreakRooms.Find(id);
            string basePath = Server.MapPath(Constants.BREAK_ROOM_UPLOAD_BASE_PATH + breakRoom.Id + "/");
            if (Directory.Exists(basePath))
            {
                TempData["Images"] = FileHelper.GetImages(breakRoom.Id + "", basePath);
            }
            if (breakRoom == null)
            {
                return HttpNotFound();
            }
            return View(breakRoom);
        }

        // GET: BreakRooms/Create
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

        // POST: BreakRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,FireStationId")] BreakRoom breakRoom, IEnumerable<HttpPostedFileBase> image)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in image)
                {
                    string error;
                    if (!FileHelper.CheckIfFileIsImage(item, out error))
                    {
                        ModelState.AddModelError("", error);
                        ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("Id") + ""), "Id", "Name", breakRoom.FireStationId);
                        return View(breakRoom);
                    }
                }

                breakRoom.Id = Guid.NewGuid();
                string basePath = Server.MapPath(Constants.BREAK_ROOM_UPLOAD_BASE_PATH + breakRoom.Id + "/");
                FileHelper.SaveFiles(image, basePath);

                db.BreakRooms.Add(breakRoom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("Id") + ""), "Id", "Name", breakRoom.FireStationId);
            return View(breakRoom);
        }

        // GET: BreakRooms/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BreakRoom breakRoom = db.BreakRooms.Find(id);
            if (breakRoom == null)
            {
                return HttpNotFound();
            }
            ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("Id") + ""), "Id", "Name", breakRoom.FireStationId);
            return View(breakRoom);
        }

        // POST: BreakRooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,FireStationId")] BreakRoom breakRoom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(breakRoom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("Id") + ""), "Id", "Name", breakRoom.FireStationId);
            return View(breakRoom);
        }

        // GET: BreakRooms/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BreakRoom breakRoom = db.BreakRooms.Find(id);
            if (breakRoom == null)
            {
                return HttpNotFound();
            }
            return View(breakRoom);
        }

        // POST: BreakRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            BreakRoom breakRoom = db.BreakRooms.Find(id);
            db.BreakRooms.Remove(breakRoom);
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
