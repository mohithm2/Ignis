using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public enum TicketTypes
    {
        Vehicle, VehicleEquipment
    }

    public class SelectTicketTypeViewModel
    {
        [Required]
        public TicketTypes TicketType { get; set; }
    }
}