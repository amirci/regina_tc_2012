using System.Web.Mvc;
using MovieLibrary.Core;

namespace MovieLibrary.Website.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieLibrary _library;

        public MoviesController(IMovieLibrary library)
        {
            _library = library;
        }

        public ActionResult Index()
        {
            return View(this._library.Contents);
        }

    }
}
