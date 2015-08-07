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
        public List<UserDTO> GetSetOfUsers()
        {
            using (NoteeContext db = new NoteeContext())
            {
                return db.Users.Select(u => new UserDTO
                {   
                    UserID = u.UserID,
                    Notes = u.Notes.ToList()
                    }).ToList();
            }
        }

        public User GetSingleUser(int id)
        {
            using (NoteeContext db = new NoteeContext())
            {
                var singleTask = db.Users.Find(id);

                if (singleTask == null)
                {
                    throw new ObjectNotFoundException();
                }

                return singleTask;
            }
        } 

    }
}
