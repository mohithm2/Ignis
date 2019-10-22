using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class ClassRoomDamageStatus : DamageStatus
    {
        public ClassRoomDamageStatus()
        {

        }

        public Guid ClassRoomDamageId { get; set; }
        public virtual ClassRoomDamage ClassRoomDamage { get; set; }
    }
}