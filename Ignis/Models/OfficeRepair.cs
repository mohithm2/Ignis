using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class OfficeRepair : Repair
    {
        public OfficeRepair()
        {

        }

        public Guid OfficeDamageId { get; set; }

        public OfficeDamage OfficeDamage { get; set; }
    }
}