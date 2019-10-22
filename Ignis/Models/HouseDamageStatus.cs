using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class HouseDamageStatus : DamageStatus
    {
        public HouseDamageStatus()
        {

        }

        public Guid HouseDamageId { get; set; }
        public virtual HouseDamage HouseDamage { get; set; }
    }
}