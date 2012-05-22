using System;
using System.IO;
using System.Xml;
using FluentXml;
using MovieLibrary.Storage.NHibernate;
using NUnit.Framework;

namespace MovieLibrary.Acceptance.Tests.Infrastructure
{
    public class Storage
    {
        public const string DBSETTINGS_KEY = "MovieDatabaseFile";

        public Storage()
        {
            DatabaseFile = Path.GetTempFileName();

            UpdateWebConfig(WebServer.WebRoot, DatabaseFile);

            this.Library = new SimpleMovieLibrary(DatabaseFile);
        }

        public SimpleMovieLibrary Library { get; private set; }

        public string DatabaseFile { get; private set; }

        private static void UpdateWebConfig(DirectoryInfo webRoot, string dbFileName)
        {
            var configFile = Path.Combine(webRoot.FullName, "Web.config");

            Assert.True(File.Exists(configFile), "{0} does not exist!", configFile);

            Console.WriteLine("updating: {0}", configFile);

            FluentXmlDocument
                .FromFile(configFile)
                .RemoveSqliteFileSetting()
                .AddSqliteFileSetting(dbFileName)
                .Save(configFile);
        }
    }

    public static class Helper
    {
        public static XmlDocument RemoveSqliteFileSetting(this XmlDocument configDoc)
        {
            var appSettings = configDoc.Node("appSettings");

            var node = appSettings.Node(n => n.Attr("key") == Storage.DBSETTINGS_KEY);

            if (node != null)
            {
                appSettings.RemoveChild(node);
            }

            return configDoc;
        }

        public static XmlDocument AddSqliteFileSetting(this XmlDocument configDoc, string dbFileName)
        {
            configDoc.Node("appSettings")
                .NewNode("add")
                .Attr("key", Storage.DBSETTINGS_KEY)
                .Attr("value", dbFileName);

            return configDoc;
        }
            
    }
}