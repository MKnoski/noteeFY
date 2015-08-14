using System.Collections.Generic;
using NoteeFY.Data.DBContext;
using NoteeFY.Buisness.DTOs;
using System.Linq;

namespace NoteeFY.Buisness.Managers
{
    public class UsersManager
    {
        public UserDTO GetUser(string id)
        {
            using (var db = new NoteeContext())
            {
                var user = db.Users.SingleOrDefault(u => u.UserID == id);
                if (user == null)
                {
                    var us = new UserDTO()
                    {
                        UserID = id,
                        Notes = new List<NoteDTO>()
                    };
                    AddOrUpdateUser(us);
                    user = db.Users.SingleOrDefault(u => u.UserID == us.UserID);
                    return new UserDTO(user);
                }
                else return new UserDTO(user);
            }
        }


        public void AddOrUpdateUser(UserDTO user)
        {
            using (var db = new NoteeContext())
            {
                var model = db.Users.SingleOrDefault(u => u.UserID == user.UserID);
                if(model == null)
                {
                    model = db.Users.Create();
                    model.UserID = user.UserID;
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
