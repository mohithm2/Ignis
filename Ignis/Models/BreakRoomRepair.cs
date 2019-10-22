using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class BreakRoomRepair : Repair
    {
        public BreakRoomRepair()
        {

        }

        public Guid BreakRoomDamageId { get; set; }

        public BreakRoomDamage BreakRoomDamage { get; set; }
    }
}