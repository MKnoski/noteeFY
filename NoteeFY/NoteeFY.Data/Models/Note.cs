using System;
using System.Collections.Generic;


namespace NoteeFY.Data.Models
{
    public enum Type { Text = 0, ToDoList };

    public class Note
    {
        public int NoteID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public Type Type { get; set; }
        public DateTime ModificationDate { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }

        public virtual List<TaskItem> TaskItems { get; set; }
    }
}