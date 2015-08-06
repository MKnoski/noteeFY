using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using NoteeFY.Data.DBContext;
using NoteeFY.Data.Models;

namespace NoteeFY.Buisness.Managers
{
    public class UserManager
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
                    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
                }

                return singleTask;
            }
        } 

    }
}
