using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StreetEats.Models
{
    public class About
    {
        public List<string> ourFoodCol1 { get; set; }
        public List<string> ourFoodCol2 { get; set; }
        public List<string> business1 { get; set; }
        public List<string> business2 { get; set; }
        public List<string> awards1 { get; set; }
        public List<string> awards2 { get; set; }
        public string face { get; set; }
    }
}