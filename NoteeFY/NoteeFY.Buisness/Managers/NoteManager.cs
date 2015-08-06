using NoteeFY.Data.DBContext;
using NoteeFY.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http.Description;
using System.Web.Http;

namespace NoteeFY.Buisness.Menagers
{
    public class NoteManager
    {
        private NoteeContext db = new NoteeContext();

        // GET: api/Notes - READ
        public IQueryable<Note> GetNotes()
        {
            return db.Notes;
        }
        
        /*
        // GET: api/Notes/5 - READ Single
        [ResponseType(typeof(Note))]
        public IHttpActionResult GetNote(int id)
        {
            Note note = db.Notes.Find(id);
            if (note == null)
            {
                return NotFound();
            }
            return Ok(note);
        }*/

    }
}