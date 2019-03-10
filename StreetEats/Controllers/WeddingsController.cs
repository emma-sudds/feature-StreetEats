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
            string frontPageHeader = ConfigurationManager.AppSettings["weddingMenuHeader"];
            string frontPageText = ConfigurationManager.AppSettings["weddingMenuText"];
            string weddingMenuDescription = ConfigurationManager.AppSettings["weddingMenuDescription"];
            List<string> weddingCategories = ConfigurationManager.AppSettings["weddingCategories"].Split('|').ToList();
            List<string> weddingNames = ConfigurationManager.AppSettings["weddingFoodNames"].Split('|').ToList();
            List<string> weddingPictureNames = ConfigurationManager.AppSettings["weddingPictures"].Split('|').ToList();
            List<string> weddingDescriptions = ConfigurationManager.AppSettings["weddingDescriptions"].Split('|').ToList();
            List<WeddingPage> weddingCategoryDetails = new List<WeddingPage>();

            for (int category = 0; category < weddingCategories.Count; category++)
            {
                List<food> weddingFoods = new List<food>();
                List<string> categoryFoodNames = weddingNames[category].Split('\\').ToList();
                List<string> categoryFileNames = weddingPictureNames[category].Split(',').ToList();
                List<string> categoryFoodDescriptions = weddingDescriptions[category].Split('\\').ToList();

                for (int file = 0; file < categoryFileNames.Count; file++)
                {
                    categoryFileNames[file] = allPicturesLocation + "/"+ categoryFileNames[file];
                }
                
                var foodDetails = categoryFoodNames.Zip(categoryFileNames, (name, file) => new
                {
                    Name = name,
                    File = file,
                })
                .Zip(categoryFoodDescriptions, (a, b) => new
                {
                    Name = a.Name,
                    File = a.File,
                    Description = b,
                });

                foreach (var weddingFood in foodDetails) {
                    var foodDetail = new food
                    {
                        fileLocation = weddingFood.File,
                        foodName = weddingFood.Name,
                        description = weddingFood.Description
                    };
                    weddingFoods.Add(foodDetail);
                }
                var weddingInfo = new WeddingPage
                {
                    header = weddingCategories[category],
                    foodOfCategory = weddingFoods
                };
                weddingCategoryDetails.Add(weddingInfo);
            }

            Weddings weddingData = new Weddings();
            weddingData.weddingPages = weddingCategoryDetails;
            weddingData.frontPageHeader = frontPageHeader;
            weddingData.frontPageText = frontPageText;
            weddingData.frontPageImage = allPicturesLocation + "/" + ConfigurationManager.AppSettings["weddingMenuImage"];
            weddingData.frontPageImage2 = allPicturesLocation + "/" + ConfigurationManager.AppSettings["weddingMenuImage2"];
            weddingData.weddingDescription = weddingMenuDescription.Split('|').ToList();
            return View(weddingData);
        }

        [HttpPost]
        public JsonResult AjaxContactForm(Contact model)
        {
            GmailUsername = "emmasudsey@gmail.com";
            GmailPassword = "Deadpool2019!";
            ToEmail = "emmasudds@live.co.uk";
            Subject = model.subject;
            Body = "<b>Name: </b>" + model.name + "<br/>" +
                   "<b>Message: </b>" + model.message + "<br/>" +
                   "<b>Email Contact: </b>" + model.email;
            IsHtml = true;
            Send();
            return Json(model);
        }

        [HttpPost]
        public JsonResult AjaxFeedbackForm(feedback model)
        {
            GmailUsername = "emmasudsey@gmail.com";
            GmailPassword = "Deadpool2019!";
            ToEmail = "emmasudds@live.co.uk";
            Subject = model.subject;
            Body = "<b>Feedback category: </b>" + model.feedbackCategory + "<br/>" +
                   "<b>Name: </b>" + model.name + " <br/>" +
                   "<b>Allowed to use Feedback: </b>" + model.useFeedback + " <br/>" +
                   "<b>Feedback: </b>" + model.message + "<br/>" +
                   "<b>Email Contact: </b>" + model.email;
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