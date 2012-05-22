using System;
using System.Linq;
using System.Text.RegularExpressions;
using MavenThought.Commons.Extensions;
using MovieLibrary.Core;
using SharpTestsEx;
using TechTalk.SpecFlow;
using WatiN.Core;

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

        [Given(@"I have some movies stored")]
        public void GenerateSomeMovies()
        {
            10
                .Times(i => new Movie
                              {
                                  Title = "The great adventures of Sheldon " + i,
                                  ReleaseDate = new DateTime(1990 + i, i + 1, 1)
                              })
                .ForEach(Library.Add);
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

        [Then(@"I should see all the movies listed")]
        public void AssertAllMoviesAreListed()
        {
            var expected = Library.Contents.Select(m => new {m.Title, m.ReleaseDate});

            var actual = Browser
                .Instance
                .TableRows.Filter(Find.ByClass(".movie"))
                .Select(row => new
                                   {
                                       Title = row.TableCells[0].Text,
                                       ReleaseDate = DateTime.Parse(row.TableCells[1].Text)
                                   });

            actual.Should().Have.SameSequenceAs(expected);
        }
    }
}
