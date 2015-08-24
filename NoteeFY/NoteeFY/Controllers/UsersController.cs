using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using NoteeFY.Buisness.DTOs;
using NoteeFY.Buisness.Helpers;
using NoteeFY.Buisness.Managers;

namespace NoteeFY.Controllers
{
    [Authorize]
    public class UsersController : ApiControllerBase
    {
        private UsersManager userManager = new UsersManager();

        // GET api/Users
        [ResponseType(typeof(UserDTO))]
        public IHttpActionResult GetUser()
        {
            var user = userManager.GetUser(User.Identity.Name);
            return user == null ? (IHttpActionResult) NotFound() : Ok(user);
        }

        // POST: api/Users - ADD or UPDATE
        public JsonResult<ModificationResult<UserDTO>> PostUser(UserDTO user)
        {
            var result = ValidateModelState<UserDTO>();
            if (result != null)
            {
                return result;
            }
            else
            {
                userManager.AddOrUpdateUser(user);
                return Json(new ModificationResult<UserDTO>(true)
                {
                    Data = user
                });
            }
        }
    }
}
