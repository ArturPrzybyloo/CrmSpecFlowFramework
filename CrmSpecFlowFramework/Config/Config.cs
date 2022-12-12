namespace CrmSpecFlowFramework.Config
{
    public class WebDriverConfig
    {
        public Browsers BrowsersName { get; set; }
        public string ScreenshotsPath { get; set; }
        public int DefaultTimeout { get; set; }
        public string BrowserLanguage { get; set; }
        public bool Headless { get; set; }
    }

    public class EnvironmentConfig
    {
        public string ApplicationName { get; set; }
        public string ApplicationUrl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
