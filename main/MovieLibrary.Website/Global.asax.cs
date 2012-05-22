using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CommonServiceLocator.WindsorAdapter;
using Microsoft.Practices.ServiceLocation;
using MovieLibrary.Core;
using MovieLibrary.Storage.NHibernate;
using MovieLibrary.Website.Controllers;

namespace MovieLibrary.Website
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Movies", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            
            RegisterRoutes(RouteTable.Routes);

            SetupContainer();
        }

        private static void SetupContainer()
        {
            var container = new WindsorContainer();

            // Get the configuration object to access the related Web.config file.
            var dbFile = WebConfigurationManager.AppSettings["MovieDatabaseFile"];

            container.Register(
                Component.For<IMovieLibrary>().Instance(new SimpleMovieLibrary(dbFile)),
                Component.For<IControllerFactory>().ImplementedBy<WindsorControllerFactory>(),
                Component.For<MoviesController>().LifeStyle.Transient);

            ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));

            DependencyResolver.SetResolver(ServiceLocator.Current);
        }
    }
}