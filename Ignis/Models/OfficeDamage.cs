using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class OfficeDamage : Damage
    {
        public OfficeDamage()
        {
            OfficeDamageStatues = new List<OfficeDamageStatus>();
            OfficeRepairs = new List<OfficeRepair>();
        }

        public Guid OfficeId { get; set; }
        public virtual Office Office { get; set; }

        public Guid OfficeDamageTypeId { get; set; }
        public virtual BuildingDamageTypes OfficeDamageType { get; set; }

        public virtual ICollection<OfficeDamageStatus> OfficeDamageStatues { get; set; }

        public virtual ICollection<OfficeRepair> OfficeRepairs { get; set; }
    }
}