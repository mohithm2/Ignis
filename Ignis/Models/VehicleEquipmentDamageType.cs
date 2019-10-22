using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class VehicleEquipmentDamageType : DamageType
    {
        public VehicleEquipmentDamageType()
        {
            VehicleEquipmentDamages = new List<VehicleEquipmentDamage>();
        }

        public virtual ICollection<VehicleEquipmentDamage> VehicleEquipmentDamages { get; set; }
    }
}