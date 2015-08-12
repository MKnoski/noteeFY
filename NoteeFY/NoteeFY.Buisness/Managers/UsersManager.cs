using NoteeFY.Data.DBContext;
using NoteeFY.Buisness.DTOs;
using System.Linq;
using NoteeFY.Data.Models;

namespace NoteeFY.Buisness.Managers
{
    public class UsersManager
    {
        public UserDTO GetUser(int id)
        {
            using (var db = new NoteeContext())
            {
                var user = db.Users.SingleOrDefault(u => u.UserID == id);
                return user == null ? null : new UserDTO(user);
            }
        }


        public void AddOrUpdateUser(UserDTO user)
        {
            using (var db = new NoteeContext())
            {
                User model;
                if (user.UserID > 0)
                {
                    model = db.Users.Single(u => u.UserID == user.UserID);
                }
                else
                {
                    model = db.Users.Create();
                    db.Users.Add(model);
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
