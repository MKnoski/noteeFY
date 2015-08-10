using NoteeFY.Buisness.DTOs;
using NoteeFY.Buisness.Managers;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace NoteeFY.Controllers
{
    public class NotesController : ApiController
    {
        private NotesManager noteManager = new NotesManager();

        // GET: api/Notes - READ 
        public List<NoteDTO> GetNotes()
        {
            return noteManager.GetNotes();
        }

        // GET: api/Notes/5 - READ Single
        [ResponseType(typeof(NoteDTO))]
        public IHttpActionResult GetNote(int id)
        {
            NoteDTO noteDTO = noteManager.GetNote(id);
            if (noteDTO == null) return NotFound();
            return Ok(noteDTO);
        }

        // POST: api/Notes
        [ResponseType(typeof(NoteDTO))]
        public IHttpActionResult PostNote(NoteDTO note)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool result = noteManager.AddOrUpdateNote(note);

            if (result) return CreatedAtRoute("DefaultApi", new { id = note.NoteID }, note);
            else return NotFound();
        }

    }
}
