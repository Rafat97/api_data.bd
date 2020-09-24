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
    public class ViewInstituitionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ViewInstituitions
        public ActionResult Index()
        {
            ViewBag.currentAdminUser = AuthAdminUser.getAdminUser();
            var instituitions = db.Instituitions.Include(i => i.InstituitionAddress);
            return View(instituitions.ToList());
        }

        // GET: ViewInstituitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instituitions instituitions = db.Instituitions.Find(id);
            if (instituitions == null)
            {
                return HttpNotFound();
            }
            return View(instituitions);
        }

        // GET: ViewInstituitions/Create
        public ActionResult Create()
        {
            ViewBag.currentAdminUser = AuthAdminUser.getAdminUser();

            ViewBag.InstituitionAddressId = new SelectList(db.InstituitionsAddresses, "InstituitionAddressId", "InstituitionAddressUnion");
            return View();
        }

        // POST: ViewInstituitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InstituitionId,InstituitionName,InstituitionEstablishment,InstituitionType,InstituitionEiin,InstituitionPhoneNumber,InstituitionManagementType,InstituitionEducationLevel,InstituitionAddressId")] Instituitions instituitions)
        {
            if (ModelState.IsValid)
            {
                db.Instituitions.Add(instituitions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InstituitionAddressId = new SelectList(db.InstituitionsAddresses, "InstituitionAddressId", "InstituitionAddressUnion", instituitions.InstituitionAddressId);
            return View(instituitions);
        }

        // GET: ViewInstituitions/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.currentAdminUser = AuthAdminUser.getAdminUser();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instituitions instituitions = db.Instituitions.Find(id);
            if (instituitions == null)
            {
                return HttpNotFound();
            }
            ViewBag.InstituitionAddressId = new SelectList(db.InstituitionsAddresses, "InstituitionAddressId", "InstituitionAddressUnion", instituitions.InstituitionAddressId);
            return View(instituitions);
        }

        // POST: ViewInstituitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InstituitionId,InstituitionName,InstituitionEstablishment,InstituitionType,InstituitionEiin,InstituitionPhoneNumber,InstituitionManagementType,InstituitionEducationLevel,InstituitionAddressId")] Instituitions instituitions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instituitions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InstituitionAddressId = new SelectList(db.InstituitionsAddresses, "InstituitionAddressId", "InstituitionAddressUnion", instituitions.InstituitionAddressId);
            return View(instituitions);
        }

        // GET: ViewInstituitions/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.currentAdminUser = AuthAdminUser.getAdminUser();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instituitions instituitions = db.Instituitions.Find(id);
            if (instituitions == null)
            {
                return HttpNotFound();
            }
            return View(instituitions);
        }

        // POST: ViewInstituitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Instituitions instituitions = db.Instituitions.Find(id);
            IEnumerable<BoardResult> boardResults = instituitions.BoardResult;
            IEnumerable<InstituteStatistics> instituteStatistics = instituitions.InstituteStatistics;
            foreach (var data in boardResults)
                data.Instituitions = null;
            foreach (var data in instituteStatistics)
                data.Instituitions = null;

            db.Instituitions.Remove(instituitions);
            db.SaveChanges();
            //return RedirectToAction("Index");
           
            return new HttpStatusCodeResult(HttpStatusCode.OK); ;
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
