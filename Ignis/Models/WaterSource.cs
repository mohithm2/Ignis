using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class WaterSource
    {
        public Guid Id { get; set; }

        [Required]
        [DisplayName("Water source name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [DisplayName("Is water source owned by fire station")]
        public bool IsOwned { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Capacity { get; set; }

        public Guid FireStationId { get; set; }
        public virtual FireStation FireStation { get; set; }

    }
}