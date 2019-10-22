using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public abstract class Repair
    {
        public Guid Id { get; set; }

        [Required]
        [DisplayName("Bill TIN")]
        public string BillTIN { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Cost { get; set; }

        [Required]
        [DisplayName("Agency Name")]
        public string AgencyName { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [DisplayName("Agency Contact")]
        public double AgencyContact { get; set; }
    }
}