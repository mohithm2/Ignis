using Ignis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignis.Util
{
    public class TicketHelper
    {
        public static List<DamageStatus> GetDamageStatuses(string id)
        {
            List<Vehicle> vehicles = DataFilter.GetVehicles(id);
            List<DamageStatus> statuses = vehicles.SelectMany(x => x.VehicleDamages)
                .SelectMany(y => y.VehicleDamageStatuses).Cast<DamageStatus>().OrderByDescending(x => x.DateOfArrival).ToList();

            List<VehicleEquipment> vehicleEquipments = DataFilter.GetVehicleEquipments(id);
            statuses.AddRange(vehicleEquipments.SelectMany(x => x.VehicleEquipmentDamages)
                .SelectMany(y => y.VehicleEquipmentDamageStatues).Cast<DamageStatus>().OrderByDescending(x => x.DateOfArrival).ToList());

            List<FireExtinguishingEquipment> fireExtinguishingEquipments = DataFilter.GetFireExtingushingEquipments(id);
            statuses.AddRange(fireExtinguishingEquipments.SelectMany(x => x.FireExtinguishingEquipmentDamages)
                .SelectMany(y => y.FireExtinguishingEquipmentStatuses).Cast<DamageStatus>().OrderByDescending(x => x.DateOfArrival).ToList());

            List<ClassRoom> classRooms = DataFilter.GetClassRooms(id);
            statuses.AddRange(classRooms.SelectMany(x => x.ClassRoomDamages)
                .SelectMany(y => y.ClassRoomDamageStatues).Cast<DamageStatus>().OrderByDescending(x => x.DateOfArrival).ToList());

            List<BreakRoom> breakRooms = DataFilter.GetBreakRooms(id);
            statuses.AddRange(breakRooms.SelectMany(x => x.BreakRoomDamages)
                .SelectMany(y => y.BreakRoomDamageStatues).Cast<DamageStatus>().OrderByDescending(x => x.DateOfArrival).ToList());

            List<FireStation> fireStations = DataFilter.GetFireStations(id);
            statuses.AddRange(fireStations.SelectMany(x => x.FireStationDamages)
                .SelectMany(y => y.FireStationDamageStatues).Cast<DamageStatus>().OrderByDescending(x => x.DateOfArrival).ToList());

            List<House> houses = DataFilter.GetHouses(id);
            statuses.AddRange(houses.SelectMany(x => x.HouseDamages)
                .SelectMany(y => y.HouseDamageStatues).Cast<DamageStatus>().OrderByDescending(x => x.DateOfArrival).ToList());

            List<Office> offices = DataFilter.GetOffices(id);
            statuses.AddRange(offices.SelectMany(x => x.OfficeDamages)
                .SelectMany(y => y.OfficeDamageStatues).Cast<DamageStatus>().OrderByDescending(x => x.DateOfArrival).ToList());

            List<TelephoneRoom> telephoneRooms = DataFilter.GetTelephoneRooms(id);
            statuses.AddRange(telephoneRooms.SelectMany(x => x.TelephoneRoomDamages)
                .SelectMany(y => y.TelephoneRoomDamageStatues).Cast<DamageStatus>().OrderByDescending(x => x.DateOfArrival).ToList());

            return statuses;
        }
    }
}