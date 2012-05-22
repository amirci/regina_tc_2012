using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MovieLibrary.Core;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace MovieLibrary.Storage.NHibernate
{
    public static class SessionFactoryGateway
    {
        public static ISessionFactory Create(string databaseFile)
        {
            var configurer = SQLiteConfiguration.Standard.UsingFile(databaseFile);

#if DEBUG
            configurer.ShowSql();
#endif

            return Fluently.Configure()
                .ExposeConfiguration(BuildSchema)
                .Database(configurer)
                .Mappings(m => m.AutoMappings.Add(AutoMap.AssemblyOf<IMovie>()))
                .BuildSessionFactory();
        }

        /// <summary>
        /// Deletes the database if exists and creates the schema
        /// </summary>
        /// <param name="config">
        /// Configuration to use 
        /// </param>
        private static void BuildSchema(Configuration config)
        {
            // export schema
            new SchemaExport(config).Create(true, true);
        }
    }
}