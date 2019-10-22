using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class Range
    {
        public Range()
        {
            ZoneRanges = new List<ZoneRange>();
        }

        public Guid Id { get; set; }

        [Required]
        [DisplayName("Range Name")]
        public string Name { get; set; }

        public virtual ICollection<ZoneRange> ZoneRanges { get; set; }
        public virtual ICollection<RangeDistrict> RangeDistricts { get; set; }
    }
}