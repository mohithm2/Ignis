using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class ZoneRange
    {
        public ZoneRange()
        {

        }

        public Guid Id { get; set; }
        public Guid ZoneId { get; set; }
        public Guid RangeId { get; set; }
        public virtual Zone Zone { get; set; }
        public virtual Range Range { get; set; }
    }
}