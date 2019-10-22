using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class Count
    {
        public Guid Id { get; set; }

        [Required]
        [DisplayName("Sanctioned Strength")]
        public decimal Sanctioned { get; set; }

        [Required]
        [DisplayName("Alloted Strength")]
        public decimal Alloted { get; set; }

        public Guid RankId { get; set; }
        public virtual Rank Rank { get; set; }

        public Guid FireStationId { get; set; }
        public virtual FireStation FireStation { get; set; }
    }
}