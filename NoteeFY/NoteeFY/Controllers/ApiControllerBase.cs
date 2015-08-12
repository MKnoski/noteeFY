using NoteeFY.Buisness.DTOs;
using NoteeFY.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

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
