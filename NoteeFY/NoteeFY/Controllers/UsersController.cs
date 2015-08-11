using NoteeFY.Buisness.DTOs;
using NoteeFY.Buisness.Managers;
using System.Web.Http;
using System.Web.Http.Description;

namespace NoteeFY.Controllers
{
    public class UsersController : ApiController
    {
        private UsersManager userManager = new UsersManager();

        // GET api/User/5
        [ResponseType(typeof(UserDTO))]
        public IHttpActionResult GetUser(int id)
        {
            UserDTO user = userManager.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        } 
    }
}
