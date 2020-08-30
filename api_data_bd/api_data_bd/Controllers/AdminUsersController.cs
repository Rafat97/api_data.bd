using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using api_data_bd.Models;

namespace api_data_bd.Controllers
{
    public class AdminUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminUsers
        public ActionResult Index()
        {
            return View(db.AdminUsers.ToList());
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdminUsersId,AdminUsersName,AdminUsersEmail,AdminUsersPassword")] AdminUsers adminUsers)
        {
            if (ModelState.IsValid)
            {
                db.AdminUsers.Add(adminUsers);
                db.SaveChanges();
                return RedirectToAction("Index");
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
