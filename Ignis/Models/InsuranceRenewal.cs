using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class InsuranceRenewal
    {
        public InsuranceRenewal()
        {

        }

        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Date of Payment")]
        public DateTime DateOfPayment { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [DisplayName("Amount Paid")]
        public double AmountPaid { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Expiry Date")]
        public DateTime ExpiryDate { get; set; }

        public Guid VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}