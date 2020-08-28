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
    public class ViewInstituitionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ViewInstituitions
        public async Task<ActionResult> Index()
        {
            var instituitions = db.Instituitions.Include(i => i.InstituitionAddress);
            return View(await instituitions.ToListAsync());
        }

        // GET: ViewInstituitions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instituitions instituitions = await db.Instituitions.FindAsync(id);
            if (instituitions == null)
            {
                return HttpNotFound();
            }
            return View(instituitions);
        }

        // GET: ViewInstituitions/Create
        public ActionResult Create()
        {
            ViewBag.InstituitionAddressId = new SelectList(db.InstituitionsAddresses, "InstituitionAddressId", "InstituitionAddressUnion");
            return View();
        }

        // POST: ViewInstituitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "InstituitionId,InstituitionName,InstituitionEstablishment,InstituitionType,InstituitionEiin,InstituitionPhoneNumber,InstituitionManagementType,InstituitionEducationLevel,InstituitionAddressId")] Instituitions instituitions)
        {
            if (ModelState.IsValid)
            {
                db.Instituitions.Add(instituitions);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.InstituitionAddressId = new SelectList(db.InstituitionsAddresses, "InstituitionAddressId", "InstituitionAddressUnion", instituitions.InstituitionAddressId);
            return View(instituitions);
        }

        // GET: ViewInstituitions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instituitions instituitions = await db.Instituitions.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "InstituitionId,InstituitionName,InstituitionEstablishment,InstituitionType,InstituitionEiin,InstituitionPhoneNumber,InstituitionManagementType,InstituitionEducationLevel,InstituitionAddressId")] Instituitions instituitions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instituitions).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.InstituitionAddressId = new SelectList(db.InstituitionsAddresses, "InstituitionAddressId", "InstituitionAddressUnion", instituitions.InstituitionAddressId);
            return View(instituitions);
        }

        // GET: ViewInstituitions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instituitions instituitions = await db.Instituitions.FindAsync(id);
            if (instituitions == null)
            {
                return HttpNotFound();
            }
            return View(instituitions);
        }

        // POST: ViewInstituitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Instituitions instituitions = await db.Instituitions.FindAsync(id);
            db.Instituitions.Remove(instituitions);
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
