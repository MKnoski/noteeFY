using System.Web.Http;
using System.Web.Http.Results;
using NoteeFY.Buisness.Helpers;

namespace NoteeFY.Controllers
{
    public abstract class ApiControllerBase : ApiController
    {
        protected JsonResult<ModificationResult<T>> ValidateModelState<T>()
        {
            if (!ModelState.IsValid)
            {
                return Json(new ModificationResult<T>("error: Zly model"));
            }
            else
            {
                return null;
            }
        }

    }
}
