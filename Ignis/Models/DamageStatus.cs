using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public enum DamageAction
    {
        Open, Approve, Disapprove, Elevate, Closed, Raised
    }

    public enum Official
    {
        CFO, DFO, RFO, ZFO, IG
    }

    public abstract class DamageStatus
    {
        public Guid Id { get; set; }
        public Guid CaseId { get; set; }
        public DateTime DateOfArrival { get; set; }
        public DateTime? DateOfLeaving { get; set; }
        public string Comment { get; set; }
        public DamageAction Action { get; set; }
        public Official Official { get; set; }

        public string DiscriminatorValue
        {
            get
            {
                return this.GetType().Name.Substring(0, this.GetType().Name.IndexOf('_'));
            }
        }
    }
}