using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class RequiredLand
    {
        public RequiredLand()
        {

        }

        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Reason { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [DisplayName("Estimated Cost")]
        public double PotentialCost { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [DisplayName("Area Required")]
        public double AreaRequired { get; set; }

        public Guid FireStationId { get; set; }
        public virtual FireStation FireStation { get; set; }
    }
}