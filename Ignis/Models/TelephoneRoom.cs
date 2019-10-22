using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class TelephoneRoom 
    {
        public TelephoneRoom()
        {
            TelephoneRoomDamages = new List<TelephoneRoomDamage>();
        }
        public Guid Id { get; set; }

        [Required]
        [DisplayName("Telephone Room Name")]
        public string Name { get; set; }

        public Guid FireStationId { get; set; }
        public virtual FireStation FireStation { get; set; }

        public virtual ICollection<TelephoneRoomDamage> TelephoneRoomDamages { get; set; }
    }
}