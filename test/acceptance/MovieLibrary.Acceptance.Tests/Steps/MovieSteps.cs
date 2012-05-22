using System.Text.RegularExpressions;
using SharpTestsEx;
using TechTalk.SpecFlow;

namespace MovieLibrary.Acceptance.Tests.Steps
{
    [Binding]
    public class MovieSteps : BaseSteps
    {
        [Given(@"I have no movies stored")]
        public void ClearTheStorage()
        {
            // nothing to do empty by default
        }

        [When(@"I browse the movies")]
        public void GoToBrowseMoviesPage()
        {
            Browser.GoTo("/movies");
        }

        [Then(@"I should a notification explaining the listing is empty")]
        public void AssertNotificationExistsOnPage()
        {
            Browser.Instance
                .FindText(new Regex("Sorry no movies available!"))
                .Should("Can't find the expected message!")
                .Not.Be.Null();
        }
    }
}
