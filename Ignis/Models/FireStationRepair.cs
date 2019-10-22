using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class FireStationRepair : Repair
    {
        public FireStationRepair()
        {

        }

        public Guid FireStationDamageId { get; set; }

        public FireStationDamage FireStationDamage { get; set; }
    }
}