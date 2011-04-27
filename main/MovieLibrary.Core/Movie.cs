namespace MovieLibrary.Core
{
    public class Movie : IMovie
    {
        public Movie(string title)
        {
            Title = title;
        }

        /// <summary>
        /// Gets the title of the movie
        /// </summary>
        virtual public string Title { get; private set; }
    }
}