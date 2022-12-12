using OpenQA.Selenium;


namespace CrmSpecFlowFramework.Pages
{
    internal class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        // Locators
        public By HomePageLogo => By.Id("main-title-module");

        internal bool IsHomePageDisplayed() => IsElementDisplayedAfterWaiting(HomePageLogo);

    }
}
