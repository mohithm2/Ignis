using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public abstract class Building
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}