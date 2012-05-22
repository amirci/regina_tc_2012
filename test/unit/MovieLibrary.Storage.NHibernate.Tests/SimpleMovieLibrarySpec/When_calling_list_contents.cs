using System.Collections.Generic;
using System.Linq;
using MavenThought.Commons.Extensions;
using MovieLibrary.Core;
using NHibernate;
using Rhino.Mocks;
using MavenThought.Commons.Testing;
using SharpTestsEx;

namespace MovieLibrary.Storage.NHibernate.Tests.SimpleMovieLibrarySpec
{
    [Specification]
    public class When_calling_list_contents : SimpleMovieLibrarySpecification
    {
        private IEnumerable<IMovie> _actual;
        private IEnumerable<Movie> _movies;

        protected override void GivenThat()
        {
            base.GivenThat();

            Given_I_have_movies_in_the_session();
        }

        protected override void WhenIRun()
        {
            this._actual = this.Sut.Contents;
        }

        [It]
        public void Should_return_all_the_contents_in_the_session()
        {
            this._actual.Should().Have.SameSequenceAs(this._movies);
        }

        private void Given_I_have_movies_in_the_session()
        {
            Stub<ISessionFactory, ISession>(f => f.OpenSession());

            Stub<ISession, ICriteria>(s => s.CreateCriteria<Movie>());

            this._movies = 10.Times(() => new Movie());

            Dep<ICriteria>().Stub(c => c.List<Movie>()).Return(this._movies.ToList());
        }
    }
}