using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class BreakRoomDamageStatus : DamageStatus
    {
        public BreakRoomDamageStatus()
        {

        }

        public Guid BreakRoomDamageId { get; set; }
        public virtual BreakRoomDamage BreakRoomDamage { get; set; }
    }
}