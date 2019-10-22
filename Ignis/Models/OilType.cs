using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class OilType
    {
        public OilType()
        {
            OilChanges = new List<OilChange>();
        }

        public Guid Id { get; set; }

        [Required]
        [DisplayName("Oil Name")]
        public string Name { get; set; }

        public virtual ICollection<OilChange> OilChanges { get; set; }
    }
}