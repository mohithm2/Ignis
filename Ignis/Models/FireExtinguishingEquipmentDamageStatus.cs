using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class FireExtinguishingEquipmentDamageStatus : DamageStatus
    {
        public FireExtinguishingEquipmentDamageStatus()
        {

        }

        public Guid FireExtinguishingEquipmentDamageId { get; set; }
        public virtual FireExtinguishingEquipmentDamage FireExtinguishingEquipmentDamage { get; set; }
    }
}