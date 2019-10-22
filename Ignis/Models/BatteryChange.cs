using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class BatteryChange
    {
        public BatteryChange()
        {

        }

        public Guid Id { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [DisplayName("Odometer Reading")]
        public double OdometerReading { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [DisplayName("Road Run Kilometer")]
        public double RoadRunKilometer { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [DisplayName("Pump Run Kilometer")]
        public double PumpRunKilometer { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date of Change")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfChange { get; set; }

        public Guid VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}