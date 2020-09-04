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
using api_data_bd.Utiles.Static;

namespace api_data_bd.Controllers
{
    [AdminAuthrization]
    public class ViewBoardResultsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ViewBoardResults
        public ActionResult Index()
        {
            ViewBag.currentAdminUser = AuthAdminUser.getAdminUser();

            var boardResults = db.BoardResults.Include(b => b.Instituitions);
            return View(boardResults.ToList());
        }

        // GET: ViewBoardResults/Details/5
        public ActionResult Details(int? id)
        {

            ViewBag.currentAdminUser = AuthAdminUser.getAdminUser();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardResult boardResult = db.BoardResults.Find(id);
            if (boardResult == null)
            {
                return HttpNotFound();
            }
            return View(boardResult);
        }

        // GET: ViewBoardResults/Create
        public ActionResult Create()
        {

            ViewBag.currentAdminUser = AuthAdminUser.getAdminUser();

            ViewBag.InstituitionId = new SelectList(db.Instituitions, "InstituitionId", "InstituitionName");
            return View();
        }

        // POST: ViewBoardResults/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BoardResultId,Year,ResultType,ExamAttendence,GpaFiveStudentNumber,FailStudentNumber,InstituitionId")] BoardResult boardResult)
        {
            if (ModelState.IsValid)
            {
                db.BoardResults.Add(boardResult);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InstituitionId = new SelectList(db.Instituitions, "InstituitionId", "InstituitionName", boardResult.InstituitionId);
            return View(boardResult);
        }

        // GET: ViewBoardResults/Edit/5
        public ActionResult Edit(int? id)
        {

            ViewBag.currentAdminUser = AuthAdminUser.getAdminUser();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardResult boardResult = db.BoardResults.Find(id);
            if (boardResult == null)
            {
                return HttpNotFound();
            }
            ViewBag.InstituitionId = new SelectList(db.Instituitions, "InstituitionId", "InstituitionName", boardResult.InstituitionId);
            return View(boardResult);
        }

        // POST: ViewBoardResults/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BoardResultId,Year,ResultType,ExamAttendence,GpaFiveStudentNumber,FailStudentNumber,InstituitionId")] BoardResult boardResult)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boardResult).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InstituitionId = new SelectList(db.Instituitions, "InstituitionId", "InstituitionName", boardResult.InstituitionId);
            return View(boardResult);
        }

        // GET: ViewBoardResults/Delete/5
        public ActionResult Delete(int? id)
        {

            ViewBag.currentAdminUser = AuthAdminUser.getAdminUser();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardResult boardResult = db.BoardResults.Find(id);
            if (boardResult == null)
            {
                return HttpNotFound();
            }
            return View(boardResult);
        }

        // POST: ViewBoardResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BoardResult boardResult = db.BoardResults.Find(id);
            db.BoardResults.Remove(boardResult);
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
