using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class TelephoneRoomDamage : Damage
    {
        public TelephoneRoomDamage()
        {
            TelephoneRoomDamageStatues = new List<TelephoneRoomDamageStatus>();
            TelephoneRoomRepairs = new List<TelephoneRoomRepair>();
        }

        public Guid TelephoneRoomId { get; set; }
        public virtual TelephoneRoom TelephoneRoom { get; set; }

        public Guid TelephoneRoomDamageTypeId { get; set; }
        public virtual BuildingDamageTypes TelephoneRoomDamageType { get; set; }

        public virtual ICollection<TelephoneRoomDamageStatus> TelephoneRoomDamageStatues { get; set; }

        public virtual ICollection<TelephoneRoomRepair> TelephoneRoomRepairs { get; set; }
    }
}