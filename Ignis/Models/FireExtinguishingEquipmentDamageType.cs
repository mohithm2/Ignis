using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class FireExtinguishingEquipmentDamageType : DamageType
    {
        public FireExtinguishingEquipmentDamageType()
        {
            FireExtinguishingEquipmentDamages = new List<FireExtinguishingEquipmentDamage>();
        }

        public virtual ICollection<FireExtinguishingEquipmentDamage> FireExtinguishingEquipmentDamages { get; set; }
    }
}