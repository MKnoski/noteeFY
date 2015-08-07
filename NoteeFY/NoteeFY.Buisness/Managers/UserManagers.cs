using NoteeFY.Data.DBContext;
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
                if (singleUser == null) return null;
                else return new UserDTO(singleUser);
            }
        }
    }
}
