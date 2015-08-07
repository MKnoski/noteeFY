using NoteeFY.Data.Models;
using System.Collections.Generic;

namespace NoteeFY.Buisness.DTOs
{
    public class TaskItemDTO
    {
        public int TaskItemID { get; set; }
        public string Text { get; set; }
        public bool IsDone { get; set; }

        public NoteDTO ToDoListDTO { get; set; }

        public TaskItemDTO (TaskItem task)
        {
            this.TaskItemID = task.TaskItemID;
            this.Text = task.Text;
            this.IsDone = task.IsDone;
            this.ToDoListDTO = null;
        }
    }
}
