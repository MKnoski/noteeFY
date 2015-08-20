using System.Collections.Generic;


namespace NoteeFY.Data.Models
{
    public enum NoteType { Text = 0, ToDoList };
    public class Note
    {
        public Note()
        {
            this.TaskItems = new HashSet<TaskItem>();
        }

        public int NoteID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public System.DateTime ModificationDate { get; set; }
        public string UserID { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<TaskItem> TaskItems { get; set; }
        public NoteType Type { get; set; }
    }
}
