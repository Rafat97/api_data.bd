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
    public class InstituteStatisticsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/InstituteStatistics
        public IQueryable<InstituteStatistics> GetInstituteStatistics()
        {
            return db.InstituteStatistics;
        }

        // GET: api/InstituteStatistics/5
        [ResponseType(typeof(InstituteStatistics))]
        public async Task<IHttpActionResult> GetInstituteStatistics(int id)
        {
            InstituteStatistics instituteStatistics = await db.InstituteStatistics.FindAsync(id);
            if (instituteStatistics == null)
            {
                return NotFound();
            }

            return Ok(instituteStatistics);
        }

        // PUT: api/InstituteStatistics/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutInstituteStatistics(int id, InstituteStatistics instituteStatistics)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != instituteStatistics.InstituteStatisticsId)
            {
                return BadRequest();
            }

            db.Entry(instituteStatistics).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstituteStatisticsExists(id))
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

        // POST: api/InstituteStatistics
        [ResponseType(typeof(InstituteStatistics))]
        public async Task<IHttpActionResult> PostInstituteStatistics(InstituteStatistics instituteStatistics)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InstituteStatistics.Add(instituteStatistics);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = instituteStatistics.InstituteStatisticsId }, instituteStatistics);
        }

        // DELETE: api/InstituteStatistics/5
        [ResponseType(typeof(InstituteStatistics))]
        public async Task<IHttpActionResult> DeleteInstituteStatistics(int id)
        {
            InstituteStatistics instituteStatistics = await db.InstituteStatistics.FindAsync(id);
            if (instituteStatistics == null)
            {
                return NotFound();
            }

            db.InstituteStatistics.Remove(instituteStatistics);
            await db.SaveChangesAsync();

            return Ok(instituteStatistics);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InstituteStatisticsExists(int id)
        {
            return db.InstituteStatistics.Count(e => e.InstituteStatisticsId == id) > 0;
        }
    }
}