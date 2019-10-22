using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class Group
    {
        public Group()
        {
            Ranks = new List<Rank>();
        }
        public Guid Id { get; set; }

        [Required]
        [DisplayName("Group Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Maximum Years For a Tenure")]
        public decimal MaxYears { get; set; }

        public virtual ICollection<Rank> Ranks { get; set; }
    }
}