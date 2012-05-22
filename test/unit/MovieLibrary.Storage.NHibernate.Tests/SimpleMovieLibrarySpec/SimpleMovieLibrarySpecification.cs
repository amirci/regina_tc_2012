using MavenThought.Commons.Testing;
using MovieLibrary.Core;
using NHibernate;

namespace MovieLibrary.Storage.NHibernate.Tests.SimpleMovieLibrarySpec
{
    /// <summary>
    /// Base specification for SimpleMovieLibrary
    /// </summary>
    public abstract class SimpleMovieLibrarySpecification
        : AutoMockSpecification<SimpleMovieLibrary, IMovieLibrary>
    {
        protected override IMovieLibrary CreateSut()
        {
            return new SimpleMovieLibrary(Dep<ISessionFactory>());
        }
    }
}