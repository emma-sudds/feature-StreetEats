using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StreetEats.Models;
using System.IO;

namespace StreetEats.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            string aboutTheFood1 = "/Content/Images/about/ourFood.JPG";
            string aboutTheFood2 = "/Content/Images/about/ourFood2.JPG";
            string aboutTheFood3 = "/Content/Images/about/ourFood3.JPG";
            string aboutTheFood4 = "/Content/Images/about/ourFood4.JPG";
            var aboutFood = new About
            {
                ourFood1 = aboutTheFood1,
                ourFood2 = aboutTheFood2,
                ourFood3 = aboutTheFood3,
                ourFood4 = aboutTheFood4
            };
            return View(aboutFood);
        }
    }
}