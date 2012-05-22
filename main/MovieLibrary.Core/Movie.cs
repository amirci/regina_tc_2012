using System;

namespace MovieLibrary.Core
{
    public class Movie : IMovie
    {
        virtual public int Id { get; set; }

        /// <summary>
        /// Gets the title of the movie
        /// </summary>
        virtual public string Title { get; set; }

        /// <summary>
        /// Gets or sets when the movie was released
        /// </summary>
        virtual public DateTime ReleaseDate { get; set; }
    }
}