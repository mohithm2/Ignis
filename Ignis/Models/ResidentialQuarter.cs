using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class ResidentialQuarter 
    {
        public ResidentialQuarter()
        {
            Houses = new List<House>();
        }

        public Guid Id { get; set; }

        [Required]
        [DisplayName("Name of Residential Quarter")]
        public string Name { get; set; }

        public Guid FireStationId { get; set; }
        public virtual FireStation FireStation { get; set; }

        public virtual ICollection<House> Houses { get; set; }
    }
}