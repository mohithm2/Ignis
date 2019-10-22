using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class TelephoneRoomRepair : Repair
    {
        public TelephoneRoomRepair()
        {

        }

        public Guid TelephoneRoomDamageId { get; set; }

        public TelephoneRoomDamage TelephoneRoomDamage { get; set; }
    }
}