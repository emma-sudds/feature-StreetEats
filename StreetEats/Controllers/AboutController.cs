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
            string business1 = "/Content/Images/business/business1.JPG";
            string business2 = "/Content/Images/business/business2.JPG";
            string business3 = "/Content/Images/business/business3.JPG";
            string business4 = "/Content/Images/business/business4.JPG";
            string business5 = "/Content/Images/business/business5.JPG";
            string business6 = "/Content/Images/business/business6.JPG";
            var aboutFood = new About
            {
                ourFood1 = aboutTheFood1,
                ourFood2 = aboutTheFood2,
                ourFood3 = aboutTheFood3,
                ourFood4 = aboutTheFood4,
                business1 = business1,
                business2 = business2,
                business3 = business3,
                business4 = business4,
                business5 = business5,
                business6 = business6
            };
            return View(aboutFood);
        }
    }
}