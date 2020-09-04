using api_data_bd.Models;
using api_data_bd.Utiles.Action;
using api_data_bd.Utiles.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace api_data_bd.Controllers
{
    [AdminAuthrization]
    public class DashboardController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Dashboard
        public ActionResult Index()
        {
            ViewBag.currentAdminUser = AuthAdminUser.getAdminUser();
            return View();
        }
        public ActionResult Logout()
        {
            AuthAdminUser.signOutAdminUser();
            return RedirectToAction("Login", "AdminUsers");
        }
    }
}