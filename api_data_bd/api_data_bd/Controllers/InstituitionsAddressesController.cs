using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using api_data_bd.Models;

namespace api_data_bd.Controllers
{
    public class InstituitionsAddressesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/InstituitionsAddresses
        public IQueryable<InstituitionsAddress> GetInstituitionsAddresses()
        {
            return db.InstituitionsAddresses;
        }

        // GET: api/InstituitionsAddresses/5
        [ResponseType(typeof(InstituitionsAddress))]
        public async Task<IHttpActionResult> GetInstituitionsAddress(int id)
        {
            InstituitionsAddress instituitionsAddress = await db.InstituitionsAddresses.FindAsync(id);
            if (instituitionsAddress == null)
            {
                return NotFound();
            }

            return Ok(instituitionsAddress);
        }

        // PUT: api/InstituitionsAddresses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutInstituitionsAddress(int id, InstituitionsAddress instituitionsAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != instituitionsAddress.InstituitionAddressId)
            {
                return BadRequest();
            }

            db.Entry(instituitionsAddress).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstituitionsAddressExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/InstituitionsAddresses
        [ResponseType(typeof(InstituitionsAddress))]
        public async Task<IHttpActionResult> PostInstituitionsAddress(InstituitionsAddress instituitionsAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InstituitionsAddresses.Add(instituitionsAddress);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = instituitionsAddress.InstituitionAddressId }, instituitionsAddress);
        }

        // DELETE: api/InstituitionsAddresses/5
        [ResponseType(typeof(InstituitionsAddress))]
        public async Task<IHttpActionResult> DeleteInstituitionsAddress(int id)
        {
            InstituitionsAddress instituitionsAddress = await db.InstituitionsAddresses.FindAsync(id);
            if (instituitionsAddress == null)
            {
                return NotFound();
            }

            db.InstituitionsAddresses.Remove(instituitionsAddress);
            await db.SaveChangesAsync();

            return Ok(instituitionsAddress);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InstituitionsAddressExists(int id)
        {
            return db.InstituitionsAddresses.Count(e => e.InstituitionAddressId == id) > 0;
        }
    }
}