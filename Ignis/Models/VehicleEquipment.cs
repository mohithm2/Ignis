using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public enum VehicleEquipementStatus
    {
        UnderConstruction, Operational, ConstructedNonOperational, UnderRenovationOperational,
        UnderRenovationNonOperational
    }
    public class VehicleEquipment
    {
        public VehicleEquipment()
        {
            VehicleEquipmentDamages = new List<VehicleEquipmentDamage>();
        }

        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Date of Purchase")]
        public DateTime DateofPurchase { get; set; }

        [Required]
        public VehicleEquipementStatus Status { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        public Guid VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public Guid VehicleEquipmentTypeId { get; set; }
        public virtual VehicleEquipmentType VehicleEquipmentType { get; set; }

        public virtual ICollection<VehicleEquipmentDamage> VehicleEquipmentDamages { get; set; }
    }
}