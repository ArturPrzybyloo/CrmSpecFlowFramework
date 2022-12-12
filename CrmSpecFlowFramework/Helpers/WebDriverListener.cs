using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using TechTalk.SpecFlow.Infrastructure;

namespace CrmSpecFlowFramework.Helpers
{
    public class WebDriverListener : EventFiringWebDriver
    {
        private readonly IWebDriver driver;
        private readonly Logger logger;
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;

        public WebDriverListener(IWebDriver parentDriver, Logger logger, ISpecFlowOutputHelper specFlowOutputHelper) : base(parentDriver)
        {
            driver = parentDriver;
            this.logger = logger;
            Navigating += WebDriverListener_Navigating;
            Navigated += WebDriverListener_Navigated;
            FindingElement += WebDriverListener_FindingElement;
            ElementClicking += WebDriverListener_ElementClicking;
            ElementClicked += WebDriverListener_ElementClicked;
            ElementValueChanged += WebDriverListener_ElementValueChanged;
            _specFlowOutputHelper = specFlowOutputHelper;
        }

        private void WebDriverListener_Navigating(object sender,
            WebDriverNavigationEventArgs e)
        {
            LogMessage($"Navigating to {e.Url}");
            _specFlowOutputHelper.WriteLine($"Navigating to {e.Url}");
        }

        private void WebDriverListener_ElementClicked(object sender,
            WebElementEventArgs e)
        {
            LogScreenshot($"{e.Element} clicked");
            _specFlowOutputHelper.WriteLine($"{e.Element} clicked");
        }

        private void WebDriverListener_ElementClicking(object sender,
            WebElementEventArgs e)
        {
            LogMessage($"Clicking on the {e.Element.TagName} `{e.Element.Text}` {e.Element}");
            _specFlowOutputHelper.WriteLine($"Clicking on the {e.Element.TagName} `{e.Element.Text}` {e.Element}");
        }

        private void WebDriverListener_FindingElement(object sender,
            FindElementEventArgs e)
        {
            LogMessage($"Finding element `{e.FindMethod}`");
            _specFlowOutputHelper.WriteLine($"Finding element `{e.FindMethod}`");
        }

        private void WebDriverListener_ElementValueChanged(object sender,
            WebElementValueEventArgs e)
        {
            LogScreenshot($"Value of the {e.Element} changed to `{e.Value}`");
            _specFlowOutputHelper.WriteLine($"Value of the {e.Element} changed to `{e.Value}`");
        }

        private void WebDriverListener_Navigated(object sender,
            WebDriverNavigationEventArgs e)
        {
            LogScreenshot($"Navigated to [{e.Driver.Title}]({e.Url})");
            _specFlowOutputHelper.WriteLine($"Navigated to [{e.Driver.Title}]({e.Url})");
        }

        private void LogMessage(string text)
        {
            logger.Info(text);
        }

        private void LogScreenshot(string text)
        {
            //driver.TakeScreenshot();
            logger.Info(text);
        }
    }
}
