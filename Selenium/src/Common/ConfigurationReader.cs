using Microsoft.Extensions.Configuration;

namespace Common
{
    public sealed class ConfigurationReader
    {
        private static IConfigurationRoot _configuration;
        private static readonly object _lock = new object();

        private ConfigurationReader() { }

        public static IConfigurationRoot GetInstance()
        {
            if (_configuration == null)
            {
                lock (_lock)
                {
                    var builder = new ConfigurationBuilder()
                        .AddJsonFile("ConnectionStrings.json", optional: false)
                        .AddJsonFile("Secrets.json")
                        .AddJsonFile("Config/TokenSecrets.json", optional: false)
                        .AddJsonFile("Config/Environment.json", optional: false);

                    _configuration = builder.Build();
                }
            }

            return _configuration;
        }
    }
}
