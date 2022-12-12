using Newtonsoft.Json.Linq;


namespace CrmSpecFlowFramework.Config
{
    public class ConfigProvider
    {
        private const string WebDriverConfigSectionName = "webdriver";
        private const string EnvironmentConfigSectionName = "environment";
        private const string FilePath = @"..\..\Config.json";
        private static readonly string SettingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FilePath);

        // Load configuration for driver based on config file
        public static WebDriverConfig WebDriver =>
            Load<WebDriverConfig>(WebDriverConfigSectionName);

        // Load configuration for environment based on config file
        public static EnvironmentConfig Environment =>
            Load<EnvironmentConfig>(EnvironmentConfigSectionName);

        private static T Load<T>(string sectionName) =>
            JObject.Parse(File.ReadAllText(SettingsPath)).SelectToken(sectionName).ToObject<T>();
    }
}
