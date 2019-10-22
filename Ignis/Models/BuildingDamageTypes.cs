using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class BuildingDamageTypes : DamageType
    {
        public BuildingDamageTypes()
        {
            ClassRoomDamages = new List<ClassRoomDamage>();
        }

        public virtual ICollection<ClassRoomDamage> ClassRoomDamages { get; set; }

    }
}