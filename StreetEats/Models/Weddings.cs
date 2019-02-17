using System.Collections.Generic;

namespace StreetEats.Models
{
    public class Weddings
    {
        public string header { get; set; }
        public string startingPage { get; set; }
        public List<string> fileLocations { get; set; }
        public List<string> foodNames { get; set; }
        public List<string> descriptions { get; set; }
    }
}