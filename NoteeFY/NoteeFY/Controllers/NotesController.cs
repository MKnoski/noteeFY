using NoteeFY.Buisness.DTOs;
using NoteeFY.Buisness.Managers;
using NoteeFY.Data.Models;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;

namespace NoteeFY.Controllers
{
    public class NotesController : ApiControllerBase
    {
        private NotesManager noteManager = new NotesManager();

        // GET: api/Notes/5 - READ
        [ResponseType(typeof(NoteDTO))]
        public IHttpActionResult GetNote(int id)
        {
            var noteDto = noteManager.GetNote(id);
            return noteDto == null ? (IHttpActionResult) NotFound() : Ok(noteDto);
        }

        // POST: api/Notes - ADD or UPDATE
        public JsonResult<ModificationResult<NoteDTO>> PostNote(NoteDTO note)
        {
            var result = ValidateModelState<NoteDTO>();
            if (result != null)
            {
                return result;
            }

            if (noteManager.AddOrUpdateNote(note))
            {
                return Json(new ModificationResult<NoteDTO>(true)
                {
                    Data = note
                });
            }
            else
            {
                return Json(new ModificationResult<NoteDTO>("error: nie znaleziono uzytkownika (nie mozna dolaczyc tej notatki do uzytkownika o id: " + note.UserID + ")"));
            }
        }

        // DELETE: api/Notes/3 - DELETE
        public JsonResult<ModificationResult<NoteDTO>> DeleteNote(int id)
        {
            if (noteManager.DeleteNote(id))
            {
                return Json(new ModificationResult<NoteDTO>(true));
            }
            else
            {
                return
                    Json(
                        new ModificationResult<NoteDTO>(
                            "error: nie znaleziono notatki (nie mozna odnalezc notatki o id: " + id + ")"));
            }
        }
    }
}
