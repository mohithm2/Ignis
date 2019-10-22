using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class VehicleDamageStatus : DamageStatus
    {
        public VehicleDamageStatus()
        {

        }

        public Guid VehicleDamageId { get; set; }
        public virtual VehicleDamage VehicleDamage { get; set; }
    }
}