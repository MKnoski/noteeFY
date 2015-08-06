using NoteeFY.Data.DBContext;
using NoteeFY.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace NoteeFY.Buisness.Managers
{
    public class NoteManager
    { 
        public IQueryable<Note> GetNotes()
        {
            using(NoteeContext db = new NoteeContext())
            {
                return db.Notes;
            }
        }

        public Note GetNote(int id)
        {
            using (NoteeContext db = new NoteeContext())
            {
                return db.Notes.Find(id);
            }
        }

        /*
        public async Task<bool> PutNote(int id, Note note)
        {
            db.Entry(note).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (db.Notes.Count(e => e.NoteID == id) > 0) return false;
                else throw;
            }
            return true;
        }

        public async void PutNote(Note note)
        {
            db.Notes.Add(note);
            await db.SaveChangesAsync();
        }*/
    }
}