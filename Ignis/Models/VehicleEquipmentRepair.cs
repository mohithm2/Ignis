using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class VehicleEquipmentRepair : Repair
    {
        public VehicleEquipmentRepair()
        {

        }

        public Guid VehicleEquipmentDamageId { get; set; }

        public VehicleEquipmentDamage VehicleEquipmentDamage { get; set; }
    }
}