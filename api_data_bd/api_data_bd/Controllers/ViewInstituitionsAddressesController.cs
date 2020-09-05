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
using api_data_bd.Utiles.Action;
using api_data_bd.Utiles.Static;
using System.Web.Http.Description;

namespace api_data_bd.Controllers
{
    [AdminAuthrization]
    public class ViewInstituitionsAddressesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ViewInstituitionsAddresses
        public async Task<ActionResult> Index()
        {
            ViewBag.currentAdminUser = AuthAdminUser.getAdminUser();

            return View(await db.InstituitionsAddresses.ToListAsync());
        }

        // GET: ViewInstituitionsAddresses/Details/5
        public async Task<ActionResult> Details(int? id)
        {

            ViewBag.currentAdminUser = AuthAdminUser.getAdminUser();

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
            ViewBag.currentAdminUser = AuthAdminUser.getAdminUser();

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

            ViewBag.currentAdminUser = AuthAdminUser.getAdminUser();

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

        [ResponseType(typeof(InstituitionsAddress))]
        public async Task<ActionResult> Delete(int id)
        {
            ViewBag.currentAdminUser = AuthAdminUser.getAdminUser();


            InstituitionsAddress instituitionsAddress = await db.InstituitionsAddresses.FindAsync(id);
            /*
            if (instituitionsAddress == null)
            {
                return NotFound();
            }

            db.InstituitionsAddresses.Remove(instituitionsAddress);
            await db.SaveChangesAsync();
            return Ok(instituitionsAddress);
            */
            db.InstituitionsAddresses.Remove(instituitionsAddress);
            await db.SaveChangesAsync();
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
