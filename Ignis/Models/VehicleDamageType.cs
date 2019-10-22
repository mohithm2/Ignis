using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class VehicleDamageType : DamageType
    {
        public VehicleDamageType()
        {
            VehicleDamages = new List<VehicleDamage>();
        }

        public virtual ICollection<VehicleDamage> VehicleDamages { get; set; }
    }
}