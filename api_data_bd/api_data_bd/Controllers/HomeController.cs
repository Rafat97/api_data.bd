using api_data_bd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace api_data_bd.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "")] ContactUs contactUs)
        {
            if (ModelState.IsValid)
            {
                db.ContactUs.Add(contactUs);
                db.SaveChanges();
                return RedirectToAction("ThankYou");
            }

            return View(contactUs);
        }

        public ActionResult Error()
        {
            ViewBag.Title = "404";

            return View();
        }

        public ActionResult ThankYou()
        {
            ViewBag.Title = "Thank You";

            return View();
        }
    }
}
