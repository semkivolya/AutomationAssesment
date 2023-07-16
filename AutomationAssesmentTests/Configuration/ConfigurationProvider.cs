using Microsoft.Extensions.Configuration;

namespace AutomationAssesmentTests.Configuration
{
    public static class ConfigurationProvider
    {
        private static ConfigurationManager configuration;
        public static ConfigurationManager Configuration
        {
            get
            {
                if (configuration == null)
                {
                    configuration = new ConfigurationManager();
                    configuration.AddJsonFile("appsettings.json");
                }
                return configuration;
            }
        }
    }
}
