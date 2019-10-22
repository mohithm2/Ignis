using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class BreakRoom
    {
        public BreakRoom()
        {
            BreakRoomDamages = new List<BreakRoomDamage>();
        }
        public Guid Id { get; set; }

        [Required]
        [DisplayName("Break Room Name")]
        public string Name { get; set; }

        public Guid FireStationId { get; set; }
        public virtual FireStation FireStation { get; set; }

        public virtual ICollection<BreakRoomDamage> BreakRoomDamages { get; set; }
    }
}