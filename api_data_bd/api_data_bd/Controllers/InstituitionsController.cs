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
    public class InstituitionsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: api/Instituitions
        /// <summary>
        /// This api Url to get all Instituitions Information
        /// </summary>
        public IQueryable<Instituitions> GetInstituitions()
        {
            return db.Instituitions;
        }

        // GET: api/Instituitions
        /// <summary>
        /// This api Url to get an Instituitions Information
        /// </summary>
        /// <param name="id">The ID of the data.</param>
        // GET: api/Instituitions/5
        [ResponseType(typeof(Instituitions))]
        public async Task<IHttpActionResult> GetInstituitions(int id)
        {
            Instituitions instituitions = await db.Instituitions.FindAsync(id);
            if (instituitions == null)
            {
                return NotFound();
            }

            return Ok(instituitions);
        }

        // PUT: api/Instituitions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutInstituitions(int id, Instituitions instituitions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != instituitions.InstituitionId)
            {
                return BadRequest();
            }

            db.Entry(instituitions).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstituitionsExists(id))
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

        // POST: api/Instituitions
        [ResponseType(typeof(Instituitions))]
        public async Task<IHttpActionResult> PostInstituitions(Instituitions instituitions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Instituitions.Add(instituitions);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = instituitions.InstituitionId }, instituitions);
        }

        // DELETE: api/Instituitions/5
        [ResponseType(typeof(Instituitions))]
        public async Task<IHttpActionResult> DeleteInstituitions(int id)
        {
            Instituitions instituitions = await db.Instituitions.FindAsync(id);
            if (instituitions == null)
            {
                return NotFound();
            }

            db.Instituitions.Remove(instituitions);
            await db.SaveChangesAsync();

            return Ok(instituitions);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InstituitionsExists(int id)
        {
            return db.Instituitions.Count(e => e.InstituitionId == id) > 0;
        }
    }
}