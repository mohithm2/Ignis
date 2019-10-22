using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class FireExtinguishingEquipmentType
    {
        public FireExtinguishingEquipmentType()
        {
            FireExtinguishingEquipments = new List<FireExtinguishingEquipment>();
        }

        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        [Range(1000, 9999)]
        public int YearOfManufacture { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public double Cost { get; set; }
        [Required]
        public bool IsFuelRequired { get; set; }

        public virtual ICollection<FireExtinguishingEquipment> FireExtinguishingEquipments { get; set; }
    }
}