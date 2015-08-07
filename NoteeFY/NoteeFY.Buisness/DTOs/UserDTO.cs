using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteeFY.Data.Models;

namespace NoteeFY.Buisness.DTOs
{
    public class UserDTO
    {
        public int UserID { get; set; }

        public ICollection<NoteDTO> NotesDTO { get; set; }
    }
}
