using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using api_data_bd.Models;
using api_data_bd.Utiles.Action;
using api_data_bd.Utiles.Form;
using api_data_bd.Utiles.Static;

namespace api_data_bd.Controllers
{
    public class AdminUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminUsers
        public ActionResult Index()
        {
            return RedirectToAction("Login");
            //return View(db.AdminUsers.ToList());
        }

        // GET: AdminUsers/Login
        [HttpGet]
        [AdminAuthrizationRedirect( "Index", "Dashboard")]
        public ActionResult Login()
        {
            return View();
        }

        // POST: AdminUsers/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthrizationRedirect("Index", "Dashboard")]
        public ActionResult Login([Bind(Include = "")] LoginForm loginForm)
        {
            if (ModelState.IsValid)
            {

                    bool isHave = db.AdminUsers.Any(u => u.AdminUsersEmail == loginForm.Email 
                        && u.AdminUsersPassword == loginForm.Password);
                    if (!isHave)
                        ModelState.AddModelError("", "Sorry no user found.");
                    else {
                        var data = db.AdminUsers
                          .Where(us => us.AdminUsersEmail == loginForm.Email)
                          .Where(us => us.AdminUsersPassword == loginForm.Password)
                          .Single();
                        AuthAdminUser.setUserInCookie(data.AdminUsersId + "");
                        return RedirectToAction("Index", "DashBoard");
                    }
                   
            }
            return View(loginForm);
        }

        // GET: AdminUsers/Login
        [HttpGet]
        [AdminAuthrizationRedirect("Index", "Dashboard")]
        public ActionResult Register()
        {
            return View();
        }

        // POST: AdminUsers/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthrizationRedirect("Index", "Dashboard")]
        public ActionResult Register([Bind(Include = "")] AdminUsersRegisterBindingModel registerForm)
        {
            if (ModelState.IsValid)
            {
                AdminUsers adminUsers = registerForm.getAdminUser();
                db.AdminUsers.Add(adminUsers);
                db.SaveChanges();
                return RedirectToAction("Login");

            }
            return View(registerForm);
        }





        // GET: AdminUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminUsers adminUsers = db.AdminUsers.Find(id);
            if (adminUsers == null)
            {
                return HttpNotFound();
            }
            return View(adminUsers);
        }

        // GET: AdminUsers/Create
        [AdminAuthrizationRedirect("Index", "Dashboard")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthrizationRedirect("Index", "Dashboard")]
        public ActionResult Create([Bind(Include = "AdminUsersId,AdminUsersName,AdminUsersEmail,AdminUsersPassword")] AdminUsers adminUsers)
        {
            
            if (ModelState.IsValid)
            {
                db.AdminUsers.Add(adminUsers);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(adminUsers);
        }

        // GET: AdminUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminUsers adminUsers = db.AdminUsers.Find(id);
            if (adminUsers == null)
            {
                return HttpNotFound();
            }
            return View(adminUsers);
        }

        // POST: AdminUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdminUsersId,AdminUsersName,AdminUsersEmail,AdminUsersPassword")] AdminUsers adminUsers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminUsers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adminUsers);
        }

        // GET: AdminUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminUsers adminUsers = db.AdminUsers.Find(id);
            if (adminUsers == null)
            {
                return HttpNotFound();
            }
            return View(adminUsers);
        }

        // POST: AdminUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdminUsers adminUsers = db.AdminUsers.Find(id);
            db.AdminUsers.Remove(adminUsers);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
