


namespace NoteeFY.Data.Models
{
    public class TaskItem
    {
            public int TaskItemID { get; set; }
            public string Text { get; set; }
            public bool IsDone { get; set; }

            public virtual Note ToDoList { get; set; }
    }
}