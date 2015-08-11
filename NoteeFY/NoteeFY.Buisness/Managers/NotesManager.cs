using NoteeFY.Buisness.DTOs;
using NoteeFY.Data.DBContext;
using NoteeFY.Data.Models;
using System.Linq;

namespace NoteeFY.Buisness.Managers
{
    public class NotesManager
    { 
        public NoteDTO GetNote(int id)
        {
            using (NoteeContext db = new NoteeContext())
            {
                var note = db.Notes.SingleOrDefault(n => n.NoteID == id);
                if (note == null)
                {
                    return null;
                }
                else
                {
                    return new NoteDTO(note);
                }
            }
        }

        public bool AddOrUpdateNote(NoteDTO note)
        {
            Note model;
            using (NoteeContext db = new NoteeContext())
            {
                if (db.Users.Any(u => u.UserID == note.UserID))
                {
                    if (note.NoteID > 0)
                    {
                        model = db.Notes.Single(n => n.NoteID == note.NoteID);
                    }
                    else
                    {
                        model = db.Notes.Create();
                        model.User = db.Users.Single(n => n.UserID == note.UserID);
                        db.Notes.Add(model);
                    }

                    model.Title = note.Title;
                    model.Text = note.Text;
                    model.Type = note.Type;

                    db.SaveChanges();

                }
                else
                {
                    return false;
                }
            }

            new TaskItemsManager().AddOrUpdateTaskItems(model.NoteID, note.TaskItems);
            return true;
        }


        public bool DeleteNote(int id)
        {
            using (NoteeContext db = new NoteeContext())
            {
                Note note = db.Notes.SingleOrDefault(n => n.NoteID == id);
                if (note == null)
                {
                    return false;
                }
                else
                {
                    db.Notes.Remove(note);
                    db.SaveChanges();
                    return true;
                }
            }
        }

    }
}