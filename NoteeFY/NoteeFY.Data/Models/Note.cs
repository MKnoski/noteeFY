using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoteeFY.Models
{
    public enum Type { Note, ToDoList };

    public class Note
    {
        public int NoteID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public Type? Type { get; set; }
        
        public virtual ICollection<TaskItem> Tasks { get; set; }
    }
}