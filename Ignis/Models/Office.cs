using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class Office 
    {
        public Office()
        {
            OfficeDamages = new List<OfficeDamage>();
        }

        public Guid Id { get; set; }

        [Required]
        [DisplayName("Office Name")]
        public string Name { get; set; }

        public Guid FireStationId { get; set; }
        public virtual FireStation FireStation { get; set; }

        public virtual ICollection<OfficeDamage> OfficeDamages { get; set; }
    }
}