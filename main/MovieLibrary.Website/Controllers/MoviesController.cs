using System.Web.Mvc;
using MovieLibrary.Core;

namespace MovieLibrary.Website.Controllers
{
    public class MoviesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}
