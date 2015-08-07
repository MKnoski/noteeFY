using NoteeFY.Data.Models;
using System.Collections.Generic;

namespace NoteeFY.Buisness.DTOs
{
    public class NoteDTO
    {
        public int NoteID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public Type Type { get; set; }

        public List<TaskItemDTO> TaskItemsDTO { get; set; }
    }
}
