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

namespace api_data_bd.Controllers
{
    [AdminAuthrization]
    public class ViewInstituteStatisticsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ViewInstituteStatistics
        public ActionResult Index()
        {
            var db = api_data_bd.Utiles.Static.AppDatabase.getInstence().getDatabase();
            int adminUserId = (int)Session["AdminUserID"];
            ViewBag.currentAdminUser = db.AdminUsers.Find(adminUserId);

            var instituteStatistics = db.InstituteStatistics.Include(i => i.Instituitions);
            return View(instituteStatistics.ToList());
        }

        // GET: ViewInstituteStatistics/Details/5
        public ActionResult Details(int? id)
        {
            var db = api_data_bd.Utiles.Static.AppDatabase.getInstence().getDatabase();
            int adminUserId = (int)Session["AdminUserID"];
            ViewBag.currentAdminUser = db.AdminUsers.Find(adminUserId);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InstituteStatistics instituteStatistics = db.InstituteStatistics.Find(id);
            if (instituteStatistics == null)
            {
                return HttpNotFound();
            }
            return View(instituteStatistics);
        }

        // GET: ViewInstituteStatistics/Create
        public ActionResult Create()
        {
            var db = api_data_bd.Utiles.Static.AppDatabase.getInstence().getDatabase();
            int adminUserId = (int)Session["AdminUserID"];
            ViewBag.currentAdminUser = db.AdminUsers.Find(adminUserId);

            ViewBag.InstituitionId = new SelectList(db.Instituitions, "InstituitionId", "InstituitionName");
            return View();
        }

        // POST: ViewInstituteStatistics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InstituteStatisticsId,InstituteStatisticsMaleTeacher,InstituteStatisticsFemaleTeacher,InstituteStatisticsYear,InstituteStatisticsBoysStudent,InstituteStatisticsGirlsStudent,InstituitionId")] InstituteStatistics instituteStatistics)
        {
            if (ModelState.IsValid)
            {
                db.InstituteStatistics.Add(instituteStatistics);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InstituitionId = new SelectList(db.Instituitions, "InstituitionId", "InstituitionName", instituteStatistics.InstituitionId);
            return View(instituteStatistics);
        }

        // GET: ViewInstituteStatistics/Edit/5
        public ActionResult Edit(int? id)
        {

            var db = api_data_bd.Utiles.Static.AppDatabase.getInstence().getDatabase();
            int adminUserId = (int)Session["AdminUserID"];
            ViewBag.currentAdminUser = db.AdminUsers.Find(adminUserId);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InstituteStatistics instituteStatistics = db.InstituteStatistics.Find(id);
            if (instituteStatistics == null)
            {
                return HttpNotFound();
            }
            ViewBag.InstituitionId = new SelectList(db.Instituitions, "InstituitionId", "InstituitionName", instituteStatistics.InstituitionId);
            return View(instituteStatistics);
        }

        // POST: ViewInstituteStatistics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InstituteStatisticsId,InstituteStatisticsMaleTeacher,InstituteStatisticsFemaleTeacher,InstituteStatisticsYear,InstituteStatisticsBoysStudent,InstituteStatisticsGirlsStudent,InstituitionId")] InstituteStatistics instituteStatistics)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instituteStatistics).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InstituitionId = new SelectList(db.Instituitions, "InstituitionId", "InstituitionName", instituteStatistics.InstituitionId);
            return View(instituteStatistics);
        }

        // GET: ViewInstituteStatistics/Delete/5
        public ActionResult Delete(int? id)
        {
            var db = api_data_bd.Utiles.Static.AppDatabase.getInstence().getDatabase();
            int adminUserId = (int)Session["AdminUserID"];
            ViewBag.currentAdminUser = db.AdminUsers.Find(adminUserId);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InstituteStatistics instituteStatistics = db.InstituteStatistics.Find(id);
            if (instituteStatistics == null)
            {
                return HttpNotFound();
            }
            return View(instituteStatistics);
        }

        // POST: ViewInstituteStatistics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InstituteStatistics instituteStatistics = db.InstituteStatistics.Find(id);
            db.InstituteStatistics.Remove(instituteStatistics);
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
