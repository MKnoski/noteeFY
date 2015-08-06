using NoteeFY.Buisness.Menagers;
using NoteeFY.Models;
using System.Linq;
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
            if (note == null)
            {
                return NotFound();
            }
            return Ok(note);
        }


        /* IN PROGRES
        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }*/
    }
}
