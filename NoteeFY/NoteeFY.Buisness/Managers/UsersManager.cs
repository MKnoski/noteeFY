using NoteeFY.Data.DBContext;
using NoteeFY.Buisness.DTOs;
using System.Linq;


namespace NoteeFY.Buisness.Managers
{
    public class UsersManager
    {
        public UserDTO GetUser(int id)
        {
            using (NoteeContext db = new NoteeContext())
            {
                var user = db.Users.SingleOrDefault(u => u.UserID == id);
                if (user == null)
                {
                    return null;
                }
                else
                {
                    return new UserDTO(user);
                }
            }
        }
    }
}
