using NoteeFY.Buisness.DTOs;
using NoteeFY.Data.DBContext;
using NoteeFY.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace NoteeFY.Buisness.Managers
{
    public class NoteManagers
    { 
        public List<NoteDTO> GetNotes()
        {
            using(NoteeContext db = new NoteeContext())
            {
                return db.Notes.ToList().Select(n => new NoteDTO(n)).ToList();
            }
        }

        public NoteDTO GetNote(int id)
        {
            using (NoteeContext db = new NoteeContext())
            {
                var note = db.Notes.Find(id);
                if (note == null) return null;
                else return new NoteDTO(note);
            }
        }
    }
}