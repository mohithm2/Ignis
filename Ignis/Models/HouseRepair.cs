using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class HouseRepair : Repair
    {
        public HouseRepair()
        {

        }

        public Guid HouseDamageId { get; set; }

        public HouseDamage HouseDamage { get; set; }
    }
}