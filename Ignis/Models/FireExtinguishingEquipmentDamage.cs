using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class FireExtinguishingEquipmentDamage : Damage
    {
        public FireExtinguishingEquipmentDamage()
        {
            FireExtinguishingEquipmentStatuses = new List<FireExtinguishingEquipmentDamageStatus>();
            FireExtinguishingEquipmentRepairs = new List<FireExtinguishingEquipmentRepair>();
        }

        public Guid FireExtinguishingEquipmentId { get; set; }
        public virtual FireExtinguishingEquipment FireExtinguishingEquipment { get; set; }

        public Guid FireExtinguishingEquipmentDamageTypeId { get; set; }
        public virtual FireExtinguishingEquipmentDamageType FireExtinguishingEquipmentDamageType { get; set; }

        public virtual ICollection<FireExtinguishingEquipmentDamageStatus> FireExtinguishingEquipmentStatuses { get; set; }
        public virtual ICollection<FireExtinguishingEquipmentRepair> FireExtinguishingEquipmentRepairs { get; set; }
    }
}