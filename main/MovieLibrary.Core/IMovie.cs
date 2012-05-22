using System;

namespace MovieLibrary.Core
{
    /// <summary>
    /// Movie model
    /// </summary>
    public interface IMovie
    {
        /// <summary>
        /// Gets the title of the movie
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Gets or sets when the movie was released
        /// </summary>
        DateTime ReleaseDate { get; set; }
    }
}