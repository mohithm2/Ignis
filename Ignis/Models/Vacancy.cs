using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class Vacancy
    {
        public Guid Id { get; set; }

        [Required]
        [DisplayName("Vacancy")]
        public decimal Vacant { get; set; }

        public Guid RankId { get; set; }
        public virtual Rank Rank { get; set; }
        public Guid FireStationId { get; set; }
        public virtual FireStation FireStation { get; set; }

    }
}