using NoteeFY.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace NoteeFY.Buisness.DTOs
{
    public class NoteDTO
    {
        public int NoteID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public Type Type { get; set; }

        public List<TaskItemDTO> TaskItemsDTO { get; set; }

        public NoteDTO() { }

        public NoteDTO(Note note)
        {
            NoteID = note.NoteID;
            Title = note.Title;
            Text = note.Text;
            Type = note.Type;
            TaskItemsDTO = note.TaskItems.Select(ti => new TaskItemDTO(ti)).ToList();
        }

    }
}
