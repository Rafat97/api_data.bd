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
    public class ViewInstituitionsAddressesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ViewInstituitionsAddresses
        public async Task<ActionResult> Index()
        {
            return View(await db.InstituitionsAddresses.ToListAsync());
        }

        // GET: ViewInstituitionsAddresses/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InstituitionsAddress instituitionsAddress = await db.InstituitionsAddresses.FindAsync(id);
            if (instituitionsAddress == null)
            {
                return HttpNotFound();
            }
            return View(instituitionsAddress);
        }

        // GET: ViewInstituitionsAddresses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ViewInstituitionsAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "InstituitionAddressId,InstituitionAddressUnion,InstituitionAddressThana,InstituitionAddressDivision,InstituitionAddressDistrict")] InstituitionsAddress instituitionsAddress)
        {
            if (ModelState.IsValid)
            {
                db.InstituitionsAddresses.Add(instituitionsAddress);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(instituitionsAddress);
        }

        // GET: ViewInstituitionsAddresses/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InstituitionsAddress instituitionsAddress = await db.InstituitionsAddresses.FindAsync(id);
            if (instituitionsAddress == null)
            {
                return HttpNotFound();
            }
            return View(instituitionsAddress);
        }

        // POST: ViewInstituitionsAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "InstituitionAddressId,InstituitionAddressUnion,InstituitionAddressThana,InstituitionAddressDivision,InstituitionAddressDistrict")] InstituitionsAddress instituitionsAddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instituitionsAddress).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(instituitionsAddress);
        }

        // GET: ViewInstituitionsAddresses/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InstituitionsAddress instituitionsAddress = await db.InstituitionsAddresses.FindAsync(id);
            if (instituitionsAddress == null)
            {
                return HttpNotFound();
            }
            return View(instituitionsAddress);
        }

        // POST: ViewInstituitionsAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            InstituitionsAddress instituitionsAddress = await db.InstituitionsAddresses.FindAsync(id);
            db.InstituitionsAddresses.Remove(instituitionsAddress);
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
