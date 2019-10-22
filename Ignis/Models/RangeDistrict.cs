using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class RangeDistrict
    {
        public RangeDistrict()
        {

        }

        public Guid Id { get; set; }
        public Guid RangeId { get; set; }
        public Guid DistrictId { get; set; }
        public virtual Range Range { get; set; }
        public virtual District District { get; set; }
    }
}