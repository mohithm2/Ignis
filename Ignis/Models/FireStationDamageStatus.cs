using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class FireStationDamageStatus : DamageStatus
    {
        public FireStationDamageStatus()
        {

        }

        public Guid FireStationDamageId { get; set; }
        public virtual FireStationDamage FireStationDamage { get; set; }
    }
}