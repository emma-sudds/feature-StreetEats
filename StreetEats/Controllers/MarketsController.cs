using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StreetEats.Controllers
{
    public class MarketsController : Controller
    {
        // GET: Markets
        public ActionResult Index()
        {
            return View();
        }
    }
}