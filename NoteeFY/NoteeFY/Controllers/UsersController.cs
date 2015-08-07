using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NoteeFY.Buisness.DTOs;
using NoteeFY.Data.Models;
using NoteeFY.Buisness.Managers;

namespace NoteeFY.Controllers
{
    public class UsersController : ApiController
    {
        private UserManagers userManager = new UserManagers();

        // GET api/User/5
        public UserDTO GetUser(int id)
        {
            try
            {
                return userManager.GetSingleUser(id);
            }
            catch (ObjectNotFoundException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }     
        } 
    }
}
