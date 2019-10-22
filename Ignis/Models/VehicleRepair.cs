using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class VehicleRepair : Repair
    {
        public VehicleRepair()
        {

        }

        public Guid VehicleDamageId { get; set; }

        public VehicleDamage VehicleDamage { get; set; }
    }
}