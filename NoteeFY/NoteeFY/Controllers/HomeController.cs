using System.Web.Mvc;

namespace NoteeFY.Controllers
{
    [Authorize]
    [RequireHttps]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NoteeFY()
        {
            return View();
        }
    }
}