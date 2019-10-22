using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class OilChange
    {
        public OilChange()
        {

        }

        public Guid Id { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [DisplayName("Odometer Reading")]
        public double OdometerReading { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [DisplayName("Road run kilometer")]
        public double RoadRunKilometer { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [DisplayName("Pump run kilometer")]
        public double PumpRunKilometer { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Date of Change")]
        public DateTime DateOfChange { get; set; }

        public Guid OilTypeId { get; set; }
        public virtual OilType OilType { get; set; }
        public Guid VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}