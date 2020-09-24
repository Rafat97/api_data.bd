using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using api_data_bd.Models;

namespace api_data_bd.Controllers
{
    public class StudentsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Students
        /// <summary>
        /// This api Url to get all Students Information
        /// </summary>
        public IQueryable<Students> GetStudents()
        {
            return db.Students;
        }

        // GET: api/Students/5
        /// <summary>
        /// This api Url to get a student Information
        /// </summary>
        /// <param name="id">The ID of the data.</param>
        [ResponseType(typeof(Students))]
        public IHttpActionResult GetStudents(int id)
        {
            Students students = db.Students.Find(id);
            if (students == null)
            {
                return NotFound();
            }

            return Ok(students);
        }

        // PUT: api/Students/5
        /// <summary>
        /// This api Url to update single  student Information
        /// </summary>
        /// <param name="id">The ID of the data.</param>
        /// <param name="students">The student information of the data</param>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudents(int id, Students students)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != students.StudentId)
            {
                return BadRequest();
            }

            db.Entry(students).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentsExists(id))
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

        // POST: api/Students
        /// <summary>
        /// This api Url to create single student Information
        /// </summary>
        /// <param name="students">The student information of the data</param>
        [ResponseType(typeof(Students))]
        public IHttpActionResult PostStudents(Students students)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Students.Add(students);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = students.StudentId }, students);
        }

        // DELETE: api/Students/5
        /// <summary>
        /// This api Url to delete single student Information
        /// </summary>
        /// <param name="id">The ID of the data.</param>
        [ResponseType(typeof(Students))]
        public IHttpActionResult DeleteStudents(int id)
        {
            Students students = db.Students.Find(id);
            if (students == null)
            {
                return NotFound();
            }

            db.Students.Remove(students);
            db.SaveChanges();

            return Ok(students);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentsExists(int id)
        {
            return db.Students.Count(e => e.StudentId == id) > 0;
        }
    }
}