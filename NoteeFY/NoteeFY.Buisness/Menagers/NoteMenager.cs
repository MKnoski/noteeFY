using NoteeFY.Data.DBContext;
using NoteeFY.Models;
using System.Linq;

namespace NoteeFY.Buisness.Menagers
{
    class NoteMenager
    {
        private NoteeContext db = new NoteeContext();

        // GET: api/Products
        public IQueryable<Note> GetNotes()
        {
            return db.Notes;
        }
    }
}