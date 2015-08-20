using System.Collections.Generic;


namespace NoteeFY.Data.Models
{
    public class User
    {
        public User()
        {
            this.Notes = new HashSet<Note>();
        }

        public string UserID { get; set; }

        public virtual ICollection<Note> Notes { get; set; }
    }
}
