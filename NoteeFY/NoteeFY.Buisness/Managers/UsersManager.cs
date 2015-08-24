using System.Linq;
using NoteeFY.Buisness.DTOs;
using NoteeFY.Data;

namespace NoteeFY.Buisness.Managers
{
    public class UsersManager
    {
        public UserDTO GetUser(string id)
        {
            using (var db = new NoteeContext())
            {
                var user = db.SubUsers.SingleOrDefault(u => u.UserID == id);
                return user == null ? null : new UserDTO(user);
            }
        }


        public void AddOrUpdateUser(UserDTO user)
        {
            using (var db = new NoteeContext())
            {
                var model = db.SubUsers.SingleOrDefault(u => u.UserID == user.UserID);
                if(model == null)
                {
                    model = db.SubUsers.Create();
                    model.UserID = user.UserID;
                    db.SubUsers.Add(model);
                }

                db.SaveChanges();
                user.UserID = model.UserID;

                new NotesManager().AddOrUpdateNotes(model.UserID, user.Notes);
                user.Notes.Clear();
                model.Notes.ToList().ForEach(n => user.Notes.Add(new NoteDTO(n)));
            }
            
        }
    }
}
