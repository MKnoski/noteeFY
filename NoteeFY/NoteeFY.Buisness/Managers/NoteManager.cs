using NoteeFY.Data.DBContext;
using NoteeFY.Models;
using System.Linq;
using System.Web.Http;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace NoteeFY.Buisness.Menagers
{
    public class NoteManager
    {
        private NoteeContext db = new NoteeContext();

        public IQueryable<Note> GetNotes()
        {
            return db.Notes;
        }

        public Note GetNote(int id)
        {
            return db.Notes.Find(id);
        }
    }
}