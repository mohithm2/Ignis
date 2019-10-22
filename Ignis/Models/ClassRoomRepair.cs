using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class ClassRoomRepair : Repair
    {
        public ClassRoomRepair()
        {

        }

        public Guid ClassRoomDamageId { get; set; }

        public ClassRoomDamage ClassRoomDamage { get; set; }
    }
}