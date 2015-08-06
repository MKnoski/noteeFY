using NoteeFY.Data.DBContext;
using NoteeFY.Data.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace NoteeFY.Buisness.Managers
{
    public class NoteManager
    { 
        public List<Note> GetNotes()
        {
            using(NoteeContext db = new NoteeContext())
            {
                return db.Notes.ToList();
            }
        }

        public Note GetNote(int id)
        {
            using (NoteeContext db = new NoteeContext())
            {
                return db.Notes.Find(id);
            }
        }

        /* TO DO post put
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