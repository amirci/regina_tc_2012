using System.Linq;
using System.Web.Mvc;
using MovieLibrary.Core;

namespace MovieLibrary.Website.Controllers
{
    public class MoviesController : Controller
    {
        //
        // GET: /Movies/

        public ActionResult Index()
        {
            return View(Enumerable.Empty<IMovie>());
        }

    }
}
