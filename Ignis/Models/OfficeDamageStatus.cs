using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class OfficeDamageStatus : DamageStatus
    {
        public OfficeDamageStatus()
        {

        }

        public Guid OfficeDamageId { get; set; }
        public virtual OfficeDamage OfficeDamage { get; set; }
    }
}