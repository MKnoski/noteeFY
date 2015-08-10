using System.Collections.Generic;

namespace NoteeFY.Data.Models
{
    public class User
    {
            public int UserID { get; set; }

            public virtual ICollection<Note> Notes { get; set; }
    }
}
