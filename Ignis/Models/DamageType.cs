using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public abstract class DamageType
    {
        public Guid Id { get; set; }

        [Required]
        [DisplayName("Damage Description")]
        public string Description { get; set; }

        [Required]
        [DisplayName("Is Major Damage")]
        public bool IsMajor { get; set; }
    }
}