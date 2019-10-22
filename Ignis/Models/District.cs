using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class District
    {
        public District()
        {
            RangeDistricts = new List<RangeDistrict>();
            Taluks = new List<Taluk>();
        }

        public Guid Id { get; set; }

        [Required]
        [DisplayName("District Name")]
        public string Name { get; set; }

        public virtual ICollection<RangeDistrict> RangeDistricts { get; set; }

        public virtual ICollection<Taluk> Taluks { get; set; }
    }
}