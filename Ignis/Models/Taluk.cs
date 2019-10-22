using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class Taluk
    {
        public Taluk()
        {
            Hoblis = new List<Hobli>();
        }

        public Guid Id { get; set; }

        [Required]
        [DisplayName("Taluk Name")]
        public string Name { get; set; }

        public Guid DistrictId { get; set; }
        public virtual District District { get; set; }
        public virtual ICollection<Hobli> Hoblis { get; set; }
    }
}