using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StreetEats.Models
{
    public class WeddingPage
    {
        public string header { get; set; }
        public List<food> foodOfCategory { get; set; }
    }
}