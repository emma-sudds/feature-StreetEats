using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StreetEats.Models;
using System.IO;

namespace StreetEats.Controllers
{
    public class WeddingsController : Controller
    {
        // GET: Wedding
        public ActionResult Index()
        {
            string backgroundImage = "";
            string menuFrontPageImage = "";
            List<string> menuPages = new List<string>();
            string[] backGroundImageFiles = Directory.GetFiles("C:\\Users\\HazeyOrion\\Documents\\StreetEats\\StreetEats\\StreetEats\\Content\\Images\\background");
            string[] menuFrontImageFiles = Directory.GetFiles("C:\\Users\\HazeyOrion\\Documents\\StreetEats\\StreetEats\\StreetEats\\Content\\Images\\menu\\front");
            string[] menuPagesImageFiles = Directory.GetFiles("C:\\Users\\HazeyOrion\\Documents\\StreetEats\\StreetEats\\StreetEats\\Content\\Images\\menu\\pages");

            foreach (string file in backGroundImageFiles)
            {
                string fileName = Path.GetFileName(file);
                backgroundImage = "/Content/Images/background/" + fileName;
            }

            foreach (string file in menuFrontImageFiles)
            {
                string fileName = Path.GetFileName(file);
                menuFrontPageImage = "/Content/Images/menu/front/" + fileName;
            }

            foreach (string file in menuPagesImageFiles)
            {
                string fileName = Path.GetFileName(file);
                menuPages.Add("/Content/Images/menu/pages/" + fileName);
            }

            var weddingInfo = new Weddings
            {
                backGroundImage = backgroundImage,
                menuFrontPage = menuFrontPageImage,
                MenuPage = menuPages
            };

            return View(weddingInfo);
        }
    }
}