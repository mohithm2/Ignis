using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class VehicleEquipmentDamage : Damage
    {
        public VehicleEquipmentDamage()
        {
            VehicleEquipmentDamageStatues = new List<VehicleEquipmentDamageStatus>();
            VehicleEquipmentRepairs = new List<VehicleEquipmentRepair>();
        }

        public Guid VehicleEquipmentId { get; set; }
        public virtual VehicleEquipment VehicleEquipment { get; set; }

        public Guid VehicleEquipmentDamageTypeId { get; set; }
        public virtual VehicleEquipmentDamageType VehicleEquipmentDamageType { get; set; }

        public virtual ICollection<VehicleEquipmentDamageStatus> VehicleEquipmentDamageStatues { get; set; }

        public virtual ICollection<VehicleEquipmentRepair> VehicleEquipmentRepairs { get; set; }
    }
}