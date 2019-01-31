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
            string face = "/Content/Images/about/face/face.png";
            string ourFoodPath = "/Content/Images/about/ourFood";
            string businessPath = "/Content/Images/about/business";
            string awardPath = "/Content/Images/about/awards";
            List <string> ourFoodFilesCol1 = new List<string>();
            List<string> ourFoodFilesCol2 = new List<string>();
            List<string> businessFilesCol1 = new List<string>();
            List<string> businessFilesCol2 = new List<string>();
            List<string> awardsCol1 = new List<string>();
            List<string> awardsCol2 = new List<string>();

            foreach (string ourFood in Directory.GetFiles(Server.MapPath(ourFoodPath)))
            {
                if (ourFood.IndexOf("_") > 0)
                {
                    string ourFoodFileName = Path.GetFileName(ourFood);
                    string ourFoodColumnValue = ourFoodFileName.Substring(0, ourFoodFileName.IndexOf("_"));

                    if (ourFoodColumnValue == "col1")
                    {
                        ourFoodFilesCol1.Add(ourFoodPath + "/" + ourFoodFileName);
                    }

                    if (ourFoodColumnValue == "col2")
                    {
                        ourFoodFilesCol2.Add(ourFoodPath + "/" + ourFoodFileName);
                    }
                }
            }

            foreach (string businessFood in Directory.GetFiles(Server.MapPath(businessPath)))
            {
                if (businessFood.IndexOf("_") > 0)
                {
                    string businessFileName = Path.GetFileName(businessFood);
                    string businessFoodColumnValue = businessFileName.Substring(0, businessFileName.IndexOf("_"));

                    if (businessFoodColumnValue == "col1")
                    {
                        businessFilesCol1.Add(businessPath + "/" + businessFileName);
                    }

                    if (businessFoodColumnValue == "col2")
                    {
                        businessFilesCol2.Add(businessPath + "/" + businessFileName);
                    }
                }
            }

            foreach (string awardFile in Directory.GetFiles(Server.MapPath(awardPath)))
            {
                if (awardFile.IndexOf("_") > 0)
                {
                    string awardFileName = Path.GetFileName(awardFile);
                    string awardColumnValue = awardFileName.Substring(0, awardFileName.IndexOf("_"));

                    if (awardColumnValue == "col1")
                    {
                        awardsCol1.Add(awardPath + "/" + awardFileName);
                    }

                    if (awardColumnValue == "col2")
                    {
                        awardsCol2.Add(awardPath + "/" + awardFileName);
                    }
                }
            }

            var aboutFood = new About
            {
                ourFoodCol1 = ourFoodFilesCol1,
                ourFoodCol2 = ourFoodFilesCol2,
                business1 = businessFilesCol1,
                business2 = businessFilesCol2,
                awards1 = awardsCol1,
                awards2 = awardsCol2,
                face = face
            };

            return View(aboutFood);
        }
    }
}