using System.Collections.Generic;
using System.Linq;
using NoteeFY.Data.Models;

namespace NoteeFY.Buisness.DTOs
{
    public class UserDTO
    {
        public int UserID { get; set; }

        public List<NoteDTO> NotesDTO { get; set; }

        public UserDTO() { }

        public UserDTO(User user)
        {
            UserID = user.UserID;
            NotesDTO = user.Notes.Select(n => new NoteDTO(n)).ToList();
        }
    }
}
