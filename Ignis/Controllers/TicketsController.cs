using Ignis.DAL;
using Ignis.Models;
using Ignis.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ignis.Controllers
{
    public class TicketsController : Controller
    {
        private IgnisModel db = new IgnisModel();

        public ActionResult SelectTicketType()
        {
            return View();
        }




        public ActionResult OpenTicketForTelephoneRoom()
        {
            ViewBag.TelephoneRoomId = new SelectList(DataFilter.GetTelephoneRooms(TempData.Peek("Id") + ""), "Id", "Name");
            ViewBag.TelephoneRoomDamageTypeId = new SelectList(db.BuildingDamageTypes, "Id", "Description");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OpenTicketForTelephoneRoom(TelephoneRoomDamage vehicleDamage,
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
                        ViewBag.TelephoneRoomId = new SelectList(DataFilter.GetTelephoneRooms(TempData.Peek("Id") + ""), "Id", "Name");
                        ViewBag.TelephoneRoomDamageTypeId = new SelectList(db.BuildingDamageTypes, "Id", "Description");
                        return View(vehicleDamage);
                    }
                }

                vehicleDamage.Id = Guid.NewGuid();

                string basePath = Server.MapPath(Constants.TELEPHONE_ROOM_DAMAGE_UPLOAD_BASE_PATH + vehicleDamage.Id + "/");
                FileHelper.SaveFiles(image, basePath);

                db.Damages.Add(vehicleDamage);
                db.SaveChanges();

                TelephoneRoomDamageStatus status = new TelephoneRoomDamageStatus
                {
                    DateOfArrival = DateTime.Now,
                    Id = Guid.NewGuid(),
                    TelephoneRoomDamageId = vehicleDamage.Id,
                    Official = ChainOfCommandHelper.GetCurrentOfficial(),
                    Action = DamageAction.Raised
                };
                status.CaseId = vehicleDamage.Id;
                db.DamageStatuses.Add(status);
                db.SaveChanges();

                status = new TelephoneRoomDamageStatus
                {
                    DateOfArrival = DateTime.Now,
                    Id = Guid.NewGuid(),
                    TelephoneRoomDamageId = vehicleDamage.Id,
                    Official = ChainOfCommandHelper.GetHigherOfficial()
                };
                status.CaseId = vehicleDamage.Id;
                db.DamageStatuses.Add(status);
                db.SaveChanges();

                return RedirectToAction("ViewOpenTickets");
            }

            ViewBag.TelephoneRoomId = new SelectList(DataFilter.GetTelephoneRooms(TempData.Peek("Id") + ""), "Id", "Name");
            ViewBag.TelephoneRoomDamageTypeId = new SelectList(db.BuildingDamageTypes, "Id", "Description");
            return View(vehicleDamage);
        }

        public ActionResult OpenTicketForOffice()
        {
            ViewBag.OfficeId = new SelectList(DataFilter.GetOffices(TempData.Peek("Id") + ""), "Id", "Name");
            ViewBag.OfficeDamageTypeId = new SelectList(db.BuildingDamageTypes, "Id", "Description");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OpenTicketForOffice(OfficeDamage vehicleDamage,
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
                        ViewBag.OfficeId = new SelectList(DataFilter.GetOffices(TempData.Peek("Id") + ""), "Id", "Name");
                        ViewBag.OfficeDamageTypeId = new SelectList(db.BuildingDamageTypes, "Id", "Description");
                        return View(vehicleDamage);
                    }
                }

                vehicleDamage.Id = Guid.NewGuid();

                string basePath = Server.MapPath(Constants.OFFICE_DAMAGE_UPLOAD_BASE_PATH + vehicleDamage.Id + "/");
                FileHelper.SaveFiles(image, basePath);

                db.Damages.Add(vehicleDamage);
                db.SaveChanges();

                OfficeDamageStatus status = new OfficeDamageStatus
                {
                    DateOfArrival = DateTime.Now,
                    Id = Guid.NewGuid(),
                    OfficeDamageId = vehicleDamage.Id,
                    Official = ChainOfCommandHelper.GetCurrentOfficial(),
                    Action = DamageAction.Raised
                };
                status.CaseId = vehicleDamage.Id;
                db.DamageStatuses.Add(status);
                db.SaveChanges();

                status = new OfficeDamageStatus
                {
                    DateOfArrival = DateTime.Now,
                    Id = Guid.NewGuid(),
                    OfficeDamageId = vehicleDamage.Id,
                    Official = ChainOfCommandHelper.GetHigherOfficial()
                };
                status.CaseId = vehicleDamage.Id;
                db.DamageStatuses.Add(status);
                db.SaveChanges();

                return RedirectToAction("ViewOpenTickets");
            }

            ViewBag.OfficeId = new SelectList(DataFilter.GetOffices(TempData.Peek("Id") + ""), "Id", "Name");
            ViewBag.OfficeDamageTypeId = new SelectList(db.BuildingDamageTypes, "Id", "Description");
            return View(vehicleDamage);
        }

        public ActionResult OpenTicketForHouse()
        {
            ViewBag.HouseId = new SelectList(DataFilter.GetHouses(TempData.Peek("Id") + ""), "Id", "Number");
            ViewBag.HouseDamageTypeId = new SelectList(db.BuildingDamageTypes, "Id", "Description");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OpenTicketForHouse(HouseDamage vehicleDamage,
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
                        ViewBag.HouseId = new SelectList(DataFilter.GetHouses(TempData.Peek("Id") + ""), "Id", "Number");
                        ViewBag.HouseDamageTypeId = new SelectList(db.BuildingDamageTypes, "Id", "Description");
                        return View(vehicleDamage);
                    }
                }

                vehicleDamage.Id = Guid.NewGuid();

                string basePath = Server.MapPath(Constants.HOUSE_DAMAGE_UPLOAD_BASE_PATH + vehicleDamage.Id + "/");
                FileHelper.SaveFiles(image, basePath);

                db.Damages.Add(vehicleDamage);
                db.SaveChanges();

                HouseDamageStatus status = new HouseDamageStatus
                {
                    DateOfArrival = DateTime.Now,
                    Id = Guid.NewGuid(),
                    HouseDamageId = vehicleDamage.Id,
                    Official = ChainOfCommandHelper.GetCurrentOfficial(),
                    Action = DamageAction.Raised
                };
                status.CaseId = vehicleDamage.Id;
                db.DamageStatuses.Add(status);
                db.SaveChanges();

                status = new HouseDamageStatus
                {
                    DateOfArrival = DateTime.Now,
                    Id = Guid.NewGuid(),
                    HouseDamageId = vehicleDamage.Id,
                    Official = ChainOfCommandHelper.GetHigherOfficial()
                };
                status.CaseId = vehicleDamage.Id;
                db.DamageStatuses.Add(status);
                db.SaveChanges();

                return RedirectToAction("ViewOpenTickets");
            }

            ViewBag.HouseId = new SelectList(DataFilter.GetHouses(TempData.Peek("Id") + ""), "Id", "Number");
            ViewBag.HouseDamageTypeId = new SelectList(db.BuildingDamageTypes, "Id", "Description");
            return View(vehicleDamage);
        }

        public ActionResult OpenTicketForFireStation()
        {
            ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("Id") + ""), "Id", "Name");
            ViewBag.FireStationDamageTypeId = new SelectList(db.BuildingDamageTypes, "Id", "Description");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OpenTicketForFireStation(FireStationDamage vehicleDamage,
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
                        ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("Id") + ""), "Id", "Name");
                        ViewBag.FireStationDamageTypeId = new SelectList(db.BuildingDamageTypes, "Id", "Description");
                        return View(vehicleDamage);
                    }
                }

                vehicleDamage.Id = Guid.NewGuid();

                string basePath = Server.MapPath(Constants.FIRE_STATION_DAMAGE_UPLOAD_BASE_PATH + vehicleDamage.Id + "/");
                FileHelper.SaveFiles(image, basePath);

                db.Damages.Add(vehicleDamage);
                db.SaveChanges();

                FireStationDamageStatus status = new FireStationDamageStatus
                {
                    DateOfArrival = DateTime.Now,
                    Id = Guid.NewGuid(),
                    FireStationDamageId = vehicleDamage.Id,
                    Official = ChainOfCommandHelper.GetCurrentOfficial(),
                    Action = DamageAction.Raised
                };
                status.CaseId = vehicleDamage.Id;
                db.DamageStatuses.Add(status);
                db.SaveChanges();

                status = new FireStationDamageStatus
                {
                    DateOfArrival = DateTime.Now,
                    Id = Guid.NewGuid(),
                    FireStationDamageId = vehicleDamage.Id,
                    Official = ChainOfCommandHelper.GetHigherOfficial()
                };
                status.CaseId = vehicleDamage.Id;
                db.DamageStatuses.Add(status);
                db.SaveChanges();

                return RedirectToAction("ViewOpenTickets");
            }

            ViewBag.FireStationId = new SelectList(DataFilter.GetFireStations(TempData.Peek("Id") + ""), "Id", "Name");
            ViewBag.FireStationDamageTypeId = new SelectList(db.BuildingDamageTypes, "Id", "Description");
            return View(vehicleDamage);
        }

        public ActionResult OpenTicketForBreakRoom()
        {
            ViewBag.BreakRoomId = new SelectList(DataFilter.GetBreakRooms(TempData.Peek("Id") + ""), "Id", "Name");
            ViewBag.BreakRoomDamageTypeId = new SelectList(db.BuildingDamageTypes, "Id", "Description");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OpenTicketForBreakRoom(BreakRoomDamage vehicleDamage,
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
                        ViewBag.BreakRoomId = new SelectList(DataFilter.GetBreakRooms(TempData.Peek("Id") + ""), "Id", "Name");
                        ViewBag.BreakRoomDamageTypeId = new SelectList(db.BuildingDamageTypes, "Id", "Description");
                        return View(vehicleDamage);
                    }
                }

                vehicleDamage.Id = Guid.NewGuid();

                string basePath = Server.MapPath(Constants.BREAK_ROOM_DAMAGE_UPLOAD_BASE_PATH + vehicleDamage.Id + "/");
                FileHelper.SaveFiles(image, basePath);

                db.Damages.Add(vehicleDamage);
                db.SaveChanges();

                BreakRoomDamageStatus status = new BreakRoomDamageStatus
                {
                    DateOfArrival = DateTime.Now,
                    Id = Guid.NewGuid(),
                    BreakRoomDamageId = vehicleDamage.Id,
                    Official = ChainOfCommandHelper.GetCurrentOfficial(),
                    Action = DamageAction.Raised
                };
                status.CaseId = vehicleDamage.Id;
                db.DamageStatuses.Add(status);
                db.SaveChanges();

                status = new BreakRoomDamageStatus
                {
                    DateOfArrival = DateTime.Now,
                    Id = Guid.NewGuid(),
                    BreakRoomDamageId = vehicleDamage.Id,
                    Official = ChainOfCommandHelper.GetHigherOfficial()
                };
                status.CaseId = vehicleDamage.Id;
                db.DamageStatuses.Add(status);
                db.SaveChanges();

                return RedirectToAction("ViewOpenTickets");
            }

            ViewBag.BreakRoomId = new SelectList(DataFilter.GetBreakRooms(TempData.Peek("Id") + ""), "Id", "Name");
            ViewBag.BreakRoomDamageTypeId = new SelectList(db.BuildingDamageTypes, "Id", "Description");
            return View(vehicleDamage);
        }

        public ActionResult OpenTicketForClassRoom()
        {
            ViewBag.ClassRoomId = new SelectList(DataFilter.GetClassRooms(TempData.Peek("Id") + ""), "Id", "Name");
            ViewBag.ClassRoomDamageTypeId = new SelectList(db.BuildingDamageTypes, "Id", "Description");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OpenTicketForClassRoom(ClassRoomDamage vehicleDamage,
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
                        ViewBag.ClassRoomId = new SelectList(DataFilter.GetClassRooms(TempData.Peek("Id") + ""), "Id", "Name");
                        ViewBag.ClassRoomDamageTypeId = new SelectList(db.BuildingDamageTypes, "Id", "Description");
                        return View(vehicleDamage);
                    }
                }

                vehicleDamage.Id = Guid.NewGuid();

                string basePath = Server.MapPath(Constants.CLASS_ROOM_DAMAGE_UPLOAD_BASE_PATH + vehicleDamage.Id + "/");
                FileHelper.SaveFiles(image, basePath);

                db.Damages.Add(vehicleDamage);
                db.SaveChanges();

                ClassRoomDamageStatus status = new ClassRoomDamageStatus
                {
                    DateOfArrival = DateTime.Now,
                    Id = Guid.NewGuid(),
                    ClassRoomDamageId = vehicleDamage.Id,
                    Official = ChainOfCommandHelper.GetCurrentOfficial(),
                    Action = DamageAction.Raised
                };
                status.CaseId = vehicleDamage.Id;
                db.DamageStatuses.Add(status);
                db.SaveChanges();

                status = new ClassRoomDamageStatus
                {
                    DateOfArrival = DateTime.Now,
                    Id = Guid.NewGuid(),
                    ClassRoomDamageId = vehicleDamage.Id,
                    Official = ChainOfCommandHelper.GetHigherOfficial()
                };
                status.CaseId = vehicleDamage.Id;
                db.DamageStatuses.Add(status);
                db.SaveChanges();

                return RedirectToAction("ViewOpenTickets");
            }

            ViewBag.ClassRoomId = new SelectList(DataFilter.GetClassRooms(TempData.Peek("Id") + ""), "Id", "Name");
            ViewBag.ClassRoomDamageTypeId = new SelectList(db.BuildingDamageTypes, "Id", "Description");
            return View(vehicleDamage);
        }

        public ActionResult OpenTicketForVehicle()
        {
            ViewBag.VehicleId = new SelectList(DataFilter.GetVehicles(TempData.Peek("Id") + ""), "Id", "Name");
            ViewBag.VehicleDamageTypeId = new SelectList(db.VehicleDamageTypes, "Id", "Description");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OpenTicketForVehicle(VehicleDamage vehicleDamage,
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
                        ViewBag.VehicleId = new SelectList(DataFilter.GetVehicles(TempData.Peek("Id") + ""), "Id", "Name");
                        ViewBag.VehicleDamageTypeId = new SelectList(db.VehicleDamageTypes, "Id", "Description");
                        return View(vehicleDamage);
                    }
                }

                vehicleDamage.Id = Guid.NewGuid();

                string basePath = Server.MapPath(Constants.VEHICLE_DAMAGE_UPLOAD_BASE_PATH + vehicleDamage.Id + "/");
                FileHelper.SaveFiles(image, basePath);

                db.Damages.Add(vehicleDamage);
                db.SaveChanges();

                VehicleDamageStatus status = new VehicleDamageStatus
                {
                    DateOfArrival = DateTime.Now,
                    Id = Guid.NewGuid(),
                    VehicleDamageId = vehicleDamage.Id,
                    Official = ChainOfCommandHelper.GetCurrentOfficial(),
                    Action = DamageAction.Raised
                };
                status.CaseId = vehicleDamage.Id;
                db.DamageStatuses.Add(status);
                db.SaveChanges();

                status = new VehicleDamageStatus
                {
                    DateOfArrival = DateTime.Now,
                    Id = Guid.NewGuid(),
                    VehicleDamageId = vehicleDamage.Id,
                    Official = ChainOfCommandHelper.GetHigherOfficial()
                };
                status.CaseId = vehicleDamage.Id;
                db.DamageStatuses.Add(status);
                db.SaveChanges();

                return RedirectToAction("ViewOpenTickets");
            }

            ViewBag.VehicleId = new SelectList(DataFilter.GetVehicles(TempData.Peek("Id") + ""), "Id", "Name");
            ViewBag.VehicleDamageTypeId = new SelectList(db.VehicleDamageTypes, "Id", "Description");
            return View(vehicleDamage);
        }

        public ActionResult OpenTicketForVehicleEquipment()
        {
            ViewBag.VehicleEquipmentId = new SelectList(DataFilter.GetVehicleEquipments(TempData.Peek("Id") + "").Select(x => new SelectListItem { Value = x.Id + "", Text = x.VehicleEquipmentType.Name }), "Value", "Text");
            ViewBag.VehicleEquipmentDamageTypeId = new SelectList(db.VehicleEquipmentDamageTypes, "Id", "Description");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OpenTicketForVehicleEquipment(VehicleEquipmentDamage vehicleDamage,
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
                        ViewBag.VehicleEquipmentId = new SelectList(DataFilter.GetVehicleEquipments(TempData.Peek("Id") + "").Select(x => new SelectListItem { Value = x.Id+"", Text = x.VehicleEquipmentType.Name }), "Value", "Text");
                        ViewBag.VehicleEquipmentDamageTypeId = new SelectList(db.VehicleEquipmentDamageTypes, "Id", "Description");
                        return View(vehicleDamage);
                    }
                }

                vehicleDamage.Id = Guid.NewGuid();
                string basePath = Server.MapPath(Constants.VEHICLE_EQUIPMENT_DAMAGE_UPLOAD_BASE_PATH + vehicleDamage.Id + "/");
                FileHelper.SaveFiles(image, basePath);
                db.Damages.Add(vehicleDamage);
                db.SaveChanges();

                VehicleEquipmentDamageStatus status = new VehicleEquipmentDamageStatus
                {
                    DateOfArrival = DateTime.Now,
                    Id = Guid.NewGuid(),
                    VehicleEquipmentDamageId = vehicleDamage.Id,
                    Official = ChainOfCommandHelper.GetCurrentOfficial(),
                    Action = DamageAction.Raised
                };
                status.CaseId = vehicleDamage.Id;
                db.DamageStatuses.Add(status);
                db.SaveChanges();

                status = new VehicleEquipmentDamageStatus
                {
                    DateOfArrival = DateTime.Now,
                    Id = Guid.NewGuid(),
                    VehicleEquipmentDamageId = vehicleDamage.Id,
                    Official = ChainOfCommandHelper.GetHigherOfficial()
                };
                status.CaseId = vehicleDamage.Id;
                db.DamageStatuses.Add(status);
                db.SaveChanges();

                return RedirectToAction("ViewOpenTickets");
            }

            ViewBag.VehicleEquipmentId = new SelectList(DataFilter.GetVehicleEquipments(TempData.Peek("Id") + "").Select(x => new SelectListItem { Value = x.Id + "", Text = x.VehicleEquipmentType.Name }), "Value", "Text");
            ViewBag.VehicleEquipmentDamageTypeId = new SelectList(db.VehicleEquipmentDamageTypes, "Id", "Description");
            return View(vehicleDamage);
        }

        public ActionResult OpenTicketForFireExtinguishingEquipment()
        {
            ViewBag.FireExtinguishingEquipmentId = new SelectList(DataFilter.GetFireExtingushingEquipments(TempData.Peek("Id") + "").Select(x => new SelectListItem { Value = x.Id + "", Text = x.FireExtinguishingEquipmentType.Name }), "Value", "Text");
            ViewBag.FireExtinguishingEquipmentDamageTypeId = new SelectList(db.FireExtinguishingEquipmentDamageTypes, "Id", "Description");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OpenTicketForFireExtinguishingEquipment(FireExtinguishingEquipmentDamage vehicleDamage,
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
                        ViewBag.FireExtinguishingEquipmentId = new SelectList(DataFilter.GetFireExtingushingEquipments(TempData.Peek("Id") + "").Select(x => new SelectListItem { Value = x.Id + "", Text = x.FireExtinguishingEquipmentType.Name }), "Value", "Text");
                        ViewBag.FireExtinguishingEquipmentDamageTypeId = new SelectList(db.FireExtinguishingEquipmentDamageTypes, "Id", "Description");
                        return View(vehicleDamage);
                    }
                }

                vehicleDamage.Id = Guid.NewGuid();

                string basePath = Server.MapPath(Constants.FIRE_EXTINGUISHING_EQUIPMENT_DAMAGE_UPLOAD_BASE_PATH + vehicleDamage.Id + "/");
                FileHelper.SaveFiles(image, basePath);

                db.Damages.Add(vehicleDamage);
                db.SaveChanges();

                FireExtinguishingEquipmentDamageStatus status = new FireExtinguishingEquipmentDamageStatus
                {
                    DateOfArrival = DateTime.Now,
                    Id = Guid.NewGuid(),
                    FireExtinguishingEquipmentDamageId = vehicleDamage.Id,
                    Official = ChainOfCommandHelper.GetCurrentOfficial(),
                    Action = DamageAction.Raised
                };
                status.CaseId = vehicleDamage.Id;
                db.DamageStatuses.Add(status);
                db.SaveChanges();

                status = new FireExtinguishingEquipmentDamageStatus
                {
                    DateOfArrival = DateTime.Now,
                    Id = Guid.NewGuid(),
                    FireExtinguishingEquipmentDamageId = vehicleDamage.Id,
                    Official = ChainOfCommandHelper.GetHigherOfficial()
                };
                status.CaseId = vehicleDamage.Id;
                db.DamageStatuses.Add(status);
                db.SaveChanges();

                return RedirectToAction("ViewOpenTickets");
            }

            ViewBag.FireExtinguishingEquipmentId = new SelectList(DataFilter.GetFireExtingushingEquipments(TempData.Peek("Id") + "").Select(x => new SelectListItem { Value = x.Id + "", Text = x.FireExtinguishingEquipmentType.Name }), "Value", "Text");
            ViewBag.FireExtinguishingEquipmentDamageTypeId = new SelectList(db.FireExtinguishingEquipmentDamageTypes, "Id", "Description");
            return View(vehicleDamage);
        }





        public ActionResult ViewOpenTickets()
        {
            return View(TicketHelper.GetDamageStatuses(TempData.Peek("Id") + ""));
        }

        public ActionResult ViewClosedTickets()
        {
            return View(TicketHelper.GetDamageStatuses(TempData.Peek("Id") + ""));
        }

        public ActionResult ViewFileMovement(Guid id)
        {
            return PartialView(db.DamageStatuses.Where(x => x.CaseId == id).ToList());
        }

        public ActionResult ViewTicket(Guid id)
        {
            DamageStatus status = db.DamageStatuses.Find(id);
            return View(status);
        }





        public ActionResult ViewPreviousDamages(Guid id)
        {
            Damage damage = null;

            if (db.Damages.Where(x => x.Id == id).Count() > 0)
            {
                damage = db.Damages.Where(x => x.Id == id).First();

                if (damage.DiscriminatorValue.Equals("VehicleDamage"))
                {
                    VehicleDamage vehicleDamage = (VehicleDamage)damage;
                    return PartialView("_vehicleDamageHistory", db.VehicleDamages
                        .Where(x => x.VehicleId == vehicleDamage.VehicleId && x.VehicleDamageTypeId == vehicleDamage.VehicleDamageTypeId).ToList());
                }
                else if (damage.DiscriminatorValue.Equals("VehicleEquipmentDama"))
                {
                    VehicleEquipmentDamage vehicleDamage = (VehicleEquipmentDamage)damage;
                    return PartialView("_vehicleEquipmentDamageHistory", db.VehicleEquipmentDamages
                        .Where(x => x.VehicleEquipmentId == vehicleDamage.VehicleEquipmentId && x.VehicleEquipmentDamageTypeId == vehicleDamage.VehicleEquipmentDamageTypeId).ToList());
                }
                else if (damage.DiscriminatorValue.Equals("FireExtinguishingEqu"))
                {
                    FireExtinguishingEquipmentDamage vehicleDamage = (FireExtinguishingEquipmentDamage)damage;
                    return PartialView("_fireExtinguishingEquipmentDamageHistory", db.FireExtinguishingEquipmentDamages
                        .Where(x => x.FireExtinguishingEquipmentId == vehicleDamage.FireExtinguishingEquipmentId && x.FireExtinguishingEquipmentDamageTypeId == vehicleDamage.FireExtinguishingEquipmentDamageTypeId).ToList());
                }
                else if (damage.DiscriminatorValue.Equals("ClassRoomDamage"))
                {
                    ClassRoomDamage vehicleDamage = (ClassRoomDamage)damage;
                    return PartialView("_classRoomDamageHistory", db.ClassRoomDamages
                        .Where(x => x.ClassRoomId == vehicleDamage.ClassRoomId && x.ClassRoomDamageTypeId == vehicleDamage.ClassRoomDamageTypeId).ToList());
                }
                else if (damage.DiscriminatorValue.Equals("BreakRoomDamage"))
                {
                    BreakRoomDamage vehicleDamage = (BreakRoomDamage)damage;
                    return PartialView("_breakRoomDamageHistory", db.BreakRoomDamages
                        .Where(x => x.BreakRoomId == vehicleDamage.BreakRoomId && x.BreakRoomDamageTypeId == vehicleDamage.BreakRoomDamageTypeId).ToList());
                }
                else if (damage.DiscriminatorValue.Equals("FireStationDamage"))
                {
                    FireStationDamage vehicleDamage = (FireStationDamage)damage;
                    return PartialView("_fireStationDamageHistory", db.FireStationDamages
                        .Where(x => x.FireStationId == vehicleDamage.FireStationId && x.FireStationDamageTypeId == vehicleDamage.FireStationDamageTypeId).ToList());
                }
                else if (damage.DiscriminatorValue.Equals("HouseDamage"))
                {
                    HouseDamage vehicleDamage = (HouseDamage)damage;
                    return PartialView("_houseDamageHistory", db.HouseDamages
                        .Where(x => x.HouseId == vehicleDamage.HouseId && x.HouseDamageTypeId == vehicleDamage.HouseDamageTypeId).ToList());
                }
                else if (damage.DiscriminatorValue.Equals("OfficeDamage"))
                {
                    OfficeDamage vehicleDamage = (OfficeDamage)damage;
                    return PartialView("_officeDamageHistory", db.OfficeDamages
                        .Where(x => x.OfficeId == vehicleDamage.OfficeId && x.OfficeDamageTypeId == vehicleDamage.OfficeDamageTypeId).ToList());
                }
                else if (damage.DiscriminatorValue.Equals("TelephoneRoomDamage"))
                {
                    TelephoneRoomDamage vehicleDamage = (TelephoneRoomDamage)damage;
                    return PartialView("_telephoneRoomDamageHistory", db.TelephoneRoomDamages
                        .Where(x => x.TelephoneRoomId == vehicleDamage.TelephoneRoomId && x.TelephoneRoomDamageTypeId == vehicleDamage.TelephoneRoomDamageTypeId).ToList());
                }
            }

            return PartialView();
        }

        public ActionResult ViewItem(Guid id)
        {
            Damage damage = db.Damages.Where(x => x.Id == id).First();
            if (damage.DiscriminatorValue.Equals("VehicleDamage"))
            {
                Vehicle vehicle = ((VehicleDamage)damage).Vehicle;
                string basePath = Server.MapPath(Constants.VEHICLE_UPLOAD_BASE_PATH + vehicle.Id + "/");
                if (Directory.Exists(basePath))
                {
                    TempData["VehicleImages"] = FileHelper.GetImages(vehicle.Id + "", basePath);
                }

                return PartialView("_vehicle", vehicle);
            }
            else if (damage.DiscriminatorValue.Equals("VehicleEquipmentDama"))
            {
                VehicleEquipment vehicle = ((VehicleEquipmentDamage)damage).VehicleEquipment;
                string basePath = Server.MapPath(Constants.VEHICLE_EQUIPMENTS_UPLOAD_BASE_PATH + vehicle.Id + "/");
                if (Directory.Exists(basePath))
                {
                    TempData["VehicleEquipmentImages"] = FileHelper.GetImages(vehicle.Id + "", basePath);
                }

                return PartialView("_vehicleEquipment", vehicle);
            }
            else if (damage.DiscriminatorValue.Equals("FireExtinguishingEqu"))
            {
                FireExtinguishingEquipment vehicle = ((FireExtinguishingEquipmentDamage)damage).FireExtinguishingEquipment;
                string basePath = Server.MapPath(Constants.FIRE_EXTINGUISHING_EQUIPMENTS_UPLOAD_BASE_PATH + vehicle.Id + "/");
                if (Directory.Exists(basePath))
                {
                    TempData["FireExtinguishingEquipmentImages"] = FileHelper.GetImages(vehicle.Id + "", basePath);
                }

                return PartialView("_fireExtinguishingEquipment", vehicle);
            }
            else if (damage.DiscriminatorValue.Equals("ClassRoomDamage"))
            {
                ClassRoom vehicle = ((ClassRoomDamage)damage).ClassRoom;
                string basePath = Server.MapPath(Constants.CLASS_ROOM_UPLOAD_BASE_PATH + vehicle.Id + "/");
                if (Directory.Exists(basePath))
                {
                    TempData["FireExtinguishingEquipmentImages"] = FileHelper.GetImages(vehicle.Id + "", basePath);
                }

                return PartialView("_classRoom", vehicle);
            }
            else if (damage.DiscriminatorValue.Equals("BreakRoomDamage"))
            {
                BreakRoom vehicle = ((BreakRoomDamage)damage).BreakRoom;
                string basePath = Server.MapPath(Constants.BREAK_ROOM_UPLOAD_BASE_PATH + vehicle.Id + "/");
                if (Directory.Exists(basePath))
                {
                    TempData["FireExtinguishingEquipmentImages"] = FileHelper.GetImages(vehicle.Id + "", basePath);
                }

                return PartialView("_breakRoom", vehicle);
            }
            else if (damage.DiscriminatorValue.Equals("FireStationDamage"))
            {
                FireStation vehicle = ((FireStationDamage)damage).FireStation;
                string basePath = Server.MapPath(Constants.FIRE_STATION_UPLOAD_BASE_PATH + vehicle.Id + "/");
                if (Directory.Exists(basePath))
                {
                    TempData["FireExtinguishingEquipmentImages"] = FileHelper.GetImages(vehicle.Id + "", basePath);
                }

                return PartialView("_fireStation", vehicle);
            }
            else if (damage.DiscriminatorValue.Equals("HouseDamage"))
            {
                House vehicle = ((HouseDamage)damage).House;
                string basePath = Server.MapPath(Constants.HOUSE_UPLOAD_BASE_PATH + vehicle.Id + "/");
                if (Directory.Exists(basePath))
                {
                    TempData["FireExtinguishingEquipmentImages"] = FileHelper.GetImages(vehicle.Id + "", basePath);
                }

                return PartialView("_house", vehicle);
            }
            else if (damage.DiscriminatorValue.Equals("OfficeDamage"))
            {
                Office vehicle = ((OfficeDamage)damage).Office;
                string basePath = Server.MapPath(Constants.OFFICE_UPLOAD_BASE_PATH + vehicle.Id + "/");
                if (Directory.Exists(basePath))
                {
                    TempData["FireExtinguishingEquipmentImages"] = FileHelper.GetImages(vehicle.Id + "", basePath);
                }

                return PartialView("_office", vehicle);
            }
            else if (damage.DiscriminatorValue.Equals("TelephoneRoomDamage"))
            {
                TelephoneRoom vehicle = ((TelephoneRoomDamage)damage).TelephoneRoom;
                string basePath = Server.MapPath(Constants.TELEPHONE_ROOM_UPLOAD_BASE_PATH + vehicle.Id + "/");
                if (Directory.Exists(basePath))
                {
                    TempData["FireExtinguishingEquipmentImages"] = FileHelper.GetImages(vehicle.Id + "", basePath);
                }

                return PartialView("_telephoneRoom", vehicle);
            }

            return View();
        }

        public ActionResult ViewDamage(Guid id)
        {
            Damage damage = db.Damages.Find(id);

            if (damage.DiscriminatorValue.Equals("VehicleDamage"))
            {
                VehicleDamage vehicleDamage = (VehicleDamage)damage;

                string basePath = Server.MapPath(Constants.VEHICLE_DAMAGE_UPLOAD_BASE_PATH + vehicleDamage.Id + "/");
                TempData["basePath"] = Constants.VEHICLE_DAMAGE_UPLOAD_BASE_PATH;
                if (Directory.Exists(basePath))
                {
                    TempData["DamageImages"] = FileHelper.GetImages(vehicleDamage.Id + "", basePath);
                }

                return PartialView(vehicleDamage);
            }
            else if (damage.DiscriminatorValue.Equals("VehicleEquipmentDama"))
            {
                VehicleEquipmentDamage vehicleDamage = (VehicleEquipmentDamage)damage;

                string basePath = Server.MapPath(Constants.VEHICLE_EQUIPMENT_DAMAGE_UPLOAD_BASE_PATH + vehicleDamage.Id + "/");
                TempData["basePath"] = Constants.VEHICLE_EQUIPMENT_DAMAGE_UPLOAD_BASE_PATH;
                if (Directory.Exists(basePath))
                {
                    TempData["DamageImages"] = FileHelper.GetImages(vehicleDamage.Id + "", basePath);
                }

                return PartialView("ViewDamage", vehicleDamage);
            }
            else if (damage.DiscriminatorValue.Equals("FireExtinguishingEqu"))
            {
                FireExtinguishingEquipmentDamage vehicleDamage = (FireExtinguishingEquipmentDamage)damage;

                string basePath = Server.MapPath(Constants.FIRE_EXTINGUISHING_EQUIPMENT_DAMAGE_UPLOAD_BASE_PATH + vehicleDamage.Id + "/");
                TempData["basePath"] = Constants.FIRE_EXTINGUISHING_EQUIPMENT_DAMAGE_UPLOAD_BASE_PATH;
                if (Directory.Exists(basePath))
                {
                    TempData["DamageImages"] = FileHelper.GetImages(vehicleDamage.Id + "", basePath);
                }

                return PartialView("ViewDamage", vehicleDamage);
            }
            else if (damage.DiscriminatorValue.Equals("ClassRoomDamage"))
            {
                ClassRoomDamage vehicleDamage = (ClassRoomDamage)damage;

                string basePath = Server.MapPath(Constants.CLASS_ROOM_DAMAGE_UPLOAD_BASE_PATH + vehicleDamage.Id + "/");
                TempData["basePath"] = Constants.CLASS_ROOM_DAMAGE_UPLOAD_BASE_PATH;
                if (Directory.Exists(basePath))
                {
                    TempData["DamageImages"] = FileHelper.GetImages(vehicleDamage.Id + "", basePath);
                }

                return PartialView("ViewDamage", vehicleDamage);
            }
            else if (damage.DiscriminatorValue.Equals("BreakRoomDamage"))
            {
                BreakRoomDamage vehicleDamage = (BreakRoomDamage)damage;

                string basePath = Server.MapPath(Constants.BREAK_ROOM_DAMAGE_UPLOAD_BASE_PATH + vehicleDamage.Id + "/");
                TempData["basePath"] = Constants.BREAK_ROOM_DAMAGE_UPLOAD_BASE_PATH;
                if (Directory.Exists(basePath))
                {
                    TempData["DamageImages"] = FileHelper.GetImages(vehicleDamage.Id + "", basePath);
                }

                return PartialView("ViewDamage", vehicleDamage);
            }
            else if (damage.DiscriminatorValue.Equals("FireStationDamage"))
            {
                FireStationDamage vehicleDamage = (FireStationDamage)damage;

                string basePath = Server.MapPath(Constants.FIRE_STATION_DAMAGE_UPLOAD_BASE_PATH + vehicleDamage.Id + "/");
                TempData["basePath"] = Constants.FIRE_STATION_DAMAGE_UPLOAD_BASE_PATH;
                if (Directory.Exists(basePath))
                {
                    TempData["DamageImages"] = FileHelper.GetImages(vehicleDamage.Id + "", basePath);
                }

                return PartialView("ViewDamage", vehicleDamage);
            }
            else if (damage.DiscriminatorValue.Equals("HouseDamage"))
            {
                HouseDamage vehicleDamage = (HouseDamage)damage;

                string basePath = Server.MapPath(Constants.HOUSE_DAMAGE_UPLOAD_BASE_PATH + vehicleDamage.Id + "/");
                TempData["basePath"] = Constants.HOUSE_DAMAGE_UPLOAD_BASE_PATH;
                if (Directory.Exists(basePath))
                {
                    TempData["DamageImages"] = FileHelper.GetImages(vehicleDamage.Id + "", basePath);
                }

                return PartialView("ViewDamage", vehicleDamage);
            }
            else if (damage.DiscriminatorValue.Equals("OfficeDamage"))
            {
                OfficeDamage vehicleDamage = (OfficeDamage)damage;

                string basePath = Server.MapPath(Constants.OFFICE_DAMAGE_UPLOAD_BASE_PATH + vehicleDamage.Id + "/");
                TempData["basePath"] = Constants.OFFICE_DAMAGE_UPLOAD_BASE_PATH;
                if (Directory.Exists(basePath))
                {
                    TempData["DamageImages"] = FileHelper.GetImages(vehicleDamage.Id + "", basePath);
                }

                return PartialView("ViewDamage", vehicleDamage);
            }
            else if (damage.DiscriminatorValue.Equals("TelephoneRoomDamage"))
            {
                TelephoneRoomDamage vehicleDamage = (TelephoneRoomDamage)damage;

                string basePath = Server.MapPath(Constants.TELEPHONE_ROOM_DAMAGE_UPLOAD_BASE_PATH + vehicleDamage.Id + "/");
                TempData["basePath"] = Constants.TELEPHONE_ROOM_DAMAGE_UPLOAD_BASE_PATH;
                if (Directory.Exists(basePath))
                {
                    TempData["DamageImages"] = FileHelper.GetImages(vehicleDamage.Id + "", basePath);
                }

                return PartialView("ViewDamage", vehicleDamage);
            }

            return PartialView();
        }

        public ActionResult ViewRepair(Guid id)
        {
            Damage damage = db.Damages.Find(id);

            if (damage.DiscriminatorValue.Equals("VehicleDamage"))
            {
                List<VehicleRepair> vehicleRepairs = db.VehicleDamages.Find(id).VehicleRepairs.ToList();

                if (vehicleRepairs.Count() > 0)
                {
                    VehicleRepair vehicleRepair = vehicleRepairs[0];
                    string basePath = Server.MapPath(Constants.VEHICLE_REPAIR_UPLOAD_BASE_PATH + vehicleRepair.Id + "/");
                    TempData["basePath"] = Constants.VEHICLE_REPAIR_UPLOAD_BASE_PATH;
                    if (Directory.Exists(basePath))
                    {
                        TempData["DamageImages"] = FileHelper.GetImages(vehicleRepair.Id + "", basePath);
                    }

                    return PartialView(vehicleRepair);
                }
            }
            else if (damage.DiscriminatorValue.Equals("VehicleEquipmentDama"))
            {
                List<VehicleEquipmentRepair> vehicleRepairs = db.VehicleEquipmentDamages.Find(id).VehicleEquipmentRepairs.ToList();

                if (vehicleRepairs.Count() > 0)
                {
                    VehicleEquipmentRepair vehicleRepair = vehicleRepairs[0];
                    string basePath = Server.MapPath(Constants.VEHICLE_EQUIPMENT_REPAIR_UPLOAD_BASE_PATH + vehicleRepair.Id + "/");
                    TempData["basePath"] = Constants.VEHICLE_EQUIPMENT_REPAIR_UPLOAD_BASE_PATH;
                    if (Directory.Exists(basePath))
                    {
                        TempData["DamageImages"] = FileHelper.GetImages(vehicleRepair.Id + "", basePath);
                    }

                    return PartialView(vehicleRepair);
                }
            }
            else if (damage.DiscriminatorValue.Equals("FireExtinguishingEqu"))
            {
                List<FireExtinguishingEquipmentRepair> vehicleRepairs = db.FireExtinguishingEquipmentDamages.Find(id).FireExtinguishingEquipmentRepairs.ToList();

                if (vehicleRepairs.Count() > 0)
                {
                    FireExtinguishingEquipmentRepair vehicleRepair = vehicleRepairs[0];
                    string basePath = Server.MapPath(Constants.FIRE_EXTINGUISHING_EQUIPMENT_REPAIR_UPLOAD_BASE_PATH + vehicleRepair.Id + "/");
                    TempData["basePath"] = Constants.FIRE_EXTINGUISHING_EQUIPMENT_REPAIR_UPLOAD_BASE_PATH;
                    if (Directory.Exists(basePath))
                    {
                        TempData["DamageImages"] = FileHelper.GetImages(vehicleRepair.Id + "", basePath);
                    }

                    return PartialView(vehicleRepair);
                }
            }
            else if (damage.DiscriminatorValue.Equals("ClassRoomDamage"))
            {
                List<ClassRoomRepair> vehicleRepairs = db.ClassRoomDamages.Find(id).ClassRoomRepairs.ToList();

                if (vehicleRepairs.Count() > 0)
                {
                    ClassRoomRepair vehicleRepair = vehicleRepairs[0];
                    string basePath = Server.MapPath(Constants.CLASS_ROOM_REPAIR_UPLOAD_BASE_PATH + vehicleRepair.Id + "/");
                    TempData["basePath"] = Constants.CLASS_ROOM_REPAIR_UPLOAD_BASE_PATH;
                    if (Directory.Exists(basePath))
                    {
                        TempData["DamageImages"] = FileHelper.GetImages(vehicleRepair.Id + "", basePath);
                    }

                    return PartialView(vehicleRepair);
                }
            }
            else if (damage.DiscriminatorValue.Equals("BreakRoomDamage"))
            {
                List<BreakRoomRepair> vehicleRepairs = db.BreakRoomDamages.Find(id).BreakRoomRepairs.ToList();

                if (vehicleRepairs.Count() > 0)
                {
                    BreakRoomRepair vehicleRepair = vehicleRepairs[0];
                    string basePath = Server.MapPath(Constants.BREAK_ROOM_REPAIR_UPLOAD_BASE_PATH + vehicleRepair.Id + "/");
                    TempData["basePath"] = Constants.BREAK_ROOM_REPAIR_UPLOAD_BASE_PATH;
                    if (Directory.Exists(basePath))
                    {
                        TempData["DamageImages"] = FileHelper.GetImages(vehicleRepair.Id + "", basePath);
                    }

                    return PartialView(vehicleRepair);
                }
            }
            else if (damage.DiscriminatorValue.Equals("FireStationDamage"))
            {
                List<FireStationRepair> vehicleRepairs = db.FireStationDamages.Find(id).FireStationRepairs.ToList();

                if (vehicleRepairs.Count() > 0)
                {
                    FireStationRepair vehicleRepair = vehicleRepairs[0];
                    string basePath = Server.MapPath(Constants.FIRE_STATION_REPAIR_UPLOAD_BASE_PATH + vehicleRepair.Id + "/");
                    TempData["basePath"] = Constants.FIRE_STATION_REPAIR_UPLOAD_BASE_PATH;
                    if (Directory.Exists(basePath))
                    {
                        TempData["DamageImages"] = FileHelper.GetImages(vehicleRepair.Id + "", basePath);
                    }

                    return PartialView(vehicleRepair);
                }
            }
            else if (damage.DiscriminatorValue.Equals("HouseDamage"))
            {
                List<HouseRepair> vehicleRepairs = db.HouseDamages.Find(id).HouseRepairs.ToList();

                if (vehicleRepairs.Count() > 0)
                {
                    HouseRepair vehicleRepair = vehicleRepairs[0];
                    string basePath = Server.MapPath(Constants.HOUSE_REPAIR_UPLOAD_BASE_PATH + vehicleRepair.Id + "/");
                    TempData["basePath"] = Constants.HOUSE_REPAIR_UPLOAD_BASE_PATH;
                    if (Directory.Exists(basePath))
                    {
                        TempData["DamageImages"] = FileHelper.GetImages(vehicleRepair.Id + "", basePath);
                    }

                    return PartialView(vehicleRepair);
                }
            }
            else if (damage.DiscriminatorValue.Equals("OfficeDamage"))
            {
                List<OfficeRepair> vehicleRepairs = db.OfficeDamages.Find(id).OfficeRepairs.ToList();

                if (vehicleRepairs.Count() > 0)
                {
                    OfficeRepair vehicleRepair = vehicleRepairs[0];
                    string basePath = Server.MapPath(Constants.OFFICE_REPAIR_UPLOAD_BASE_PATH + vehicleRepair.Id + "/");
                    TempData["basePath"] = Constants.OFFICE_REPAIR_UPLOAD_BASE_PATH;
                    if (Directory.Exists(basePath))
                    {
                        TempData["DamageImages"] = FileHelper.GetImages(vehicleRepair.Id + "", basePath);
                    }

                    return PartialView(vehicleRepair);
                }
            }
            else if (damage.DiscriminatorValue.Equals("TelephoneRoomDamage"))
            {
                List<TelephoneRoomRepair> vehicleRepairs = db.TelephoneRoomDamages.Find(id).TelephoneRoomRepairs.ToList();

                if (vehicleRepairs.Count() > 0)
                {
                    TelephoneRoomRepair vehicleRepair = vehicleRepairs[0];
                    string basePath = Server.MapPath(Constants.TELEPHONE_ROOM_REPAIR_UPLOAD_BASE_PATH + vehicleRepair.Id + "/");
                    TempData["basePath"] = Constants.TELEPHONE_ROOM_REPAIR_UPLOAD_BASE_PATH;
                    if (Directory.Exists(basePath))
                    {
                        TempData["DamageImages"] = FileHelper.GetImages(vehicleRepair.Id + "", basePath);
                    }

                    return PartialView(vehicleRepair);
                }
            }

            return PartialView();
        }

        

        public ActionResult DisplayFormForApproveDisapproveElevateTicket(Guid id)
        {
            Official currentOfficial = ChainOfCommandHelper.GetCurrentOfficial();
            DamageStatus status = db.DamageStatuses.Find(id);
            if (status.Official == currentOfficial && status.Action == DamageAction.Open)
            {
                if (status.DiscriminatorValue.Equals("VehicleDamageStatus"))
                {
                    return PartialView("_vehicleApproveDisapproveElevateTicket", db.VehicleDamagesStatus.Find(id));
                }
                else if (status.DiscriminatorValue.Equals("VehicleEquipmentDama"))
                {
                    return PartialView("_vehicleEquipmentApproveDisapproveElevateTicket", db.VehicleEquipmentDamageStatus.Find(id));
                }
                else if (status.DiscriminatorValue.Equals("FireExtinguishingEqu"))
                {
                    return PartialView("_fireExtinguishingEquipmentApproveDisapproveElevateTicket", db.FireExtinguishingEquipmentDamageStatues.Find(id));
                }
                else if (status.DiscriminatorValue.Equals("ClassRoomDamageStatu"))
                {
                    return PartialView("_classRoomApproveDisapproveElevateTicket", db.ClassRoomDamageStatuses.Find(id));
                }
                else if (status.DiscriminatorValue.Equals("BreakRoomDamageStatu"))
                {
                    return PartialView("_breakRoomApproveDisapproveElevateTicket", db.BreakRoomDamageStatuses.Find(id));
                }
                else if (status.DiscriminatorValue.Equals("FireStationDamageSta"))
                {
                    return PartialView("_fireStationApproveDisapproveElevateTicket", db.FireStationDamageStatuses.Find(id));
                }
                else if (status.DiscriminatorValue.Equals("HouseDamageStatus"))
                {
                    return PartialView("_houseApproveDisapproveElevateTicket", db.HouseDamageStatuses.Find(id));
                }
                else if (status.DiscriminatorValue.Equals("OfficeDamageStatus"))
                {
                    return PartialView("_officeApproveDisapproveElevateTicket", db.OfficeDamageStatuses.Find(id));
                }
                else if (status.DiscriminatorValue.Equals("TelephoneRoomDamageS"))
                {
                    return PartialView("_telephoneRoomApproveDisapproveElevateTicket", db.TelephoneRoomDamageStatuses.Find(id));
                }
            }

            return Content("");
        }

        public ActionResult DisplayFormForCloseTicket(Guid id)
        {
            Official currentOfficial = ChainOfCommandHelper.GetCurrentOfficial();
            DamageStatus status = db.DamageStatuses.Find(id);
            DamageStatus initialStatus = db.DamageStatuses.Where(x => x.CaseId == status.CaseId && x.Action == DamageAction.Raised).First();
            if (initialStatus.Official == currentOfficial && (status.Action == DamageAction.Approve))
            {
                if (status.DiscriminatorValue.Equals("VehicleDamageStatus"))
                {
                    TempData["StatusId"] = id;
                    VehicleDamageStatus vehicleStatus = db.VehicleDamagesStatus.Find(id);

                    VehicleRepair reapir = new VehicleRepair
                    {
                        Id = new Guid(),
                        VehicleDamage = vehicleStatus.VehicleDamage
                    };

                    return PartialView("_vehicleCloseTicket", reapir);
                }
                else if (status.DiscriminatorValue.Equals("VehicleEquipmentDama"))
                {
                    TempData["StatusId"] = id;
                    VehicleEquipmentDamageStatus vehicleStatus = db.VehicleEquipmentDamageStatus.Find(id);

                    VehicleEquipmentRepair reapir = new VehicleEquipmentRepair
                    {
                        Id = new Guid(),
                        VehicleEquipmentDamage = vehicleStatus.VehicleEquipmentDamage
                    };

                    return PartialView("_vehicleEquipmentCloseTicket", reapir);
                }
                else if (status.DiscriminatorValue.Equals("FireExtinguishingEqu"))
                {
                    TempData["StatusId"] = id;
                    FireExtinguishingEquipmentDamageStatus vehicleStatus = db.FireExtinguishingEquipmentDamageStatues.Find(id);

                    FireExtinguishingEquipmentRepair reapir = new FireExtinguishingEquipmentRepair
                    {
                        Id = new Guid(),
                        FireExtinguishingEquipmentDamage = vehicleStatus.FireExtinguishingEquipmentDamage
                    };

                    return PartialView("_fireExtinguishingEquipmentCloseTicket", reapir);
                }
                else if (status.DiscriminatorValue.Equals("ClassRoomDamageStatu"))
                {
                    TempData["StatusId"] = id;
                    ClassRoomDamageStatus vehicleStatus = db.ClassRoomDamageStatuses.Find(id);

                    ClassRoomRepair reapir = new ClassRoomRepair
                    {
                        Id = new Guid(),
                        ClassRoomDamageId = vehicleStatus.ClassRoomDamageId
                    };

                    return PartialView("_classRoomCloseTicket", reapir);
                }
                else if (status.DiscriminatorValue.Equals("BreakRoomDamageStatu"))
                {
                    TempData["StatusId"] = id;
                    BreakRoomDamageStatus vehicleStatus = db.BreakRoomDamageStatuses.Find(id);

                    BreakRoomRepair reapir = new BreakRoomRepair
                    {
                        Id = new Guid(),
                        BreakRoomDamageId = vehicleStatus.BreakRoomDamageId
                    };

                    return PartialView("_breakRoomCloseTicket", reapir);
                }
                else if (status.DiscriminatorValue.Equals("FireStationDamageSta"))
                {
                    TempData["StatusId"] = id;
                    FireStationDamageStatus vehicleStatus = db.FireStationDamageStatuses.Find(id);

                    FireStationRepair reapir = new FireStationRepair
                    {
                        Id = new Guid(),
                        FireStationDamageId = vehicleStatus.FireStationDamageId
                    };

                    return PartialView("_fireStationCloseTicket", reapir);
                }
                else if (status.DiscriminatorValue.Equals("HouseDamageStatus"))
                {
                    TempData["StatusId"] = id;
                    HouseDamageStatus vehicleStatus = db.HouseDamageStatuses.Find(id);

                    HouseRepair reapir = new HouseRepair
                    {
                        Id = new Guid(),
                        HouseDamageId = vehicleStatus.HouseDamageId
                    };

                    return PartialView("_houseCloseTicket", reapir);
                }
                else if (status.DiscriminatorValue.Equals("OfficeDamageStatus"))
                {
                    TempData["StatusId"] = id;
                    OfficeDamageStatus vehicleStatus = db.OfficeDamageStatuses.Find(id);

                    OfficeRepair reapir = new OfficeRepair
                    {
                        Id = new Guid(),
                        OfficeDamageId = vehicleStatus.OfficeDamageId
                    };

                    return PartialView("_officeCloseTicket", reapir);
                }
                else if (status.DiscriminatorValue.Equals("TelephoneRoomDamageS"))
                {
                    TempData["StatusId"] = id;
                    TelephoneRoomDamageStatus vehicleStatus = db.TelephoneRoomDamageStatuses.Find(id);

                    TelephoneRoomRepair reapir = new TelephoneRoomRepair
                    {
                        Id = new Guid(),
                        TelephoneRoomDamageId = vehicleStatus.TelephoneRoomDamageId
                    };

                    return PartialView("_telephoneRoomCloseTicket", reapir);
                }
            }

            return Content("");
        }



        [HttpPost]
        public ActionResult CloseTicketForTelephoneRoom(TelephoneRoomRepair repair, IEnumerable<HttpPostedFileBase> image)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in image)
                {
                    string error;
                    if (!FileHelper.CheckIfFileIsImage(item, out error))
                    {
                        ModelState.AddModelError("", error);
                        return View(repair);
                    }
                }
                string basePath = Server.MapPath(Constants.TELEPHONE_ROOM_REPAIR_UPLOAD_BASE_PATH + repair.Id + "/");
                FileHelper.SaveFiles(image, basePath);

                TelephoneRoomDamageStatus status = db.TelephoneRoomDamageStatuses.Find(TempData.Peek("StatusId"));
                repair.TelephoneRoomDamageId = status.TelephoneRoomDamageId;
                db.Repairs.Add(repair);
                db.SaveChanges();

                TelephoneRoomDamageStatus newStatus = new TelephoneRoomDamageStatus
                {
                    Id = Guid.NewGuid(),
                    Action = DamageAction.Closed,
                    CaseId = status.CaseId,
                    DateOfArrival = DateTime.Now,
                    Official = ChainOfCommandHelper.GetCurrentOfficial(),
                    TelephoneRoomDamageId = status.TelephoneRoomDamageId
                };
                db.DamageStatuses.Add(newStatus);
                db.SaveChanges();

                return RedirectToAction("ViewClosedTickets");
            }

            return View(repair);
        }

        [HttpPost]
        public ActionResult CloseTicketForOffice(OfficeRepair repair, IEnumerable<HttpPostedFileBase> image)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in image)
                {
                    string error;
                    if (!FileHelper.CheckIfFileIsImage(item, out error))
                    {
                        ModelState.AddModelError("", error);
                        return View(repair);
                    }
                }
                string basePath = Server.MapPath(Constants.OFFICE_REPAIR_UPLOAD_BASE_PATH + repair.Id + "/");
                FileHelper.SaveFiles(image, basePath);

                OfficeDamageStatus status = db.OfficeDamageStatuses.Find(TempData.Peek("StatusId"));
                repair.OfficeDamageId = status.OfficeDamageId;
                db.Repairs.Add(repair);
                db.SaveChanges();

                OfficeDamageStatus newStatus = new OfficeDamageStatus
                {
                    Id = Guid.NewGuid(),
                    Action = DamageAction.Closed,
                    CaseId = status.CaseId,
                    DateOfArrival = DateTime.Now,
                    Official = ChainOfCommandHelper.GetCurrentOfficial(),
                    OfficeDamageId = status.OfficeDamageId
                };
                db.DamageStatuses.Add(newStatus);
                db.SaveChanges();

                return RedirectToAction("ViewClosedTickets");
            }

            return View(repair);
        }

        [HttpPost]
        public ActionResult CloseTicketForHouse(HouseRepair repair, IEnumerable<HttpPostedFileBase> image)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in image)
                {
                    string error;
                    if (!FileHelper.CheckIfFileIsImage(item, out error))
                    {
                        ModelState.AddModelError("", error);
                        return View(repair);
                    }
                }
                string basePath = Server.MapPath(Constants.HOUSE_REPAIR_UPLOAD_BASE_PATH + repair.Id + "/");
                FileHelper.SaveFiles(image, basePath);

                HouseDamageStatus status = db.HouseDamageStatuses.Find(TempData.Peek("StatusId"));
                repair.HouseDamageId = status.HouseDamageId;
                db.Repairs.Add(repair);
                db.SaveChanges();

                HouseDamageStatus newStatus = new HouseDamageStatus
                {
                    Id = Guid.NewGuid(),
                    Action = DamageAction.Closed,
                    CaseId = status.CaseId,
                    DateOfArrival = DateTime.Now,
                    Official = ChainOfCommandHelper.GetCurrentOfficial(),
                    HouseDamageId = status.HouseDamageId
                };
                db.DamageStatuses.Add(newStatus);
                db.SaveChanges();

                return RedirectToAction("ViewClosedTickets");
            }

            return View(repair);
        }

        [HttpPost]
        public ActionResult CloseTicketForFireStation(FireStationRepair repair, IEnumerable<HttpPostedFileBase> image)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in image)
                {
                    string error;
                    if (!FileHelper.CheckIfFileIsImage(item, out error))
                    {
                        ModelState.AddModelError("", error);
                        return View(repair);
                    }
                }
                string basePath = Server.MapPath(Constants.FIRE_STATION_REPAIR_UPLOAD_BASE_PATH + repair.Id + "/");
                FileHelper.SaveFiles(image, basePath);

                FireStationDamageStatus status = db.FireStationDamageStatuses.Find(TempData.Peek("StatusId"));
                repair.FireStationDamageId = status.FireStationDamageId;
                db.Repairs.Add(repair);
                db.SaveChanges();

                FireStationDamageStatus newStatus = new FireStationDamageStatus
                {
                    Id = Guid.NewGuid(),
                    Action = DamageAction.Closed,
                    CaseId = status.CaseId,
                    DateOfArrival = DateTime.Now,
                    Official = ChainOfCommandHelper.GetCurrentOfficial(),
                    FireStationDamageId = status.FireStationDamageId
                };
                db.DamageStatuses.Add(newStatus);
                db.SaveChanges();

                return RedirectToAction("ViewClosedTickets");
            }

            return View(repair);
        }

        [HttpPost]
        public ActionResult CloseTicketForBreakRoom(BreakRoomRepair repair, IEnumerable<HttpPostedFileBase> image)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in image)
                {
                    string error;
                    if (!FileHelper.CheckIfFileIsImage(item, out error))
                    {
                        ModelState.AddModelError("", error);
                        return View(repair);
                    }
                }
                string basePath = Server.MapPath(Constants.BREAK_ROOM_REPAIR_UPLOAD_BASE_PATH + repair.Id + "/");
                FileHelper.SaveFiles(image, basePath);

                BreakRoomDamageStatus status = db.BreakRoomDamageStatuses.Find(TempData.Peek("StatusId"));
                repair.BreakRoomDamageId = status.BreakRoomDamageId;
                db.Repairs.Add(repair);
                db.SaveChanges();

                BreakRoomDamageStatus newStatus = new BreakRoomDamageStatus
                {
                    Id = Guid.NewGuid(),
                    Action = DamageAction.Closed,
                    CaseId = status.CaseId,
                    DateOfArrival = DateTime.Now,
                    Official = ChainOfCommandHelper.GetCurrentOfficial(),
                    BreakRoomDamageId = status.BreakRoomDamageId
                };
                db.DamageStatuses.Add(newStatus);
                db.SaveChanges();

                return RedirectToAction("ViewClosedTickets");
            }

            return View(repair);
        }

        [HttpPost]
        public ActionResult CloseTicketForClassRoom(ClassRoomRepair repair, IEnumerable<HttpPostedFileBase> image)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in image)
                {
                    string error;
                    if (!FileHelper.CheckIfFileIsImage(item, out error))
                    {
                        ModelState.AddModelError("", error);
                        return View(repair);
                    }
                }
                string basePath = Server.MapPath(Constants.CLASS_ROOM_REPAIR_UPLOAD_BASE_PATH + repair.Id + "/");
                FileHelper.SaveFiles(image, basePath);

                ClassRoomDamageStatus status = db.ClassRoomDamageStatuses.Find(TempData.Peek("StatusId"));
                repair.ClassRoomDamageId = status.ClassRoomDamageId;
                db.Repairs.Add(repair);
                db.SaveChanges();

                ClassRoomDamageStatus newStatus = new ClassRoomDamageStatus
                {
                    Id = Guid.NewGuid(),
                    Action = DamageAction.Closed,
                    CaseId = status.CaseId,
                    DateOfArrival = DateTime.Now,
                    Official = ChainOfCommandHelper.GetCurrentOfficial(),
                    ClassRoomDamageId = status.ClassRoomDamageId
                };
                db.DamageStatuses.Add(newStatus);
                db.SaveChanges();

                return RedirectToAction("ViewClosedTickets");
            }

            return View(repair);
        }

        [HttpPost]
        public ActionResult CloseTicketForVehicle(VehicleRepair repair, IEnumerable<HttpPostedFileBase> image)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in image)
                {
                    string error;
                    if (!FileHelper.CheckIfFileIsImage(item, out error))
                    {
                        ModelState.AddModelError("", error);
                        return View(repair);
                    }
                }
                string basePath = Server.MapPath(Constants.VEHICLE_REPAIR_UPLOAD_BASE_PATH + repair.Id + "/");
                FileHelper.SaveFiles(image, basePath);

                VehicleDamageStatus status = db.VehicleDamagesStatus.Find(TempData.Peek("StatusId"));
                repair.VehicleDamageId = status.VehicleDamageId;
                db.Repairs.Add(repair);
                db.SaveChanges();

                VehicleDamageStatus newStatus = new VehicleDamageStatus
                {
                    Id = Guid.NewGuid(),
                    Action = DamageAction.Closed,
                    CaseId = status.CaseId,
                    DateOfArrival = DateTime.Now,
                    Official = ChainOfCommandHelper.GetCurrentOfficial(),
                    VehicleDamageId = status.VehicleDamageId
                };
                db.DamageStatuses.Add(newStatus);
                db.SaveChanges();

                return RedirectToAction("ViewClosedTickets");
            }

            return View(repair);
        }

        [HttpPost]
        public ActionResult CloseTicketForVehicleEquipment(VehicleEquipmentRepair repair, IEnumerable<HttpPostedFileBase> image)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in image)
                {
                    string error;
                    if (!FileHelper.CheckIfFileIsImage(item, out error))
                    {
                        ModelState.AddModelError("", error);
                        return View(repair);
                    }
                }
                string basePath = Server.MapPath(Constants.VEHICLE_EQUIPMENT_REPAIR_UPLOAD_BASE_PATH + repair.Id + "/");
                FileHelper.SaveFiles(image, basePath);

                VehicleEquipmentDamageStatus status = db.VehicleEquipmentDamageStatus.Find(TempData.Peek("StatusId"));
                repair.VehicleEquipmentDamageId = status.VehicleEquipmentDamageId;
                db.Repairs.Add(repair);
                db.SaveChanges();

                VehicleEquipmentDamageStatus newStatus = new VehicleEquipmentDamageStatus
                {
                    Id = Guid.NewGuid(),
                    Action = DamageAction.Closed,
                    CaseId = status.CaseId,
                    DateOfArrival = DateTime.Now,
                    Official = ChainOfCommandHelper.GetCurrentOfficial(),
                    VehicleEquipmentDamageId = status.VehicleEquipmentDamageId
                };
                db.DamageStatuses.Add(newStatus);
                db.SaveChanges();

                return RedirectToAction("ViewClosedTickets");
            }

            return View(repair);
        }

        [HttpPost]
        public ActionResult CloseTicketForFireExtinguishingEquipment(FireExtinguishingEquipmentRepair repair, IEnumerable<HttpPostedFileBase> image)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in image)
                {
                    string error;
                    if (!FileHelper.CheckIfFileIsImage(item, out error))
                    {
                        ModelState.AddModelError("", error);
                        return View(repair);
                    }
                }
                string basePath = Server.MapPath(Constants.FIRE_EXTINGUISHING_EQUIPMENT_REPAIR_UPLOAD_BASE_PATH + repair.Id + "/");
                FileHelper.SaveFiles(image, basePath);

                FireExtinguishingEquipmentDamageStatus status = db.FireExtinguishingEquipmentDamageStatues.Find(TempData.Peek("StatusId"));
                repair.FireExtinguishingEquipmentDamageId = status.FireExtinguishingEquipmentDamageId;
                db.Repairs.Add(repair);
                db.SaveChanges();

                FireExtinguishingEquipmentDamageStatus newStatus = new FireExtinguishingEquipmentDamageStatus
                {
                    Id = Guid.NewGuid(),
                    Action = DamageAction.Closed,
                    CaseId = status.CaseId,
                    DateOfArrival = DateTime.Now,
                    Official = ChainOfCommandHelper.GetCurrentOfficial(),
                    FireExtinguishingEquipmentDamageId = status.FireExtinguishingEquipmentDamageId
                };
                db.DamageStatuses.Add(newStatus);
                db.SaveChanges();

                return RedirectToAction("ViewClosedTickets");
            }

            return View(repair);
        }



        public ActionResult ApproveDisapproveElevateTicketForTelephoneRoom(TelephoneRoomDamageStatus vehicleStatus)
        {
            if (ModelState.IsValid)
            {
                if (vehicleStatus.Action == DamageAction.Open)
                {
                    ModelState.AddModelError("Action", "Action can not be open");
                    return View(vehicleStatus);
                }

                vehicleStatus.DateOfLeaving = DateTime.Now;
                db.Entry(vehicleStatus).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                if (vehicleStatus.Action == DamageAction.Elevate)
                {
                    TelephoneRoomDamageStatus newStatus = new TelephoneRoomDamageStatus
                    {
                        Id = Guid.NewGuid(),
                        CaseId = vehicleStatus.CaseId,
                        DateOfArrival = DateTime.Now,
                        Official = ChainOfCommandHelper.GetHigherOfficial(),
                        TelephoneRoomDamageId = vehicleStatus.TelephoneRoomDamageId
                    };
                    db.TelephoneRoomDamageStatuses.Add(newStatus);
                    db.SaveChanges();
                }

                return RedirectToAction("ViewOpenTickets");
            }

            return View("ViewTicket", vehicleStatus);
        }

        public ActionResult ApproveDisapproveElevateTicketForOffice(OfficeDamageStatus vehicleStatus)
        {
            if (ModelState.IsValid)
            {
                if (vehicleStatus.Action == DamageAction.Open)
                {
                    ModelState.AddModelError("Action", "Action can not be open");
                    return View(vehicleStatus);
                }

                vehicleStatus.DateOfLeaving = DateTime.Now;
                db.Entry(vehicleStatus).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                if (vehicleStatus.Action == DamageAction.Elevate)
                {
                    OfficeDamageStatus newStatus = new OfficeDamageStatus
                    {
                        Id = Guid.NewGuid(),
                        CaseId = vehicleStatus.CaseId,
                        DateOfArrival = DateTime.Now,
                        Official = ChainOfCommandHelper.GetHigherOfficial(),
                        OfficeDamageId = vehicleStatus.OfficeDamageId
                    };
                    db.OfficeDamageStatuses.Add(newStatus);
                    db.SaveChanges();
                }

                return RedirectToAction("ViewOpenTickets");
            }

            return View("ViewTicket", vehicleStatus);
        }

        public ActionResult ApproveDisapproveElevateTicketForHouse(HouseDamageStatus vehicleStatus)
        {
            if (ModelState.IsValid)
            {
                if (vehicleStatus.Action == DamageAction.Open)
                {
                    ModelState.AddModelError("Action", "Action can not be open");
                    return View(vehicleStatus);
                }

                vehicleStatus.DateOfLeaving = DateTime.Now;
                db.Entry(vehicleStatus).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                if (vehicleStatus.Action == DamageAction.Elevate)
                {
                    HouseDamageStatus newStatus = new HouseDamageStatus
                    {
                        Id = Guid.NewGuid(),
                        CaseId = vehicleStatus.CaseId,
                        DateOfArrival = DateTime.Now,
                        Official = ChainOfCommandHelper.GetHigherOfficial(),
                        HouseDamageId = vehicleStatus.HouseDamageId
                    };
                    db.HouseDamageStatuses.Add(newStatus);
                    db.SaveChanges();
                }

                return RedirectToAction("ViewOpenTickets");
            }

            return View("ViewTicket", vehicleStatus);
        }

        public ActionResult ApproveDisapproveElevateTicketForFireStation(FireStationDamageStatus vehicleStatus)
        {
            if (ModelState.IsValid)
            {
                if (vehicleStatus.Action == DamageAction.Open)
                {
                    ModelState.AddModelError("Action", "Action can not be open");
                    return View(vehicleStatus);
                }

                vehicleStatus.DateOfLeaving = DateTime.Now;
                db.Entry(vehicleStatus).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                if (vehicleStatus.Action == DamageAction.Elevate)
                {
                    FireStationDamageStatus newStatus = new FireStationDamageStatus
                    {
                        Id = Guid.NewGuid(),
                        CaseId = vehicleStatus.CaseId,
                        DateOfArrival = DateTime.Now,
                        Official = ChainOfCommandHelper.GetHigherOfficial(),
                        FireStationDamageId = vehicleStatus.FireStationDamageId
                    };
                    db.FireStationDamageStatuses.Add(newStatus);
                    db.SaveChanges();
                }

                return RedirectToAction("ViewOpenTickets");
            }

            return View("ViewTicket", vehicleStatus);
        }

        public ActionResult ApproveDisapproveElevateTicketForBreakRoom(BreakRoomDamageStatus vehicleStatus)
        {
            if (ModelState.IsValid)
            {
                if (vehicleStatus.Action == DamageAction.Open)
                {
                    ModelState.AddModelError("Action", "Action can not be open");
                    return View(vehicleStatus);
                }

                vehicleStatus.DateOfLeaving = DateTime.Now;
                db.Entry(vehicleStatus).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                if (vehicleStatus.Action == DamageAction.Elevate)
                {
                    BreakRoomDamageStatus newStatus = new BreakRoomDamageStatus
                    {
                        Id = Guid.NewGuid(),
                        CaseId = vehicleStatus.CaseId,
                        DateOfArrival = DateTime.Now,
                        Official = ChainOfCommandHelper.GetHigherOfficial(),
                        BreakRoomDamageId = vehicleStatus.BreakRoomDamageId
                    };
                    db.BreakRoomDamageStatuses.Add(newStatus);
                    db.SaveChanges();
                }

                return RedirectToAction("ViewOpenTickets");
            }

            return View("ViewTicket", vehicleStatus);
        }

        public ActionResult ApproveDisapproveElevateTicketForClassRoom(ClassRoomDamageStatus vehicleStatus)
        {
            if (ModelState.IsValid)
            {
                if (vehicleStatus.Action == DamageAction.Open)
                {
                    ModelState.AddModelError("Action", "Action can not be open");
                    return View(vehicleStatus);
                }

                vehicleStatus.DateOfLeaving = DateTime.Now;
                db.Entry(vehicleStatus).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                if (vehicleStatus.Action == DamageAction.Elevate)
                {
                    ClassRoomDamageStatus newStatus = new ClassRoomDamageStatus
                    {
                        Id = Guid.NewGuid(),
                        CaseId = vehicleStatus.CaseId,
                        DateOfArrival = DateTime.Now,
                        Official = ChainOfCommandHelper.GetHigherOfficial(),
                        ClassRoomDamageId = vehicleStatus.ClassRoomDamageId
                    };
                    db.ClassRoomDamageStatuses.Add(newStatus);
                    db.SaveChanges();
                }

                return RedirectToAction("ViewOpenTickets");
            }

            return View("ViewTicket", vehicleStatus);
        }

        public ActionResult ApproveDisapproveElevateTicketForVehicle(VehicleDamageStatus vehicleStatus)
        {
            if (ModelState.IsValid)
            {
                if (vehicleStatus.Action == DamageAction.Open)
                {
                    ModelState.AddModelError("Action", "Action can not be open");
                    return View(vehicleStatus);
                }

                vehicleStatus.DateOfLeaving = DateTime.Now;
                db.Entry(vehicleStatus).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                if (vehicleStatus.Action == DamageAction.Elevate)
                {
                    VehicleDamageStatus newStatus = new VehicleDamageStatus
                    {
                        Id = Guid.NewGuid(),
                        CaseId = vehicleStatus.CaseId,
                        DateOfArrival = DateTime.Now,
                        Official = ChainOfCommandHelper.GetHigherOfficial(),
                        VehicleDamageId = vehicleStatus.VehicleDamageId
                    };
                    db.VehicleDamagesStatus.Add(newStatus);
                    db.SaveChanges();
                }

                return RedirectToAction("ViewOpenTickets");
            }

            return View("ViewTicket", vehicleStatus);
        }

        public ActionResult ApproveDisapproveElevateTicketForVehicleEquipment(VehicleEquipmentDamageStatus vehicleStatus)
        {
            if (ModelState.IsValid)
            {
                if (vehicleStatus.Action == DamageAction.Open)
                {
                    ModelState.AddModelError("Action", "Action can not be open");
                    return View(vehicleStatus);
                }

                vehicleStatus.DateOfLeaving = DateTime.Now;
                db.Entry(vehicleStatus).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                if (vehicleStatus.Action == DamageAction.Elevate)
                {
                    VehicleEquipmentDamageStatus newStatus = new VehicleEquipmentDamageStatus
                    {
                        Id = Guid.NewGuid(),
                        CaseId = vehicleStatus.CaseId,
                        DateOfArrival = DateTime.Now,
                        Official = ChainOfCommandHelper.GetHigherOfficial(),
                        VehicleEquipmentDamageId = vehicleStatus.VehicleEquipmentDamageId
                    };
                    db.VehicleEquipmentDamageStatus.Add(newStatus);
                    db.SaveChanges();
                }

                return RedirectToAction("ViewOpenTickets");
            }

            return View("ViewTicket", vehicleStatus);
        }

        public ActionResult ApproveDisapproveElevateTicketForFireExtinguishingEquipment(FireExtinguishingEquipmentDamageStatus vehicleStatus)
        {
            if (ModelState.IsValid)
            {
                if (vehicleStatus.Action == DamageAction.Open)
                {
                    ModelState.AddModelError("Action", "Action can not be open");
                    return View(vehicleStatus);
                }

                vehicleStatus.DateOfLeaving = DateTime.Now;
                db.Entry(vehicleStatus).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                if (vehicleStatus.Action == DamageAction.Elevate)
                {
                    FireExtinguishingEquipmentDamageStatus newStatus = new FireExtinguishingEquipmentDamageStatus
                    {
                        Id = Guid.NewGuid(),
                        CaseId = vehicleStatus.CaseId,
                        DateOfArrival = DateTime.Now,
                        Official = ChainOfCommandHelper.GetHigherOfficial(),
                        FireExtinguishingEquipmentDamageId = vehicleStatus.FireExtinguishingEquipmentDamageId
                    };
                    db.FireExtinguishingEquipmentDamageStatues.Add(newStatus);
                    db.SaveChanges();
                }

                return RedirectToAction("ViewOpenTickets");
            }

            return View("ViewTicket", vehicleStatus);
        }
    }
}