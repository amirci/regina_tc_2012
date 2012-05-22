using System.Collections.Generic;
using System.Web.Mvc;
using MavenThought.Commons.Extensions;
using MovieLibrary.Core;
using Rhino.Mocks;
using MavenThought.Commons.Testing;
using SharpTestsEx;

namespace MovieLibrary.Website.Tests.Controllers
{
    [Specification]
    public class When_method_index_is_called : MoviesControllerSpecification
    {
        private IEnumerable<IMovie> _contents;

        protected override void GivenThat()
        {
            base.GivenThat();

            Given_I_have_some_movies_in_the_library();
        }

        protected override void WhenIRun()
        {
            this.ActualResult = this.Sut.Index();
        }

        [It]
        public void Should_return_all_the_movies_in_storage()
        {
            var view = (ViewResult) this.ActualResult;

            var actual = (IEnumerable<IMovie>) view.Model;

            actual.Should().Have.SameSequenceAs(this._contents);
        }

        private void Given_I_have_some_movies_in_the_library()
        {
            this._contents = 10.Times(() => Mock<IMovie>());

            Dep<IMovieLibrary>().Stub(lib => lib.Contents).Return(this._contents);
        }

    }
}