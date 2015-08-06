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
using NoteeFY.Models;

namespace NoteeFY.Controllers
{
    public class _TaskController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/_Task
        public IQueryable<_Task> Get_Task()
        {
            return db._Task;
        }

        // GET: api/_Task/5
        [ResponseType(typeof(_Task))]
        public IHttpActionResult Get_Task(int id)
        {
            _Task _Task = db._Task.Find(id);
            if (_Task == null)
            {
                return NotFound();
            }

            return Ok(_Task);
        }

        // PUT: api/_Task/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put_Task(int id, _Task _Task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != _Task._TaskId)
            {
                return BadRequest();
            }

            db.Entry(_Task).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_TaskExists(id))
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

        // POST: api/_Task
        [ResponseType(typeof(_Task))]
        public IHttpActionResult Post_Task(_Task _Task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db._Task.Add(_Task);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = _Task._TaskId }, _Task);
        }

        // DELETE: api/_Task/5
        [ResponseType(typeof(_Task))]
        public IHttpActionResult Delete_Task(int id)
        {
            _Task _Task = db._Task.Find(id);
            if (_Task == null)
            {
                return NotFound();
            }

            db._Task.Remove(_Task);
            db.SaveChanges();

            return Ok(_Task);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool _TaskExists(int id)
        {
            return db._Task.Count(e => e._TaskId == id) > 0;
        }
    }
}