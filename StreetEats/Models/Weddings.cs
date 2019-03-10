using System.Collections.Generic;

namespace StreetEats.Models
{
    public class Weddings
    {
        public string frontPageHeader { get; set; }
        public string frontPageText{ get; set; }
        public string frontPageImage { get; set; }
        public string frontPageImage2 { get; set; }
        public List<string> weddingDescription { get; set; }
        public List<WeddingPage> weddingPages { get; set; }
    }
}