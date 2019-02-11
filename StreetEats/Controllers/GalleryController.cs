using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using StreetEats.Models;

namespace StreetEats.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        public ActionResult Index()
        {
            string allPicturesLocation = "/Content/Images/gallery";
            List<string> allPictures = new List<string>();
            List<string> foodPictures = new List<string>();
            List<string> marketPictures = new List<string>();
            List<string> eventPictures = new List<string>();
            List<string> corporatePictures = new List<string>();
            List<string> generalPictures = new List<string>();

            int fileCount = Directory.GetFiles(Server.MapPath(allPicturesLocation), "*", SearchOption.TopDirectoryOnly).Length;
            int currentFileCount = 1;

            foreach (string allPics in Directory.GetFiles(Server.MapPath(allPicturesLocation)))
            {
                if (allPics.IndexOf('_') > 0)
                {
                    string allPicFileName = Path.GetFileName(allPics);
                    string[] picCategoryValueSplit = allPicFileName.Split('_');
                    int picNumber = Convert.ToInt32(picCategoryValueSplit[0]);
                    string picCategoryValue = picCategoryValueSplit[1];
                    string foodUrl = allPicturesLocation + "/" + allPicFileName;

                    if (picNumber == currentFileCount && picNumber <= fileCount)
                    {
                        allPictures.Add(foodUrl);
                        currentFileCount++;
                    }

                    if (picCategoryValue == "food")
                    {
                        foodPictures.Add(foodUrl);
                    }
                    else if (picCategoryValue == "market")
                    {
                        marketPictures.Add(foodUrl);
                    }
                    else if (picCategoryValue == "event")
                    {
                        eventPictures.Add(foodUrl);
                    }
                    else if (picCategoryValue == "corporate")
                    {
                        corporatePictures.Add(foodUrl);
                    }
                    else if (picCategoryValue == "general")
                    {
                        generalPictures.Add(foodUrl);
                    }

                }
            }

            var foodPicturesUrls = new Gallery
            {
                allPictures = allPictures,
                foodPictures = foodPictures,
                marketPictures = marketPictures,
                eventPictures = eventPictures,
                corporatePictures = corporatePictures,
                generalPictures = generalPictures
            };

            return View(foodPicturesUrls);
        }
    }
}