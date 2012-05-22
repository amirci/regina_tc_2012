using System.IO;
using FluentNHibernate;
using MavenThought.Commons.Testing;
using NHibernate;

namespace MovieLibrary.Storage.NHibernate.Tests
{
    /// <summary>
    /// Base specification for Storage
    /// </summary>
    public abstract class StorageSpecification
        : BaseTest
    {
        protected ISessionFactory SessionFactory { get; set; }

        protected override void BeforeEachTest()
        {
            base.BeforeEachTest();
            this.SessionFactory = SessionFactoryGateway.Create(Path.GetTempFileName());
        }
    }
}