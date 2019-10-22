using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class Vehicle
    {
        public Vehicle()
        {
            TyreChanges = new List<TyreChange>();
            BatteryChanges = new List<BatteryChange>();
            OilChanges = new List<OilChange>();
            InsuranceRenewals = new List<InsuranceRenewal>();
            TaxPayments = new List<TaxPayment>();
            FittnessCertificates = new List<FittnessCertificate>();
            VehicleEquipments = new List<VehicleEquipment>();
            VehicleDamages = new List<VehicleDamage>();
        }

        public Guid Id { get; set; }

        [Required]
        [DisplayName("Vehicle Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Vehicle Make")]
        public string Make { get; set; }

        [Required]
        [DisplayName("Vehicle Model")]
        public string Model { get; set; }

        [Required]
        [DisplayName("Vehicle Registration Number")]
        public string RegistrationNumber { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Cost { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Date of Purchase")]
        public DateTime DateOfPurchase { get; set; }

        [Required]
        [DisplayName("Engine Number")]
        public string EngineNumber { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [DisplayName("Capacity of Fuel Tank")]
        public double CapacityFuelTank { get; set; }

        [Required]
        [DisplayName("Tax Card")]
        public string TaxCard { get; set; }

        [Required]
        [DisplayName("Sanction Order Number")]
        public string SanctionOrderNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Sanction Date")]
        public DateTime SanctionDate { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [DisplayName("Theoretical Mileage")]
        public double TheoreticalMileage { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [DisplayName("Kilometers Covered")]
        public double KilometersCovered { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Usage { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [DisplayName("Capacity of Attachment")]
        public double CapacityOfAttachement { get; set; }

        public string PhotoNorth { get; set; }
        public string PhotoEast { get; set; }
        public string PhotoWest { get; set; }
        public string PhotoSouth { get; set; }

        public Guid FireStationId { get; set; }
        public virtual FireStation FireStation { get; set; }
        public virtual ICollection<TyreChange> TyreChanges { get; set; }
        public virtual ICollection<BatteryChange> BatteryChanges { get; set; }
        public virtual ICollection<OilChange> OilChanges { get; set; }
        public virtual ICollection<InsuranceRenewal> InsuranceRenewals { get; set; }
        public virtual ICollection<TaxPayment> TaxPayments { get; set; }
        public virtual ICollection<FittnessCertificate> FittnessCertificates { get; set; }
        public virtual ICollection<VehicleEquipment> VehicleEquipments { get; set; }
        public virtual ICollection<VehicleDamage> VehicleDamages { get; set; }
    }
}

