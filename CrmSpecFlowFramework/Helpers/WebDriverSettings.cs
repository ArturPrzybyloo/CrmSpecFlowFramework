using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using Microsoft.Edge.SeleniumTools;
using CrmSpecFlowFramework.Config;

namespace CrmSpecFlowFramework.Helpers
{
    public class WebDriverSettings
    {
        // Set up driver options
        public static ChromeOptions ChromeOptions(WebDriverConfig config)
        {
            var options = new ChromeOptions();
            options.AddExcludedArgument("enable-automation");
            options.AddArgument("--disable-save-password-bubble");
            options.AddArgument("ignore-certificate-errors");
            options.AddArgument("start-maximized");
            if (ConfigProvider.WebDriver.Headless)
            {
                options.AddArgument("--headless");
            }
            options.AddArgument($"--lang={config.BrowsersName}");
            options.AddUserProfilePreference("intl.accept_languages", config.BrowsersName);

            return options;
        }

        public static FirefoxOptions FirefoxOptions(WebDriverConfig config)
        {
            var options = new FirefoxOptions { AcceptInsecureCertificates = true };
            options.SetPreference("intl.accept_languages", config.BrowserLanguage);

            return options;
        }

        public static InternetExplorerOptions InternetExplorerOptions()
        {
            return new InternetExplorerOptions
            {
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                IgnoreZoomLevel = true,
                EnsureCleanSession = true
            };
        }

        public static EdgeOptions EdgeOptions()
        {
            var options = new EdgeOptions();
            options.AddArgument("start-maximized");
            options.UseChromium = true;
            options.PageLoadStrategy = PageLoadStrategy.Normal;
            options.UseInPrivateBrowsing = true;

            return options;
        }
    }
}
