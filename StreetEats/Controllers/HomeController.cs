using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StreetEats.Models;
using System.IO;

namespace StreetEats.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Home> sliderImages = new List<Home>();
            List<string> filePath = new List<string>();
            string logoFilePath = "";
            string[] sliderFiles = Directory.GetFiles(Server.MapPath("~/Content/Images/Slides"));
            string[] logoFile = Directory.GetFiles(Server.MapPath("~/Content/Images/logo"));
            string hireUsTitle = System.Configuration.ConfigurationManager.AppSettings["hireUsTitle"].ToString();
            string [] hireUsText = System.Configuration.ConfigurationManager.AppSettings["hireUsText"].Split('|').ToArray();
            string wannaKnowMoreTitle = System.Configuration.ConfigurationManager.AppSettings["wannaKnowMoreTitle"].ToString();
            string homeThirdColumn = System.Configuration.ConfigurationManager.AppSettings["homeThirdColumn"].ToString();
            string[] testimonyText = System.Configuration.ConfigurationManager.AppSettings["testimonyText"].Split('|').ToArray();

            foreach (string file in sliderFiles) {
                string fileName = Path.GetFileName(file);
                filePath.Add("/Content/Images/Slides/" + fileName);
            }

            foreach (string file in logoFile)
            {
                string fileName = Path.GetFileName(file);
                logoFilePath = "/Content/Images/logo/" + fileName;
            }

            var indexImages = new Home {
                FilePath = filePath,
                logoFilePath = logoFilePath,
                hireUsTitle = hireUsTitle,
                hireUsText = hireUsText,
                wannaKnowMoreTitle = wannaKnowMoreTitle,
                homeThirdColumn = homeThirdColumn,
                testimonyText = testimonyText
            };
            return View(indexImages);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}