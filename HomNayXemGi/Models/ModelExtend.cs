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
            return (CumRap.Trim().Equals(p.CumRap.Trim())) && (TenRap.Trim().Equals(p.TenRap.Trim()));
        }

        public override int GetHashCode()
        {
            return 13 * CumRap.GetHashCode() + 7 * TenRap.GetHashCode();
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
            return a.CumRap.Trim().Equals(b.CumRap.Trim()) && a.TenRap.Trim().Equals(b.TenRap.Trim());
        }

        public static bool operator !=(RapChieu a, RapChieu b)
        {
            return !(a == b);
        }
    }

    public partial class Movie
    {
        public String MovieType
        {
            get
            {
                string Type = "2D";
                if (this.Name.ToUpper().Contains("3D"))
                {
                    Type = "3D";
                }
                return Type;
            }
            set
            {

            }
        }

        public String CumRap()
        {
            String result = "";
            var CumRaps = this.Schedulers.Select(sche => sche.CumRap).Distinct().ToList();
            if (CumRaps.Count > 0)
            {
                foreach (var cumRap in CumRaps)
                {
                    result += cumRap + ", ";
                }
                result = result.Substring(0, result.Length - 2);
            }
            return result;
        }
    }

   

}