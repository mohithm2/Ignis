using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class ClassRoomDamage : Damage
    {
        public ClassRoomDamage()
        {
            ClassRoomDamageStatues = new List<ClassRoomDamageStatus>();
            ClassRoomRepairs = new List<ClassRoomRepair>();
        }

        public Guid ClassRoomId { get; set; }
        public virtual ClassRoom ClassRoom { get; set; }

        public Guid ClassRoomDamageTypeId { get; set; }
        public virtual BuildingDamageTypes ClassRoomDamageType { get; set; }

        public virtual ICollection<ClassRoomDamageStatus> ClassRoomDamageStatues { get; set; }

        public virtual ICollection<ClassRoomRepair> ClassRoomRepairs { get; set; }
    }
}