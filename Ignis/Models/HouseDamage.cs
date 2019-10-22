using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class HouseDamage : Damage
    {
        public HouseDamage()
        {
            HouseDamageStatues = new List<HouseDamageStatus>();
            HouseRepairs = new List<HouseRepair>();
        }

        public Guid HouseId { get; set; }
        public virtual House House { get; set; }

        public Guid HouseDamageTypeId { get; set; }
        public virtual BuildingDamageTypes HouseDamageType { get; set; }

        public virtual ICollection<HouseDamageStatus> HouseDamageStatues { get; set; }

        public virtual ICollection<HouseRepair> HouseRepairs { get; set; }
    }
}