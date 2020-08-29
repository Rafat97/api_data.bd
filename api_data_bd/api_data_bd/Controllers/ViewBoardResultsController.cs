using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using api_data_bd.Models;

namespace api_data_bd.Controllers
{
    public class ViewBoardResultsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ViewBoardResults
        public async Task<ActionResult> Index()
        {
            return View(await db.BoardResults.ToListAsync());
        }

        // GET: ViewBoardResults/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardResult boardResult = await db.BoardResults.FindAsync(id);
            if (boardResult == null)
            {
                return HttpNotFound();
            }
            return View(boardResult);
        }

        // GET: ViewBoardResults/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ViewBoardResults/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "BoardResultId,Year,ResultType,ExamAttendence,GpaFiveStudentNumber,FailStudentNumber")] BoardResult boardResult)
        {
            if (ModelState.IsValid)
            {
                db.BoardResults.Add(boardResult);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(boardResult);
        }

        // GET: ViewBoardResults/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardResult boardResult = await db.BoardResults.FindAsync(id);
            if (boardResult == null)
            {
                return HttpNotFound();
            }
            return View(boardResult);
        }

        // POST: ViewBoardResults/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "BoardResultId,Year,ResultType,ExamAttendence,GpaFiveStudentNumber,FailStudentNumber")] BoardResult boardResult)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boardResult).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(boardResult);
        }

        // GET: ViewBoardResults/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardResult boardResult = await db.BoardResults.FindAsync(id);
            if (boardResult == null)
            {
                return HttpNotFound();
            }
            return View(boardResult);
        }

        // POST: ViewBoardResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            BoardResult boardResult = await db.BoardResults.FindAsync(id);
            db.BoardResults.Remove(boardResult);
            await db.SaveChangesAsync();
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
