using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteeFY.Data.Models
{
    public class User
    {
            public int UserID { get; set; }

            public virtual ICollection<Note> Notes { get; set; }
    }
}
