using System.IO;

namespace MovieLibrary.Acceptance.Tests.Infrastructure
{
    public class Storage
    {
        protected string DatabaseFile { get; private set; }

        /// <summary>
        /// Updates the boo configuration with the path to the storage
        /// </summary>
        /// <param name="applicationPath">Path to the web application</param>
        private void UpdateConfiguraiton(string applicationPath)
        {
            // Get the file name
            var booConfigFileName = Path.Combine(applicationPath, "Global.boo");

            // Read the file and change the line
            var configFile = File.ReadAllLines(booConfigFileName);

            var index = 1; // configFile.IndexOf(line => line == "databaseFile");

            configFile[index] = string.Format("  databaseFile = \"{0}\"", DatabaseFile.Replace("\\", "/"));

            // Write the file
            File.WriteAllLines(booConfigFileName, configFile);
        }

    }
}