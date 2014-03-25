using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomNayXemGi.Models
{
    public partial class Scheduler
    {
        public RapChieu RapChieu
        {
            get
            {
                return new RapChieu { CumRap = this.CumRap, TenRap = this.TenRap };
            }
            set
            {

            }
        }
    }

    public class RapChieu
    {
        public String CumRap { get; set; }
        public String TenRap { get; set; }

        public override bool Equals(Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            RapChieu p = obj as RapChieu;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (CumRap.Equals(p.CumRap)) && (TenRap.Equals(p.TenRap));
        }

        public static bool operator ==(RapChieu a, RapChieu b)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            // Return true if the fields match:
            return a.CumRap.Equals(b.CumRap) && a.TenRap.Equals(b.TenRap);
        }

        public static bool operator !=(RapChieu a, RapChieu b)
        {
            return !(a == b);
        }
    }
}