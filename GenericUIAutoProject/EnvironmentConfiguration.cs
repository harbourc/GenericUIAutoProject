using System.Configuration;

namespace GenericUIAutoProject
{
    public class EnvironmentConfiguration
    {
        private static EnvironmentConfiguration _current;

        public static EnvironmentConfiguration Current => _current ?? (_current = new EnvironmentConfiguration());

        private EnvironmentConfiguration()
        {
        }

        // use this line to read from a ConfigFile
        // public string Browser => ConfigurationManager.AppSettings["Browser"];
        public string Browser = "chrome";

    }
}
