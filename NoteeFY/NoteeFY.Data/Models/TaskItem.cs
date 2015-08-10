using System.ComponentModel.DataAnnotations.Schema;

namespace NoteeFY.Data.Models
{
    public class TaskItem
    {
            public int TaskItemID { get; set; }
            public string Text { get; set; }
            [Column("IsDone")]
            public bool IsDone { get; set; }

            public int NoteID { get; set; }
            public virtual Note Note { get; set; }
    }
}