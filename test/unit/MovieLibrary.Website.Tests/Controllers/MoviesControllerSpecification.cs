using System.Web.Mvc;
using MavenThought.Commons.Testing;
using MovieLibrary.Website.Controllers;

namespace MovieLibrary.Website.Tests.Controllers
{
    /// <summary>
    /// Base specification for Movies Controller 
    /// </summary>
    public abstract class MoviesControllerSpecification 
        : AutoMockSpecificationWithNoContract<MoviesController>
    {
        protected ActionResult ActualResult { get; set; }
    }
}