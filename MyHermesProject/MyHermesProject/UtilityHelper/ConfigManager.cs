using NUnit.Framework;
using System.Configuration;

namespace MyHermesProject.UtilityHelper
{
    public static class ConfigManager
    {
        public static string UrlString => TestContext.Parameters.Get("EnvironmentUrl",ConfigurationManager.AppSettings["Url"]);
        public static string BrowsersType => TestContext.Parameters.Get("BrowserType", ConfigurationManager.AppSettings["Browser"]);
    }
}
