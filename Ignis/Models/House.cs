using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public enum HouseStatus
    {
        Unoccupied, Occupied, Damaged
    }

    public class House
    {
        public House()
        {
            HouseDamages = new List<HouseDamage>();
        }

        public Guid Id { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [DisplayName("House Number")]
        public int Number { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        [DisplayName("Number of Bedrooms")]
        public int NumberOfBedrooms { get; set; }

        [Required]
        public string OccupantDesignation { get; set; }

        [Required]
        public HouseStatus Status { get; set; }

        public Guid ResidentialQuarterId { get; set; }
        public virtual ResidentialQuarter ResidentialQuarter { get; set; }

        public virtual ICollection<HouseDamage> HouseDamages { get; set; }
    }
}