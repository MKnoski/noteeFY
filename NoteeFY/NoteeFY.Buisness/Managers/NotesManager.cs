using NoteeFY.Buisness.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using NoteeFY.Data;

namespace NoteeFY.Buisness.Managers
{
    public class NotesManager
    {

        public NoteDTO GetNote(int id, string authorizedUserID)
        {
            using (var db = new NoteeContext())
            {
                var note = db.Notes.SingleOrDefault(n => n.NoteID == id);
                var user = db.SubUsers.SingleOrDefault(u => u.UserID == note.UserID);
                if (user.UserID != authorizedUserID)
                {
                    return null;
                }
                return note == null ? null : new NoteDTO(note);
            }
        }

        public void AddOrUpdateNotes(string userId, IEnumerable<NoteDTO> notes)
        {
            foreach (var note in notes)
            {
                using (var db = new NoteeContext())
                {
                    Note model;
                    if (note.NoteID > 0)
                    {
                        model = db.Notes.Single(n => n.NoteID == note.NoteID);
                    }
                    else
                    {
                        model = db.Notes.Create();
                        model.User = db.SubUsers.Single(u => u.UserID == userId);
                        db.Notes.Add(model);
                    }

                    model.Title = note.Title;
                    model.Text = note.Text;
                    model.NoteType = note.Type;
                    model.ModificationDate = DateTime.Now;
                    model.Color = note.Color;
                    model.ImageUrl = note.ImageUrl;
                    model.Label = note.Label;
                    model.isLocked = note.IsLocked;

                    db.SaveChanges();
                    note.NoteID = model.NoteID;
                    note.ModificationDate = model.ModificationDate;
                    new TaskItemsManager().AddOrUpdateTaskItems(model.NoteID, note.TaskItems);
                    note.TaskItems.Clear();
                    model.TaskItems.ToList().ForEach(ti => note.TaskItems.Add(new TaskItemDTO(ti)));
                }
            }
        }

        public bool AddOrUpdateNote(NoteDTO note, string authorizedUserID)
        {
            using (var db = new NoteeContext())
            {
                var user = db.SubUsers.SingleOrDefault(u => u.UserID == note.UserID);
                if (user.UserID != authorizedUserID)
                {
                    return false;
                }
                Note model;
                if (db.SubUsers.Any(u => u.UserID == note.UserID))
                {
                    if (note.NoteID > 0)
                    {
                        model = db.Notes.Single(n => n.NoteID == note.NoteID);
                    }
                    else
                    {
                        model = db.Notes.Create();
                        model.User = db.SubUsers.Single(u => u.UserID == note.UserID);
                        db.Notes.Add(model);
                    }

                    model.Title = note.Title;
                    model.Text = note.Text;
                    model.NoteType = note.Type;
                    model.ModificationDate = DateTime.Now;
                    model.Color = note.Color;
                    model.ImageUrl = note.ImageUrl;
                    model.Label = note.Label;
                    model.isLocked = note.IsLocked;

                    db.SaveChanges();
                    note.NoteID = model.NoteID;
                    note.ModificationDate = model.ModificationDate;

                }
                else
                {
                    return false;
                }
                new TaskItemsManager().AddOrUpdateTaskItems(model.NoteID, note.TaskItems);
                note.TaskItems.Clear();
                model.TaskItems.ToList().ForEach(ti => note.TaskItems.Add(new TaskItemDTO(ti)));
            }
            return true;
        }

        public bool DeleteNote(int id, string authorizedUserID)
        {
            using (var db = new NoteeContext())
            {
                var note = db.Notes.SingleOrDefault(n => n.NoteID == id);
                var user = db.SubUsers.SingleOrDefault(u => u.UserID == note.UserID);
                if (user.UserID != authorizedUserID)
                {
                    return false;
                }
                if (note != null)
                {
                    db.Notes.Remove(note);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool UpdateModificationTime(int id)
        {
            using (var db = new NoteeContext())
            {
                var note = db.Notes.SingleOrDefault(n => n.NoteID == id);
                if (note != null)
                {
                    note.ModificationDate = DateTime.Now;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}