using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class TelephoneRoomDamageStatus : DamageStatus
    {
        public TelephoneRoomDamageStatus()
        {

        }

        public Guid TelephoneRoomDamageId { get; set; }
        public virtual TelephoneRoomDamage TelephoneRoomDamage { get; set; }
    }
}