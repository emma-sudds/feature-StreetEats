using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StreetEats.Models;
using System.Configuration;

namespace StreetEats.Controllers
{
    public class testimoniesController : Controller
    {
        // GET: testimonies
        public ActionResult Index()
        {
            List<string> fullTestimonies = ConfigurationManager.AppSettings["fullTestimonies"].Split('|').ToList();
            List<string> fullTestimoniesNames = ConfigurationManager.AppSettings["tesimonieNames"].Split('|').ToList();
            List<testimonyDetails> allTestimonies = new List<testimonyDetails>();
            testimony fullListTestimonies = new testimony();
            var fullTesimonieDetails = fullTestimonies.Zip(fullTestimoniesNames, (text, name) => new
            {
                Text = text,
                Name = name,
            });

            foreach(var testimony in fullTesimonieDetails)
            {
                var fullTestimony = new testimonyDetails
                {
                    fullTestimonyText = testimony.Text,
                    fullTestimonyName = testimony.Name
                };
                allTestimonies.Add(fullTestimony);
            }

            fullListTestimonies.testimonies = allTestimonies;
            return View(fullListTestimonies);
        }
    }
}