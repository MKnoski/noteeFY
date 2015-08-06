using NoteeFY.Buisness.Managers;
using NoteeFY.Data.Models;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace NoteeFY.Controllers
{
    public class NotesController : ApiController
    {
        private NoteManager nt = new NoteManager();

        // GET: api/Notes - READ 
        public IQueryable<Note> GetNotes()
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
        /*
        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        #pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<IHttpActionResult> PutNote(Note note, int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (id != note.NoteID) return BadRequest();

            if (nt.PutNote(id, note).IsCompleted == true) return StatusCode(HttpStatusCode.NoContent);
            else return NotFound();
        }

        // POST: api/Products - CREATE
        [ResponseType(typeof(Note))]
        public async Task<IHttpActionResult> PostNote(Note note)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            nt.PutNote(note);
            return CreatedAtRoute("DefaultApi", new { id = note.NoteID }, note);
        }

        // DELETE: api/Products/5 - DELETE
        [ResponseType(typeof(Note))]
        public async Task<IHttpActionResult> DeleteProduct(int id)
        {
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            await db.SaveChangesAsync();

            return Ok(product);
        }*/
    }
}
