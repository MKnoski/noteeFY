using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoteeFY.Data.Models
{
    public class User
    {
        [Key]
        [Required]
        [Index(IsUnique = true)]
        [Display(Name = "UserID")]
        public string UserID { get; set; }

        public virtual ICollection<Note> Notes { get; set; }
    }
}
