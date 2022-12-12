using Allure.Commons;
using CrmSpecFlowFramework.Config;
using CrmSpecFlowFramework.Helpers;
using CrmSpecFlowFramework.Pages;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using TechTalk.SpecFlow.Infrastructure;

namespace CrmSpecFlowFramework.Hooks
{
    [Binding]
    public sealed class TestHooks
    {
        private static IWebDriver _driver;
        private static LoginPage loginPage;
        private static HomePage homePage;
        protected static NavigationBar NavigationBar { get; set; }
        AllureLifecycle allure = AllureLifecycle.Instance;

        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        [BeforeScenario]
        public void TestSetup(ISpecFlowOutputHelper specFlowOutputHelper)
        {
            // Cleanup allure report
            allure.CleanupResultDirectory();

            // Set up webdriver configuration and initialize logger
            var driverConfig = ConfigProvider.WebDriver;
            var logger = new Logger("logger", InternalTraceLevel.Info, TextWriter.Null);
            _driver = new WebDriverFactory().GetWebDriver(driverConfig, logger, specFlowOutputHelper);
            ScenarioContext.Current.Add("currentDriver", _driver);

            // Initialize pages
            loginPage = new LoginPage(_driver);
            homePage = new HomePage(_driver);
            NavigationBar = new NavigationBar(_driver);

            // Open application and login with credentials based on config file
            _driver.Navigate().GoToUrl(ConfigProvider.Environment.ApplicationUrl);
            loginPage.Login();
            homePage.IsHomePageDisplayed();
        }

        [AfterScenario]
        public void TestTearDown()
        {
            // Quit driver after test
            _driver.Quit();
        }
    }
}