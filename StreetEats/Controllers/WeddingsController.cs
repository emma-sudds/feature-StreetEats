using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StreetEats.Models;
using System.IO;
using System.Net.Mail;
using System.Net;

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
                menuPages.Add("/Content/images/menu/pages/" + fileName);
            }

            var weddingInfo = new Weddings
            {
                backGroundImage = backgroundImage,
                menuFrontPage = menuFrontPageImage,
                MenuPage = menuPages
            };

            return View(weddingInfo);
        }

        [HttpPost]
        public JsonResult AjaxContactForm(Contact model)
        {
            GmailUsername = "emmasudsey@gmail.com";
            GmailPassword = "Deadpool2019!";
            ToEmail = "emmasudds@live.co.uk";
            Subject = "Wedding";
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