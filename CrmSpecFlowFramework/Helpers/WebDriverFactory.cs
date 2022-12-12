using NUnit.Framework.Internal;
using OpenQA.Selenium.Chrome;
using Microsoft.Edge.SeleniumTools;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using CrmSpecFlowFramework.Config;

namespace CrmSpecFlowFramework.Helpers
{
    public class WebDriverFactory
    {
        public WebDriverListener GetWebDriver(WebDriverConfig config, Logger logger)
        {
            // Set up driver based on configuration
            switch (config.BrowsersName)
            {
                case Browsers.Chrome:
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    var chromeDriver = new ChromeDriver(WebDriverSettings.ChromeOptions(config));
                    return new WebDriverListener(chromeDriver, logger);
                case Browsers.Firefox:
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    var firefoxDriver = new FirefoxDriver(WebDriverSettings.FirefoxOptions(config));
                    return new WebDriverListener(firefoxDriver, logger);
                case Browsers.IE:
                    new DriverManager().SetUpDriver(new InternetExplorerConfig());
                    var ieDriver = new InternetExplorerDriver(WebDriverSettings.InternetExplorerOptions());
                    return new WebDriverListener(ieDriver, logger);
                case Browsers.Edge:
                    new DriverManager().SetUpDriver(new EdgeConfig());
                    var edgeDriver = new EdgeDriver(WebDriverSettings.EdgeOptions());
                    return new WebDriverListener(edgeDriver, logger);
                default:
                    throw new ArgumentOutOfRangeException(nameof(config.BrowsersName),
                        config.BrowsersName,
                        null);
            }
        }
    }
}
