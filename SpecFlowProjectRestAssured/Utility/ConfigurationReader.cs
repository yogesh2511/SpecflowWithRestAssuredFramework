using Microsoft.Extensions.Configuration;

namespace SpecFlowProjectRestAssured.Utility
{
    public static class ConfigurationReader
    {
        private static IConfigurationRoot configuration;
        public static AppSettings Settings { get; private set; }

        static ConfigurationReader()
        {
            var builder = new ConfigurationBuilder()
           .SetBasePath(AppContext.BaseDirectory)
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            configuration = builder.Build();

            Settings = new AppSettings();
            configuration.GetSection("AppSettings").Bind(Settings); 
        }
    }
           

    public class AppSettings
    {
        public string BaseUrl { get; set; }
        public string AuthToken { get; set; }
        public string ApiKey { get; set; }
        public int Timeout { get; set; }
        public string MemberId { get; set; }
    }   
}
