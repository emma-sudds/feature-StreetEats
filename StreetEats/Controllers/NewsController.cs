using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using StreetEats.Models;
using System.IO;
using System.Text;

namespace StreetEats.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            List<NewsArticles> allNews = new List<NewsArticles>();
            string newsTextLocation = "~/newscontent/text/";
            string newsImagesLocation = "/Content/Images/news/";
            List<string> newsFileNames = ConfigurationManager.AppSettings["newsFileNames"].Split('|').ToList();
            List<string> newsHeaders = ConfigurationManager.AppSettings["newsHeaders"].Split('|').ToList();
            List<string> newsImages = ConfigurationManager.AppSettings["newsImages"].Split('|').ToList();
            News finalNews = new News();

            var combinedNews = newsFileNames
            .Zip(newsHeaders, (files, headers) => new {
                Files = files,
                Headers = headers
            })
            .Zip(newsImages, (fileHeader, images) => new {
                Files = fileHeader.Files,
                Headers = fileHeader.Headers,
                Images = images
            });

            foreach (var newsitem in combinedNews)
            {
                NewsArticles news = new NewsArticles();
                string fileLocation = Server.MapPath(newsTextLocation) + newsitem.Files;
                string newsContent = System.IO.File.ReadAllText(fileLocation, Encoding.UTF8);
                string imageLocation = newsImagesLocation + newsitem.Images;
                string header = newsitem.Headers;
                news.newsText = newsContent;
                news.newsHeader = header;
                news.imageName = imageLocation;
                allNews.Add(news);
            }
            finalNews.allNews = allNews;

            return View(finalNews);
        }
    }
}