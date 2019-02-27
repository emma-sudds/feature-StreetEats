using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StreetEats.Models
{
    public class Corporate
    {
        public string corporatePlatter { get; set; }
        public string corporatePlatterDescrip1 { get; set; }
        public string corporatePlatterDescrip2 { get; set; }
        public List<corporateFood> corporateFoodList { get; set; }
    }
}