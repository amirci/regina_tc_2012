using System.Collections.Generic;
using MovieLibrary.Core;
using NHibernate;

namespace MovieLibrary.Storage.NHibernate
{
    /// <summary>
    /// Implementation that uses the media storage
    /// </summary>
    public class SimpleMovieLibrary : IMovieLibrary
    {
        /// <summary>
        /// Factory to obtain the session
        /// </summary>
        private readonly ISessionFactory _factory;

        /// <summary>
        /// Initializes the repository using a persistence configurer
        /// </summary>
        public SimpleMovieLibrary(string databaseFile)
        {
            this._factory = SessionFactoryGateway.Create(databaseFile);
        }

        /// <summary>
        /// Constructor that injects the session factory
        /// </summary>
        /// <param name="factory">Session factory to use</param>
        public SimpleMovieLibrary(ISessionFactory factory)
        {
            this._factory = factory;
        }

        /// <summary>
        /// Adds a new element to the library
        /// </summary>
        /// <param name="element">New media element to add to the library</param>
        public void Add(IMovie element)
        {
            this._factory.SaveOrUpdate(element);
        }

        /// <summary>
        /// Gets the collection of media
        /// </summary>
        public IEnumerable<IMovie> Contents
        {
            get { return this._factory.List<Movie>(); }
        }

        /// <summary>
        /// Clears the contents of the library
        /// </summary>
        public void Clear()
        {
            this._factory.AutoCommit(s => s.Delete("from Movie"));
        }
    }
}