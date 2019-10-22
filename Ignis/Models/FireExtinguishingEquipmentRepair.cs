using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class FireExtinguishingEquipmentRepair : Repair
    {
        public FireExtinguishingEquipmentRepair()
        {

        }

        public Guid FireExtinguishingEquipmentDamageId { get; set; }
        public virtual FireExtinguishingEquipmentDamage FireExtinguishingEquipmentDamage { get; set; }
    }
}