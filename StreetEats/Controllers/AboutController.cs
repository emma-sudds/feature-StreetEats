﻿using System;
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
            string aboutTheFood = "/Content/Images/about/ourFood.JPG";
            var aboutFood = new About
            {
                ourFood = aboutTheFood
            };
            return View(aboutFood);
        }
    }
}