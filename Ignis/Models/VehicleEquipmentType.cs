using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class VehicleEquipmentType
    {
        public VehicleEquipmentType()
        {
            VehicleEquipments = new List<VehicleEquipment>();
        }

        public Guid Id { get; set; }

        [Required]
        [DisplayName("Equipment Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Equipment Make")]
        public string Make { get; set; }

        [Required]
        [DisplayName("Equipment Model")]
        public string Model { get; set; }

        [Required]
        [Range(1000, 9999)]
        [DisplayName("Year of Manufacture")]
        public int YearOfManufacture { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Cost { get; set; }

        [Required]
        [DisplayName("Is Fuel Required")]
        public bool IsFuelRequired { get; set; }

        public virtual ICollection<VehicleEquipment> VehicleEquipments { get; set; }
    }
}