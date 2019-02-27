using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StreetEats.Models;
using System.Configuration;

namespace StreetEats.Controllers
{
    public class CorporateController : Controller
    {
        // GET: Corporate
        public ActionResult Index()
        {
            string corporatePlatterLocation = "/Content/Images/corporate";
            string corporatePlatterFileName = ConfigurationManager.AppSettings["corporatePlatterFileName"];
            List<string> corporateFoodNames = ConfigurationManager.AppSettings["corporateFoodNames"].Split('|').ToList();
            List<string> corporateFoodDescriptions = ConfigurationManager.AppSettings["corporateFoodDescriptions"].Split('|').ToList();
            Corporate fullCorporateFood = new Corporate();
            List<corporateFood> corporateFoods = new List<corporateFood>();

            for (int foodCount = 0; foodCount < corporateFoodNames.Count; foodCount++)
            {
                var individualCorporateFood = new corporateFood
                {
                    foodName = corporateFoodNames[foodCount],
                    description = corporateFoodDescriptions[foodCount]
                };
                corporateFoods.Add(individualCorporateFood);
            }

            fullCorporateFood.corporatePlatter = corporatePlatterLocation + "/" + corporatePlatterFileName;
            fullCorporateFood.corporateFoodList = corporateFoods;
            fullCorporateFood.corporatePlatterDescrip1 = ConfigurationManager.AppSettings["corporatePlatterDescrip1"];
            fullCorporateFood.corporatePlatterDescrip2 = ConfigurationManager.AppSettings["corporatePlatterDescrip2"];
            return View(fullCorporateFood);
        }
    }
}