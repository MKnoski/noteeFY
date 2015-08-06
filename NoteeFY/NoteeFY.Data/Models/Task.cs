using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoteeFY.Models
{
    public class TaskItem
    {
            public int TaskItemID { get; set; }
            public string Text { get; set; }
            public bool isDone { get; set; }
            public bool isEdit  { get; set; }
            public virtual Note ToDoList { get; set; }
    }
}