using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class BreakRoomDamage : Damage
    {
        public BreakRoomDamage()
        {
            BreakRoomDamageStatues = new List<BreakRoomDamageStatus>();
            BreakRoomRepairs = new List<BreakRoomRepair>();
        }

        public Guid BreakRoomId { get; set; }
        public virtual BreakRoom BreakRoom { get; set; }

        public Guid BreakRoomDamageTypeId { get; set; }
        public virtual BuildingDamageTypes BreakRoomDamageType { get; set; }

        public virtual ICollection<BreakRoomDamageStatus> BreakRoomDamageStatues { get; set; }

        public virtual ICollection<BreakRoomRepair> BreakRoomRepairs { get; set; }
    }
}