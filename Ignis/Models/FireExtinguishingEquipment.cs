using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public enum FireExtinguishingEquipmentStatus
    {
        UnderConstruction, Operational, ConstructedNonOperational, UnderRenovationOperational,
        UnderRenovationNonOperational
    }

    public class FireExtinguishingEquipment
    {
        public FireExtinguishingEquipment()
        {
            FireExtinguishingEquipmentDamages = new List<FireExtinguishingEquipmentDamage>();
        }

        public Guid Id { get; set; }

        [Required]
        [DisplayName("Date of Purchase")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateofPurchase { get; set; }

        [Required]
        public FireExtinguishingEquipmentStatus Status { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        public Guid FireExtinguishingEquipmentTypeId { get; set; }
        public virtual FireExtinguishingEquipmentType FireExtinguishingEquipmentType { get; set; }

        public Guid FireStationId { get; set; }
        public virtual FireStation FireStation { get; set; }

        public virtual ICollection<FireExtinguishingEquipmentDamage> FireExtinguishingEquipmentDamages { get; set; }
    }
}