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
    public class BoardResultsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/BoardResults
        public IQueryable<BoardResult> GetBoardResults()
        {
            return db.BoardResults;
        }

        // GET: api/BoardResults/5
        [ResponseType(typeof(BoardResult))]
        public async Task<IHttpActionResult> GetBoardResult(string id)
        {
            BoardResult boardResult = await db.BoardResults.FindAsync(id);
            if (boardResult == null)
            {
                return NotFound();
            }

            return Ok(boardResult);
        }

        // PUT: api/BoardResults/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBoardResult(int id, BoardResult boardResult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != boardResult.BoardResultId)
            {
                return BadRequest();
            }

            db.Entry(boardResult).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoardResultExists(id))
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

        // POST: api/BoardResults
        [ResponseType(typeof(BoardResult))]
        public async Task<IHttpActionResult> PostBoardResult(BoardResult boardResult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BoardResults.Add(boardResult);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BoardResultExists(boardResult.BoardResultId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = boardResult.BoardResultId }, boardResult);
        }

        // DELETE: api/BoardResults/5
        [ResponseType(typeof(BoardResult))]
        public async Task<IHttpActionResult> DeleteBoardResult(string id)
        {
            BoardResult boardResult = await db.BoardResults.FindAsync(id);
            if (boardResult == null)
            {
                return NotFound();
            }

            db.BoardResults.Remove(boardResult);
            await db.SaveChangesAsync();

            return Ok(boardResult);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BoardResultExists(int id)
        {
            return db.BoardResults.Count(e => e.BoardResultId == id) > 0;
        }
    }
}