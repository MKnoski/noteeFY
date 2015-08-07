using NoteeFY.Data.DBContext;
using NoteeFY.Data.Models;
using System.Collections.Generic;
using System.Linq;

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
    }
}