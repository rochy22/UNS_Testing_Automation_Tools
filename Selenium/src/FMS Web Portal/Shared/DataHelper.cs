using Common;
using Microsoft.Extensions.Configuration;

namespace FMSWebPortal.Shared.DataHelper
{
    public class DataHelper
    {
        private static IConfigurationRoot _config;

        public DataHelper()
        {
            _config = ConfigurationReader.GetInstance();
        }

        public string GetPassword()
        {
            return _config["Password"];
        }

        public string GetPasswordDisable()
        {
            return _config["PasswordDisable"];
        }

        public string GetUsername()
        {
            return _config["Username"];
        }

        public string GetNoBackendUsername()
        {
            return _config["NoBackendUser"];
        }

        public string GetUserEmail()
        {
            return _config["UserEmail"];
        }

        public string GetBaseUrl()
        {
            return _config["FMSPortalBaseURL"];
        }
    }
}
