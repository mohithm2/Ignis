using Ignis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignis.Util
{
    public class ChainOfCommandHelper
    {
        public static Official GetHigherOfficial()
        {
            if(HttpContext.Current.User.IsInRole("cfo"))
            {
                return Official.DFO;
            }
            if (HttpContext.Current.User.IsInRole("dfo"))
            {
                return Official.RFO;
            }
            if (HttpContext.Current.User.IsInRole("rfo"))
            {
                return Official.ZFO;
            }
            if (HttpContext.Current.User.IsInRole("zfo"))
            {
                return Official.IG;
            }

            return Official.IG;
        }

        public static Official GetCurrentOfficial()
        {
            if (HttpContext.Current.User.IsInRole("cfo"))
            {
                return Official.CFO;
            }
            if (HttpContext.Current.User.IsInRole("dfo"))
            {
                return Official.DFO;
            }
            if (HttpContext.Current.User.IsInRole("rfo"))
            {
                return Official.RFO;
            }
            if (HttpContext.Current.User.IsInRole("zfo"))
            {
                return Official.ZFO;
            }
            if (HttpContext.Current.User.IsInRole("ig"))
            {
                return Official.IG;
            }

            return Official.IG;
        }
    }
}