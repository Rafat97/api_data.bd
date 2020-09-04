using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace api_data_bd.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "Contact Page";
            
            return View();
        }
        public ActionResult Error()
        {
            ViewBag.Title = "404";

            return Content("404");
        }
    }
}
