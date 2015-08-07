using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteeFY.Data.DBContext;
using NoteeFY.Data.Models;
using System.Data.Entity.Core;

namespace NoteeFY.Buisness.Managers
{
    public class UserManagers
    {
        public IEnumerable<User> GetSetOfUsers()
        {
            using (NoteeContext db = new NoteeContext())
            {
                return db.Users.AsEnumerable();
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
                    //throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
                }

                return singleTask;
            }
        } 

    }
}
