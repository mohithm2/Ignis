using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class Land
    {
        public Land()
        {

        }

        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Area { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Date of Purchase")]
        public DateTime DateOfPurchase { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Cost { get; set; }

        [Required]
        [DisplayName("Government Sanction Number")]
        public string GovernmentSactionNumber { get; set; }

        [Required]
        [DisplayName("Is Encroached")]
        public bool IsEncroached { get; set; }

        public Guid FireStationId { get; set; }
        public virtual FireStation FireStation { get; set; }
    }
}