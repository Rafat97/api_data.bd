using api_data_bd.Models;
using api_data_bd.Utiles.Action;
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
            var db = api_data_bd.Utiles.Static.AppDatabase.getInstence().getDatabase();
            int adminUserId = (int)Session["AdminUserID"];
            ViewBag.currentAdminUser = db.AdminUsers.Find(adminUserId);
            return View();
        }
        public ActionResult Logout()
        {
            Session["AdminUserID"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}