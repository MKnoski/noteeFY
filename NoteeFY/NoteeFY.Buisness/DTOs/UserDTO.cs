using System.Collections.Generic;
using System.Linq;
using NoteeFY.Data.Models;

namespace NoteeFY.Buisness.DTOs
{
    public class UserDTO
    {
        public string UserID { get; set; }

        public List<NoteDTO> Notes { get; set; }

        public UserDTO()
        {
            Notes = new List<NoteDTO>();
        }

        public UserDTO(User user)
        {
            UserID = user.UserID;
            Notes = user.Notes.Select(n => new NoteDTO(n)).ToList();
        }
    }
}
