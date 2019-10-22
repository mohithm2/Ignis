using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class VehicleEquipmentDamageStatus : DamageStatus
    {
        public VehicleEquipmentDamageStatus()
        {

        }

        public Guid VehicleEquipmentDamageId { get; set; }
        public virtual VehicleEquipmentDamage VehicleEquipmentDamage { get; set; }
    }
}