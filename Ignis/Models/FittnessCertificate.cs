using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class FittnessCertificate
    {
        public FittnessCertificate()
        {

        }

        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Issue Date")]
        public DateTime IssueDate { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }

        public Guid VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}