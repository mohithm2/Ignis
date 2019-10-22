namespace Ignis.DAL
{
    using Ignis.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class IgnisModel : DbContext
    {
        public IgnisModel()
            : base("name=IgnisModel")
        {
        }

        public virtual DbSet<Zone> Zones { get; set; }
        public virtual DbSet<Range> Ranges { get; set; }
        public virtual DbSet<ZoneRange> ZoneRanges { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.District> Districts { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.RangeDistrict> RangeDistricts { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.Taluk> Taluks { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.Hobli> Hoblis { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.FireStation> FireStations { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.Vehicle> Vehicles { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.TyreChange> TyreChanges { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.BatteryChange> BatteryChanges { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.OilType> OilTypes { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.OilChange> OilChanges { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.InsuranceRenewal> InsuranceRenewals { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.TaxPayment> TaxPayments { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.FittnessCertificate> FittnessCertificates { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.VehicleEquipmentType> VehicleEquipmentTypes { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.VehicleEquipment> VehicleEquipments { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.FireExtinguishingEquipmentType> FireExtinguishingEquipmentTypes { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.FireExtinguishingEquipment> FireExtinguishingEquipments { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.Office> Offices { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.BreakRoom> BreakRooms { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.ClassRoom> ClassRooms { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.TelephoneRoom> TelephoneRooms { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.ResidentialQuarter> ResidentialQuarters { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.House> Houses { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.Group> Groups { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.Rank> Ranks { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.WorksFor> WorksFors { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.Vacancy> Vacancies { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.Count> Counts { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.Land> Lands { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.RequiredLand> RequiredLands { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.VehicleDamageType> VehicleDamageTypes { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.VehicleDamage> VehicleDamages { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.VehicleEquipmentDamage> VehicleEquipmentDamages { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.Damage> Damages { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.DamageStatus> DamageStatuses { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.Repair> Repairs { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.DamageType> DamageTypes { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.VehicleDamageStatus> VehicleDamagesStatus { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.VehicleRepair> VehicleRepairs { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.VehicleEquipmentDamageType> VehicleEquipmentDamageTypes { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.VehicleEquipmentDamageStatus> VehicleEquipmentDamageStatus { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.VehicleEquipmentRepair> VehicleEquipmentRepairs { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.FireExtinguishingEquipmentDamageType> FireExtinguishingEquipmentDamageTypes { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.FireExtinguishingEquipmentDamage> FireExtinguishingEquipmentDamages { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.FireExtinguishingEquipmentDamageStatus> FireExtinguishingEquipmentDamageStatues { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.FireExtinguishingEquipmentRepair> FireExtinguishingEquipmentRepairs { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.WaterSource> WaterSources { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.BuildingDamageTypes> BuildingDamageTypes { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.ClassRoomDamage> ClassRoomDamages { get; set; }
        public System.Data.Entity.DbSet<Ignis.Models.ClassRoomDamageStatus> ClassRoomDamageStatuses { get; set; }
        public System.Data.Entity.DbSet<Ignis.Models.ClassRoomRepair> ClassRoomRepairs { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.BreakRoomDamage> BreakRoomDamages { get; set; }
        public System.Data.Entity.DbSet<Ignis.Models.BreakRoomDamageStatus> BreakRoomDamageStatuses { get; set; }
        public System.Data.Entity.DbSet<Ignis.Models.BreakRoomRepair> BreakRoomRepairs { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.FireStationDamage> FireStationDamages { get; set; }
        public System.Data.Entity.DbSet<Ignis.Models.FireStationDamageStatus> FireStationDamageStatuses { get; set; }
        public System.Data.Entity.DbSet<Ignis.Models.FireStationRepair> FireStationRepairs { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.HouseDamage> HouseDamages { get; set; }
        public System.Data.Entity.DbSet<Ignis.Models.HouseDamageStatus> HouseDamageStatuses { get; set; }
        public System.Data.Entity.DbSet<Ignis.Models.HouseRepair> HouseRepairs { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.OfficeDamage> OfficeDamages { get; set; }
        public System.Data.Entity.DbSet<Ignis.Models.OfficeDamageStatus> OfficeDamageStatuses { get; set; }
        public System.Data.Entity.DbSet<Ignis.Models.OfficeRepair> OfficeRepairs { get; set; }

        public System.Data.Entity.DbSet<Ignis.Models.TelephoneRoomDamage> TelephoneRoomDamages { get; set; }
        public System.Data.Entity.DbSet<Ignis.Models.TelephoneRoomDamageStatus> TelephoneRoomDamageStatuses { get; set; }
        public System.Data.Entity.DbSet<Ignis.Models.TelephoneRoomRepair> TelephoneRoomRepairs { get; set; }
    }
}

