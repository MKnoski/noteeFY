using NoteeFY.Data.DBContext;
using NoteeFY.Buisness.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace NoteeFY.Buisness.Managers
{
    public class UserManagers
    {
        public List<UserDTO> GetSetOfUsers()
        {
            using (NoteeContext db = new NoteeContext())
            {
                return db.Users.ToList().Select(u => new UserDTO(u)).ToList();
            }
        }

        public UserDTO GetSingleUser(int id)
        {
            using (NoteeContext db = new NoteeContext())
            {
                var singleUser = db.Users.Find(id);
                if (singleUser == null) return null;
                else return new UserDTO(singleUser);
            }
        }
    }
}
