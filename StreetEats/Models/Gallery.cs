using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StreetEats.Models
{
    public class Gallery
    {
        public List<string> allPictures { get; set; }
        public List<string> foodPictures { get; set; }
        public List<string> marketPictures { get; set; }
        public List<string> eventPictures { get; set; }
        public List<string> corporatePictures { get; set; }
        public List<string> generalPictures { get; set; }
    }
}