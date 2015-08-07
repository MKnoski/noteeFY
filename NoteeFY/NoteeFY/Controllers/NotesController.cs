using NoteeFY.Buisness.DTOs;
using NoteeFY.Buisness.Managers;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace NoteeFY.Controllers
{
    public class NotesController : ApiController
    {
        private NoteManager noteManager = new NoteManager();

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

    }
}
