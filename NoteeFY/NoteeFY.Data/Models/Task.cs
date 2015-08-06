using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoteeFY.Models
{
    public class Task
    {
            public int _TaskId { get; set; }
            public string Text { get; set; }
            public bool isDone { get; set; }
            public bool isEdit  { get; set; }
    }
}