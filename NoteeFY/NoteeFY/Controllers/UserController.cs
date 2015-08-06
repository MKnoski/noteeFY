using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NoteeFY.Data.Models;
using NoteeFY.Buisness.Managers;

namespace NoteeFY.Controllers
{
    public class UserController : ApiController
    {
        private UserManager userMng = new UserManager();

        // GET: api/Users
        public IEnumerable<User> GetUsers()
        {
            return userMng.GetSetOfUsers();
        }

        // GET api/User/5
        public User GetUsers(int id)
        {
            return userMng.GetSingleUser(id);
        } 
    }
}
