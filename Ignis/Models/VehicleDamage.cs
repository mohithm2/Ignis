using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class VehicleDamage : Damage
    {
        public VehicleDamage()
        {
            VehicleDamageStatuses = new List<VehicleDamageStatus>();
            VehicleRepairs = new List<VehicleRepair>();
        }

        [Required]
        [Range(0, double.MaxValue)]
        public double OdometerReading { get; set; }

        public Guid VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        public Guid VehicleDamageTypeId { get; set; }
        public virtual VehicleDamageType VehicleDamageType { get; set; }

        public virtual ICollection<VehicleDamageStatus> VehicleDamageStatuses { get; set; }

        public virtual ICollection<VehicleRepair> VehicleRepairs { get; set; }
    }
}