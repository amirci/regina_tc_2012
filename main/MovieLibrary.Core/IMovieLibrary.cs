using System.Collections.Generic;

namespace MovieLibrary.Core
{
    /// <summary>
    /// Library to store movies
    /// </summary>
    public interface IMovieLibrary
    {
        /// <summary>
        /// Gets the contents in the library
        /// </summary>
        IEnumerable<IMovie> Contents { get; }

        /// <summary>
        /// Clear the library
        /// </summary>
        void Clear();

        /// <summary>
        /// Add a movie
        /// </summary>
        /// <param name="movie">movie to be added</param>
        void Add(IMovie movie);
    }
}