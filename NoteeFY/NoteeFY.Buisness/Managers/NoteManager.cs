using NoteeFY.Buisness.DTOs;
using NoteeFY.Data.DBContext;
using NoteeFY.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace NoteeFY.Buisness.Managers
{
    public class NoteManager
    { 
        public List<NoteDTO> GetNotes()
        {
            using(NoteeContext db = new NoteeContext())
            {
                return db.Notes.Select(n => new NoteDTO
                {
                    NoteID = n.NoteID,
                    Title = n.Title,
                    Text = n.Text,
                    Type = n.Type,
                    TaskItems = n.TaskItems.ToList()
                }).ToList();
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