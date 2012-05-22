using System;
using FluentNHibernate.Testing;
using MovieLibrary.Core;
using MavenThought.Commons.Testing;

namespace MovieLibrary.Storage.NHibernate.Tests
{
    [Specification]
    public class When_storing_movies : StorageSpecification
    {
        [It]
        public void Should_match_al_the_mappings()
        {
            new PersistenceSpecification<Movie>(this.SessionFactory.OpenSession())
                .CheckProperty(p => p.Title, "Blazing Saddles")
                .VerifyTheMappings();
        }
    }
}