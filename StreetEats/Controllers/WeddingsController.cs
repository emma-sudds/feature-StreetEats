using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using StreetEats.Models;
using System.Net.Mail;
using System.Net;
using System.Configuration;

namespace StreetEats.Controllers
{
    public class WeddingsController : Controller
    {
        public static string GmailUsername { get; set; }
        public static string GmailPassword { get; set; }
        public static string GmailHost { get; set; }
        public static int GmailPort { get; set; }
        public static bool GmailSSL { get; set; }

        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }

        // GET: Wedding
        public ActionResult Index()
        {
            string allPicturesLocation = "/Content/Images/wedding";
            List<string> weddingCategories = ConfigurationManager.AppSettings["weddingCategories"].Split('|').ToList();
            List<string> weddingFirstPage = ConfigurationManager.AppSettings["weddingStartingPage"].Split('|').ToList();
            List<string> weddingNames = ConfigurationManager.AppSettings["weddingFoodNames"].Split('|').ToList();
            List<string> weddingPictureNames = ConfigurationManager.AppSettings["weddingPictures"].Split('|').ToList();
            List<string> weddingDescriptions = ConfigurationManager.AppSettings["weddingDescriptions"].Split('|').ToList();
            List<Weddings> weddingCategoryDetails = new List<Weddings>();

            for (int category = 0; category < weddingCategories.Count; category++)
            {
                List<string> categoryFoodNames = weddingNames[category].Split('\\').ToList();
                List<string> categoryFileNames = weddingPictureNames[category].Split(',').ToList();
                List<string> categoryFoodDescriptions = weddingDescriptions[category].Split('\\').ToList();

                for (int file = 0; file < categoryFileNames.Count; file++)
                {
                    categoryFileNames[file] = allPicturesLocation + "/"+ categoryFileNames[file];
                }

                var weddingInfo = new Weddings
                {
                    header = weddingCategories[category],
                    startingPage = weddingFirstPage[category],
                    fileLocations = categoryFileNames,
                    foodNames = categoryFoodNames,
                    descriptions = categoryFoodDescriptions
                };
                weddingCategoryDetails.Add(weddingInfo);
            }
            return View(weddingCategoryDetails);
        }

        [HttpPost]
        public JsonResult AjaxContactForm(Contact model)
        {
            GmailUsername = "emmasudsey@gmail.com";
            GmailPassword = "Deadpool2019!";
            ToEmail = "emmasudds@live.co.uk";
            Subject = model.subject;
            Body = model.message + "<br/>" + "From: " + model.email;
            IsHtml = true;
            Send();
            return Json(model);
        }

        public void Send()
        {
            GmailHost = "smtp.gmail.com";
            GmailPort = 25;
            GmailSSL = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = GmailHost;
            smtp.Port = GmailPort;
            smtp.EnableSsl = GmailSSL;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(GmailUsername, GmailPassword);

            using (var message = new MailMessage(GmailUsername, ToEmail))
            {
                message.Subject = Subject;
                message.Body = Body;
                message.IsBodyHtml = IsHtml;
                smtp.Send(message);
            }
        }
    }
}