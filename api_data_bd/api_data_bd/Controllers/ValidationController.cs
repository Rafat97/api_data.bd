using api_data_bd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace api_data_bd.Controllers
{
    public class ValidationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Validation
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult IsUserExists(string UserName)
        {
            //check if any of the UserName matches the UserName specified in the Parameter using the ANY extension method.  
            return Json(!db.AdminUsers.Any(x => x.AdminUsersEmail == UserName), JsonRequestBehavior.AllowGet);
        }
    }
}