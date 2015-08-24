using System;
using System.Collections.Generic;
using System.Linq;
using NoteeFY.Data;
using NoteeFY.Data.Models;

namespace NoteeFY.Buisness.DTOs
{
    public class NoteDTO
    {
        public int NoteID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public NoteType Type { get; set; }
        public DateTime ModificationDate { get; set; }
        public string Color { get; set; }

        public string UserID { get; set; }
        public List<TaskItemDTO> TaskItems { get; set; }

        public NoteDTO()
        {
            TaskItems = new List<TaskItemDTO>();
        }

        public NoteDTO(Note note)
        {
            NoteID = note.NoteID;
            Title = note.Title;
            Text = note.Text;
            Type = note.NoteType;
            ModificationDate = note.ModificationDate;
            UserID = note.UserID;
            Color = note.Color;
            TaskItems = note.TaskItems.Select(ti => new TaskItemDTO(ti)).ToList();
        }

    }
}
