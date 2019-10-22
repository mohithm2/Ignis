using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class Zone
    {
        public Zone()
        {
            ZoneRanges = new List<ZoneRange>();
        }

        public Guid Id { get; set; }

        [Required]
        [DisplayName("Zone Name")]
        public string Name { get; set; }

        public virtual ICollection<ZoneRange> ZoneRanges { get; set; }
    }
}