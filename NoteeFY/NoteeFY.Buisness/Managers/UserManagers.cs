using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteeFY.Data.DBContext;
using NoteeFY.Data.Models;
using System.Data.Entity.Core;
using NoteeFY.Buisness.DTOs;

namespace NoteeFY.Buisness.Managers
{
    public class UserManagers
    {
        public UserDTO GetSingleUser(int id)
        {
            using (NoteeContext db = new NoteeContext())
            {
                var singleUser = db.Users.Find(id);

                if (singleUser == null)
                {
                    throw new ObjectNotFoundException();
                }

                return GetUserDTO(singleUser);
            }
        }

        public UserDTO GetUserDTO (User user)
        {
            var UserID = user.UserID;
            var Notes = user.Notes.ToList();

            UserDTO userDTO = new UserDTO
            {
                UserID = user.UserID,
                NotesDTO = null
            };
            userDTO.NotesDTO = NoteManager.GetNotesDTO(user.Notes.ToList());
            return userDTO;
        }
    }
}
