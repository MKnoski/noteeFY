using NoteeFY.Buisness.Managers;
using NoteeFY.Data.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace NoteeFY.Controllers
{
    public class NotesController : ApiController
    {
        private NoteManager nt = new NoteManager();

        // GET: api/Notes - READ 
        public List<Note> GetNotes()
        {
            return nt.GetNotes();
        }

        // GET: api/Notes/5 - READ Single
        [ResponseType(typeof(Note))]
        public IHttpActionResult GetNote(int id)
        {
            Note note = nt.GetNote(id);
            if (note == null) return NotFound();
            return Ok(note);
        }

    }
}
