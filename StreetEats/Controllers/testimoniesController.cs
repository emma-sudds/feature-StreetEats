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
            List<string> availableTestimonyCategories = ConfigurationManager.AppSettings["tesimonyAvailableCategories"].Split('|').ToList();
            List<string> testimonyCategories = ConfigurationManager.AppSettings["tesimonyCategories"].Split('|').ToList();
            List<string> tesimonyCategoryImages = ConfigurationManager.AppSettings["tesimonyAvailableCategoriesImages"].Split('|').ToList();
            List<testimonyDetails> allTestimonies = new List<testimonyDetails>();
            testimony fullListTestimonies = new testimony();
            List<tesimonyCategories> fullCategoryList = new List<tesimonyCategories>();
            var fullTesimonieDetails = fullTestimonies
           .Zip(fullTestimoniesNames, (text, name) => new
            {
                Text = text,
                Name = name,
            })
           .Zip(testimonyCategories, (details, category) => new {
               Text = details.Text,
               Name = details.Name,
               Category = category
           });

            foreach(var testimony in fullTesimonieDetails)
            {
                var fullTestimony = new testimonyDetails
                {
                    fullTestimonyText = testimony.Text,
                    fullTestimonyName = testimony.Name,
                    testimonyCategory = testimony.Category
                };
                allTestimonies.Add(fullTestimony);
            }
            var fullCategoryDetails = availableTestimonyCategories
                .Zip(tesimonyCategoryImages, (name, image) => new {
                    Name = name,
                    Image = image
                });

            foreach (var category in fullCategoryDetails)
            {
                tesimonyCategories tesimonyCategory = new tesimonyCategories();
                tesimonyCategory.categoryName = category.Name;
                tesimonyCategory.categoryImage = category.Image;
                fullCategoryList.Add(tesimonyCategory);
            }

            fullListTestimonies.testimonies = allTestimonies;
            fullListTestimonies.tesimonyCategories = fullCategoryList;
            return View(fullListTestimonies);
        }
    }
}