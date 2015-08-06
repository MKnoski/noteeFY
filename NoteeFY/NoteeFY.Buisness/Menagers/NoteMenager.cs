using NoteeFY.Data.DBContext;
using NoteeFY.Models;
using System.Collections.Generic;

namespace NoteeFY.Buisness.Menagers
{
    class NoteMenager
    {
        private NoteeContext db = new NoteeContext();

        // GET api/Attractions
        public IEnumerable<Note> GetNotes()
        {
            return db.Notes;
        }
    }
}
