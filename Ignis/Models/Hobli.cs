using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class Hobli
    {
        public Hobli()
        {

        }

        public Guid Id { get; set; }

        [Required]
        [DisplayName("Hobli Name")]
        public string Name { get; set; }

        public Guid TalukId { get; set; }
        public virtual Taluk Taluk { get; set; }
        public virtual FireStation FireStation { get; set; }
    }
}