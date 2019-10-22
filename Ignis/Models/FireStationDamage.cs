using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class FireStationDamage : Damage
    {
        public FireStationDamage()
        {
            FireStationDamageStatues = new List<FireStationDamageStatus>();
            FireStationRepairs = new List<FireStationRepair>();
        }

        public Guid FireStationId { get; set; }
        public virtual FireStation FireStation { get; set; }

        public Guid FireStationDamageTypeId { get; set; }
        public virtual BuildingDamageTypes FireStationDamageType { get; set; }

        public virtual ICollection<FireStationDamageStatus> FireStationDamageStatues { get; set; }

        public virtual ICollection<FireStationRepair> FireStationRepairs { get; set; }
    }
}