using NoteeFY.Buisness.DTOs;
using NoteeFY.Buisness.Managers;
using NoteeFY.Data.Models;
using System.Web.Http;
using System.Web.Http.Description;

namespace NoteeFY.Controllers
{
    public class NotesController : ApiController
    {
        private NotesManager noteManager = new NotesManager();

        // GET: api/Notes/5 - READ
        [ResponseType(typeof(NoteDTO))]
        public IHttpActionResult GetNote(int id)
        {
            NoteDTO noteDTO = noteManager.GetNote(id);
            if (noteDTO == null)
            {
                return NotFound();
            }
            return Ok(noteDTO);
        }

        // POST: api/Notes - ADD or UPDATE
        [ResponseType(typeof(SaveResult<string>))]
        public SaveResult<string> PostNote(NoteDTO note)
        {
            if (!ModelState.IsValid)
            {
                return new SaveResult<string>("error: bad request", false);
            }

            if (noteManager.AddOrUpdateNote(note))
            {
                return new SaveResult<string>("success: note created/updated", true);
            }
            else
            {
                return new SaveResult<string>("error: user not found (can not join this note to the user with id: " + note.UserID + ")", false);
            }
        }

        // DELETE: api/Notes/3 - DELETE
        [ResponseType(typeof(NoteDTO))]
        public IHttpActionResult DeleteNote(int id)
        {
            if (noteManager.DeleteNote(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

    }
}
