using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public abstract class Damage
    {
        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date Damage Was Noticed")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateNoticed { get; set; }
        
        [Required]
        [DisplayName("Agency Report")]
        public string Report { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [DisplayName("Estimated Cost")]
        public double CostEstimate { get; set; }

        public string DiscriminatorValue
        {
            get
            {
                return this.GetType().Name.Substring(0, this.GetType().Name.IndexOf('_'));
            }
        }
    }
}