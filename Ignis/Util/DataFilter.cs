
using Ignis.DAL;
using Ignis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignis.Util
{
    public class DataFilter
    {

        public static List<FireStation> GetFireStations(string id)
        {
            IgnisModel db = new IgnisModel();
            List<FireStation> list = null;

            if (HttpContext.Current.User.IsInRole("cfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.FireStations.Where(x => x.Id == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("dfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.FireStations.Where(x => x.Hobli.Taluk.DistrictId == districtId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("rfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.FireStations.Where(x => x.Hobli.Taluk.District.RangeDistricts.Where(y => y.RangeId == districtId).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("zfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.FireStations.Where(x => x.Hobli.Taluk.District.RangeDistricts.Where(y => y.Range.ZoneRanges.Where(z => z.ZoneId == districtId).Count() > 0).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("ig") || HttpContext.Current.User.IsInRole("admin"))
            {
                list = db.FireStations.ToList();
            }

            return list;
        }

        public static List<ResidentialQuarter> GetResidentialQuarters(string id)
        {
            IgnisModel db = new IgnisModel();
            List<ResidentialQuarter> list = null;

            if (HttpContext.Current.User.IsInRole("cfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.ResidentialQuarters.Where(x => x.FireStationId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("dfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.ResidentialQuarters.Where(x => x.FireStation.Hobli.Taluk.DistrictId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("rfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.ResidentialQuarters.Where(x => x.FireStation.Hobli.Taluk.District.RangeDistricts.Where(y => y.RangeId == districtId).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("zfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.ResidentialQuarters.Where(x => x.FireStation.Hobli.Taluk.District.RangeDistricts.Where(y => y.Range.ZoneRanges.Where(z => z.ZoneId == districtId).Count() > 0).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("ig") || HttpContext.Current.User.IsInRole("admin"))
            {
                list = db.ResidentialQuarters.ToList();
            }

            return list;
        }

        public static List<Land> GetLands(string id)
        {
            IgnisModel db = new IgnisModel();
            List<Land> list = null;

            if (HttpContext.Current.User.IsInRole("cfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.Lands.Where(x => x.FireStationId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("dfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.Lands.Where(x => x.FireStation.Hobli.Taluk.DistrictId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("rfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.Lands.Where(x => x.FireStation.Hobli.Taluk.District.RangeDistricts.Where(y => y.RangeId == districtId).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("zfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.Lands.Where(x => x.FireStation.Hobli.Taluk.District.RangeDistricts.Where(y => y.Range.ZoneRanges.Where(z => z.ZoneId == districtId).Count() > 0).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("ig") || HttpContext.Current.User.IsInRole("admin"))
            {
                list = db.Lands.ToList();
            }

            return list;
        }

        public static List<RequiredLand> GetRequiredLands(string id)
        {
            IgnisModel db = new IgnisModel();
            List<RequiredLand> list = null;

            if (HttpContext.Current.User.IsInRole("cfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.RequiredLands.Where(x => x.FireStationId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("dfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.RequiredLands.Where(x => x.FireStation.Hobli.Taluk.DistrictId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("rfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.RequiredLands.Where(x => x.FireStation.Hobli.Taluk.District.RangeDistricts.Where(y => y.RangeId == districtId).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("zfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.RequiredLands.Where(x => x.FireStation.Hobli.Taluk.District.RangeDistricts.Where(y => y.Range.ZoneRanges.Where(z => z.ZoneId == districtId).Count() > 0).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("ig") || HttpContext.Current.User.IsInRole("admin"))
            {
                list = db.RequiredLands.ToList();
            }

            return list;
        }

        public static List<House> GetHouses(string id)
        {
            IgnisModel db = new IgnisModel();
            List<House> list = null;

            if (HttpContext.Current.User.IsInRole("cfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.Houses.Where(x => x.ResidentialQuarter.FireStationId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("dfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.Houses.Where(x => x.ResidentialQuarter.FireStation.Hobli.Taluk.DistrictId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("rfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.Houses.Where(x => x.ResidentialQuarter.FireStation.Hobli.Taluk.District.RangeDistricts.Where(y => y.RangeId == districtId).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("zfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.Houses.Where(x => x.ResidentialQuarter.FireStation.Hobli.Taluk.District.RangeDistricts.Where(y => y.Range.ZoneRanges.Where(z => z.ZoneId == districtId).Count() > 0).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("ig") || HttpContext.Current.User.IsInRole("admin"))
            {
                list = db.Houses.ToList();
            }

            return list;
        }

        public static List<TelephoneRoom> GetTelephoneRooms(string id)
        {
            IgnisModel db = new IgnisModel();
            List<TelephoneRoom> list = null;

            if (HttpContext.Current.User.IsInRole("cfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.TelephoneRooms.Where(x => x.FireStationId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("dfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.TelephoneRooms.Where(x => x.FireStation.Hobli.Taluk.DistrictId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("rfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.TelephoneRooms.Where(x => x.FireStation.Hobli.Taluk.District.RangeDistricts.Where(y => y.RangeId == districtId).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("zfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.TelephoneRooms.Where(x => x.FireStation.Hobli.Taluk.District.RangeDistricts.Where(y => y.Range.ZoneRanges.Where(z => z.ZoneId == districtId).Count() > 0).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("ig") || HttpContext.Current.User.IsInRole("admin"))
            {
                list = db.TelephoneRooms.ToList();
            }

            return list;
        }

        public static List<BreakRoom> GetBreakRooms(string id)
        {
            IgnisModel db = new IgnisModel();
            List<BreakRoom> list = null;

            if (HttpContext.Current.User.IsInRole("cfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.BreakRooms.Where(x => x.FireStationId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("dfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.BreakRooms.Where(x => x.FireStation.Hobli.Taluk.DistrictId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("rfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.BreakRooms.Where(x => x.FireStation.Hobli.Taluk.District.RangeDistricts.Where(y => y.RangeId == districtId).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("zfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.BreakRooms.Where(x => x.FireStation.Hobli.Taluk.District.RangeDistricts.Where(y => y.Range.ZoneRanges.Where(z => z.ZoneId == districtId).Count() > 0).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("ig") || HttpContext.Current.User.IsInRole("admin"))
            {
                list = db.BreakRooms.ToList();
            }

            return list;
        }

        public static List<ClassRoom> GetClassRooms(string id)
        {
            IgnisModel db = new IgnisModel();
            List<ClassRoom> list = null;

            if (HttpContext.Current.User.IsInRole("cfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.ClassRooms.Where(x => x.FireStationId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("dfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.ClassRooms.Where(x => x.FireStation.Hobli.Taluk.DistrictId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("rfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.ClassRooms.Where(x => x.FireStation.Hobli.Taluk.District.RangeDistricts.Where(y => y.RangeId == districtId).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("zfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.ClassRooms.Where(x => x.FireStation.Hobli.Taluk.District.RangeDistricts.Where(y => y.Range.ZoneRanges.Where(z => z.ZoneId == districtId).Count() > 0).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("ig") || HttpContext.Current.User.IsInRole("admin"))
            {
                list = db.ClassRooms.ToList();
            }

            return list;
        }

        public static List<WaterSource> GetWaterSources(string id)
        {
            IgnisModel db = new IgnisModel();
            List<WaterSource> list = null;

            if (HttpContext.Current.User.IsInRole("cfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.WaterSources.Where(x => x.FireStationId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("dfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.WaterSources.Where(x => x.FireStation.Hobli.Taluk.DistrictId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("rfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.WaterSources.Where(x => x.FireStation.Hobli.Taluk.District.RangeDistricts.Where(y => y.RangeId == districtId).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("zfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.WaterSources.Where(x => x.FireStation.Hobli.Taluk.District.RangeDistricts.Where(y => y.Range.ZoneRanges.Where(z => z.ZoneId == districtId).Count() > 0).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("ig") || HttpContext.Current.User.IsInRole("admin"))
            {
                list = db.WaterSources.ToList();
            }

            return list;
        }

        public static List<Office> GetOffices(string id)
        {
            IgnisModel db = new IgnisModel();
            List<Office> list = null;

            if (HttpContext.Current.User.IsInRole("cfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.Offices.Where(x => x.FireStationId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("dfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.Offices.Where(x => x.FireStation.Hobli.Taluk.DistrictId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("rfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.Offices.Where(x => x.FireStation.Hobli.Taluk.District.RangeDistricts.Where(y => y.RangeId == districtId).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("zfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.Offices.Where(x => x.FireStation.Hobli.Taluk.District.RangeDistricts.Where(y => y.Range.ZoneRanges.Where(z => z.ZoneId == districtId).Count() > 0).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("ig") || HttpContext.Current.User.IsInRole("admin"))
            {
                list = db.Offices.ToList();
            }

            return list;
        }

        public static List<Employee> GetEmployees(string id)
        {
            IgnisModel db = new IgnisModel();
            List<Employee> list = null;

            if (HttpContext.Current.User.IsInRole("cfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.Employees.Where(x => x.FireStationId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("dfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.Employees.Where(x => x.FireStation.Hobli.Taluk.DistrictId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("rfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.Employees.Where(x => x.FireStation.Hobli.Taluk.District.RangeDistricts.Where(y => y.RangeId == districtId).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("zfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.Employees.Where(x => x.FireStation.Hobli.Taluk.District.RangeDistricts.Where(y => y.Range.ZoneRanges.Where(z => z.ZoneId == districtId).Count() > 0).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("ig") || HttpContext.Current.User.IsInRole("admin"))
            {
                list = db.Employees.ToList();
            }

            return list;
        }

        public static List<FireExtinguishingEquipment> GetFireExtingushingEquipments(string id)
        {
            IgnisModel db = new IgnisModel();
            List<FireExtinguishingEquipment> list = null;

            if (HttpContext.Current.User.IsInRole("cfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.FireExtinguishingEquipments.Where(x => x.FireStationId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("dfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.FireExtinguishingEquipments.Where(x => x.FireStation.Hobli.Taluk.DistrictId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("rfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.FireExtinguishingEquipments.Where(x => x.FireStation.Hobli.Taluk.District.RangeDistricts.Where(y => y.RangeId == districtId).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("zfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.FireExtinguishingEquipments.Where(x => x.FireStation.Hobli.Taluk.District.RangeDistricts.Where(y => y.Range.ZoneRanges.Where(z => z.ZoneId == districtId).Count() > 0).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("ig") || HttpContext.Current.User.IsInRole("admin"))
            {
                list = db.FireExtinguishingEquipments.ToList();
            }

            return list;
        }

        public static List<Vehicle> GetVehicles(string id)
        {
            IgnisModel db = new IgnisModel();
            List<Vehicle> list = null;

            if (HttpContext.Current.User.IsInRole("cfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.Vehicles.Where(x => x.FireStationId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("dfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.Vehicles.Where(x => x.FireStation.Hobli.Taluk.DistrictId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("rfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.Vehicles.Where(x => x.FireStation.Hobli.Taluk.District.RangeDistricts.Where(y => y.RangeId == districtId).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("zfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.Vehicles.Where(x => x.FireStation.Hobli.Taluk.District.RangeDistricts.Where(y => y.Range.ZoneRanges.Where(z => z.ZoneId == districtId).Count() > 0).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("ig") || HttpContext.Current.User.IsInRole("admin"))
            {
                list = db.Vehicles.ToList();
            }

            return list;
        }

        public static List<VehicleEquipment> GetVehicleEquipments(string id)
        {
            IgnisModel db = new IgnisModel();
            List<VehicleEquipment> list = null;

            if (HttpContext.Current.User.IsInRole("cfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.VehicleEquipments.Where(x => x.Vehicle.FireStationId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("dfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.VehicleEquipments.Where(x => x.Vehicle.FireStation.Hobli.Taluk.DistrictId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("rfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.VehicleEquipments.Where(x => x.Vehicle.FireStation.Hobli.Taluk.District.RangeDistricts.Where(y => y.RangeId == districtId).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("zfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.VehicleEquipments.Where(x => x.Vehicle.FireStation.Hobli.Taluk.District.RangeDistricts.Where(y => y.Range.ZoneRanges.Where(z => z.ZoneId == districtId).Count() > 0).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("ig") || HttpContext.Current.User.IsInRole("admin"))
            {
                list = db.VehicleEquipments.ToList();
            }

            return list;
        }

        public static List<TyreChange> GetTyreChanges(string id)
        {
            IgnisModel db = new IgnisModel();
            List<TyreChange> list = null;

            if (HttpContext.Current.User.IsInRole("cfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.TyreChanges.Where(x => x.Vehicle.FireStationId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("dfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.TyreChanges.Where(x => x.Vehicle.FireStation.Hobli.Taluk.DistrictId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("rfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.TyreChanges.Where(x => x.Vehicle.FireStation.Hobli.Taluk.District.RangeDistricts.Where(y => y.RangeId == districtId).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("zfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.TyreChanges.Where(x => x.Vehicle.FireStation.Hobli.Taluk.District.RangeDistricts.Where(y => y.Range.ZoneRanges.Where(z => z.ZoneId == districtId).Count() > 0).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("ig") || HttpContext.Current.User.IsInRole("admin"))
            {
                list = db.TyreChanges.ToList();
            }

            return list;
        }

        public static List<TaxPayment> GetTaxPayments(string id)
        {
            IgnisModel db = new IgnisModel();
            List<TaxPayment> list = null;

            if (HttpContext.Current.User.IsInRole("cfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.TaxPayments.Where(x => x.Vehicle.FireStationId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("dfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.TaxPayments.Where(x => x.Vehicle.FireStation.Hobli.Taluk.DistrictId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("rfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.TaxPayments.Where(x => x.Vehicle.FireStation.Hobli.Taluk.District.RangeDistricts.Where(y => y.RangeId == districtId).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("zfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.TaxPayments.Where(x => x.Vehicle.FireStation.Hobli.Taluk.District.RangeDistricts.Where(y => y.Range.ZoneRanges.Where(z => z.ZoneId == districtId).Count() > 0).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("ig") || HttpContext.Current.User.IsInRole("admin"))
            {
                list = db.TaxPayments.ToList();
            }

            return list;
        }

        public static List<OilChange> GetOilChanges(string id)
        {
            IgnisModel db = new IgnisModel();
            List<OilChange> list = null;

            if (HttpContext.Current.User.IsInRole("cfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.OilChanges.Where(x => x.Vehicle.FireStationId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("dfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.OilChanges.Where(x => x.Vehicle.FireStation.Hobli.Taluk.DistrictId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("rfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.OilChanges.Where(x => x.Vehicle.FireStation.Hobli.Taluk.District.RangeDistricts.Where(y => y.RangeId == districtId).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("zfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.OilChanges.Where(x => x.Vehicle.FireStation.Hobli.Taluk.District.RangeDistricts.Where(y => y.Range.ZoneRanges.Where(z => z.ZoneId == districtId).Count() > 0).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("ig") || HttpContext.Current.User.IsInRole("admin"))
            {
                list = db.OilChanges.ToList();
            }

            return list;
        }

        public static List<InsuranceRenewal> GetInsuranceRenewals(string id)
        {
            IgnisModel db = new IgnisModel();
            List<InsuranceRenewal> list = null;

            if (HttpContext.Current.User.IsInRole("cfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.InsuranceRenewals.Where(x => x.Vehicle.FireStationId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("dfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.InsuranceRenewals.Where(x => x.Vehicle.FireStation.Hobli.Taluk.DistrictId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("rfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.InsuranceRenewals.Where(x => x.Vehicle.FireStation.Hobli.Taluk.District.RangeDistricts.Where(y => y.RangeId == districtId).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("zfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.InsuranceRenewals.Where(x => x.Vehicle.FireStation.Hobli.Taluk.District.RangeDistricts.Where(y => y.Range.ZoneRanges.Where(z => z.ZoneId == districtId).Count() > 0).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("ig") || HttpContext.Current.User.IsInRole("admin"))
            {
                list = db.InsuranceRenewals.ToList();
            }

            return list;
        }

        public static List<BatteryChange> GetBatteryChanges(string id)
        {
            IgnisModel db = new IgnisModel();
            List<BatteryChange> list = null;

            if (HttpContext.Current.User.IsInRole("cfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.BatteryChanges.Where(x => x.Vehicle.FireStationId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("dfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.BatteryChanges.Where(x => x.Vehicle.FireStation.Hobli.Taluk.DistrictId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("rfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.BatteryChanges.Where(x => x.Vehicle.FireStation.Hobli.Taluk.District.RangeDistricts.Where(y => y.RangeId == districtId).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("zfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.BatteryChanges.Where(x => x.Vehicle.FireStation.Hobli.Taluk.District.RangeDistricts.Where(y => y.Range.ZoneRanges.Where(z => z.ZoneId == districtId).Count() > 0).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("ig") || HttpContext.Current.User.IsInRole("admin"))
            {
                list = db.BatteryChanges.ToList();
            }

            return list;
        }

        public static List<FittnessCertificate> GetFittnessCertificates(string id)
        {
            IgnisModel db = new IgnisModel();
            List<FittnessCertificate> list = null;

            if (HttpContext.Current.User.IsInRole("cfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.FittnessCertificates.Where(x => x.Vehicle.FireStationId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("dfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.FittnessCertificates.Where(x => x.Vehicle.FireStation.Hobli.Taluk.DistrictId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("rfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.FittnessCertificates.Where(x => x.Vehicle.FireStation.Hobli.Taluk.District.RangeDistricts.Where(y => y.RangeId == districtId).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("zfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.FittnessCertificates.Where(x => x.Vehicle.FireStation.Hobli.Taluk.District.RangeDistricts.Where(y => y.Range.ZoneRanges.Where(z => z.ZoneId == districtId).Count() > 0).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("ig") || HttpContext.Current.User.IsInRole("admin"))
            {
                list = db.FittnessCertificates.ToList();
            }

            return list;
        }


        public static List<Hobli> GetHoblis(string id)
        {
            IgnisModel db = new IgnisModel();
            List<Hobli> list = null;

            if (HttpContext.Current.User.IsInRole("dfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.Hoblis.Where(x => x.Taluk.DistrictId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("rfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.Hoblis.Where(x => x.Taluk.District.RangeDistricts.Where(y => y.RangeId == fireStationId).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("zfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.Hoblis.Where(x => x.Taluk.District.RangeDistricts.Where(y => y.Range.ZoneRanges.Where(z => z.ZoneId == districtId).Count() > 0).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("ig") || HttpContext.Current.User.IsInRole("admin"))
            {
                list = db.Hoblis.ToList();
            }

            return list;
        }

        public static List<Taluk> GetTaluks(string id)
        {
            IgnisModel db = new IgnisModel();
            List<Taluk> list = null;

            if (HttpContext.Current.User.IsInRole("dfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.Taluks.Where(x => x.DistrictId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("rfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.Taluks.Where(x => x.District.RangeDistricts.Where(y => y.RangeId == fireStationId).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("zfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.Taluks.Where(x => x.District.RangeDistricts.Where(y => y.Range.ZoneRanges.Where(z => z.ZoneId == districtId).Count() > 0).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("ig") || HttpContext.Current.User.IsInRole("admin"))
            {
                list = db.Taluks.ToList();
            }

            return list;
        }

        public static List<District> GetDistricts(string id)
        {
            IgnisModel db = new IgnisModel();
            List<District> list = null;

            if (HttpContext.Current.User.IsInRole("dfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.Districts.Where(x => x.Id == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("rfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.Districts.Where(x => x.RangeDistricts.Where(y => y.RangeId == fireStationId).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("zfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.Districts.Where(x => x.RangeDistricts.Where(y => y.Range.ZoneRanges.Where(z => z.ZoneId == districtId).Count() > 0).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("ig") || HttpContext.Current.User.IsInRole("admin"))
            {
                list = db.Districts.ToList();
            }

            return list;
        }

        public static List<RangeDistrict> GetRangeDistricts(string id)
        {
            IgnisModel db = new IgnisModel();
            List<RangeDistrict> list = null;

            if (HttpContext.Current.User.IsInRole("rfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.RangeDistricts.Where(x => x.RangeId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("zfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.RangeDistricts.Where(x => x.Range.ZoneRanges.Where(z => z.ZoneId == districtId).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("ig") || HttpContext.Current.User.IsInRole("admin"))
            {
                list = db.RangeDistricts.ToList();
            }

            return list;
        }

        public static List<Range> GetRanges(string id)
        {
            IgnisModel db = new IgnisModel();
            List<Range> list = null;

            if (HttpContext.Current.User.IsInRole("rfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.Ranges.Where(x => x.Id == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("zfo"))
            {
                Guid districtId = Guid.Parse(id);
                list = db.Ranges.Where(x => x.ZoneRanges.Where(z => z.ZoneId == districtId).Count() > 0).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("ig") || HttpContext.Current.User.IsInRole("admin"))
            {
                list = db.Ranges.ToList();
            }

            return list;
        }

        public static List<ZoneRange> GetZoneRanges(string id)
        {
            IgnisModel db = new IgnisModel();
            List<ZoneRange> list = null;

            if (HttpContext.Current.User.IsInRole("zfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.ZoneRanges.Where(x => x.ZoneId == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("ig") || HttpContext.Current.User.IsInRole("admin"))
            {
                list = db.ZoneRanges.ToList();
            }

            return list;
        }

        public static List<Zone> GetZones(string id)
        {
            IgnisModel db = new IgnisModel();
            List<Zone> list = null;

            if (HttpContext.Current.User.IsInRole("zfo"))
            {
                Guid fireStationId = Guid.Parse(id);
                list = db.Zones.Where(x => x.Id == fireStationId).ToList();
            }
            else if (HttpContext.Current.User.IsInRole("ig") || HttpContext.Current.User.IsInRole("admin"))
            {
                list = db.Zones.ToList();
            }

            return list;
        }
    }
}