using MovieLibrary.Acceptance.Tests.Infrastructure;
using MovieLibrary.Core;
using TechTalk.SpecFlow;

namespace MovieLibrary.Acceptance.Tests.Steps
{
    public class BaseSteps
    {
        public Browser Browser
        {
            get { return ScenarioContext.Current.Get<Browser>(); }
        }

        public IMovieLibrary Library
        {
            get { return ScenarioContext.Current.Get<Infrastructure.Storage>().Library; }
        }
    }
}