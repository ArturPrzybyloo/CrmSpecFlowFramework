using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace CrmSpecFlowFramework.Pages
{
    public class BasePage
    {
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        protected IWebDriver Driver { get; private set; }
        protected WebDriverWait Wait { get; private set; }

        // Basic Selenium actions
        protected void Click(By locator) => Driver.FindElement(locator).Click();

        protected void SetText(By locator, string text) => LocateElement(locator).SendKeys(text);

        protected string GetTextOfElement(By locator) => LocateElement(locator).Text;

        protected IWebElement LocateElement(By locator) => Driver.FindElement(locator);
        protected ReadOnlyCollection<IWebElement> LocateElements(By locator) => Driver.FindElements(locator);

        protected IWebElement GetElementAfterWaiting(By locator) => Wait.Until(EC.ElementIsVisible(locator));

        protected bool IsElementDisplayedImmediately(By locator) => LocateElement(locator).Displayed;

        protected bool IsElementDisplayedAfterWaiting(By locator) => Wait.Until(EC.ElementIsVisible(locator)).Displayed;

        protected bool IsElementDisappearedAfterWaiting(By locator)
        {
            try
            {
                Wait.Until(EC.InvisibilityOfElementLocated(locator));

                return true;
            }
            catch (Exception)
            {
                throw new Exception($"Element: {locator} is still visible");
            }
        }

        protected bool WaitTillElementContainsText(By locator, string text) => Wait.Until(EC.TextToBePresentInElement(LocateElement(locator), text));
        protected bool WaitTillElementNotContainsText(By locator, string text) => Wait.Until(EC.InvisibilityOfElementWithText(locator, text));
        protected IAlert WaitForAlertPresence() => Wait.Until(EC.AlertIsPresent());

        protected void ClickOnElementAfterWaiting(By locator) => Wait.Until(EC.ElementIsVisible(locator)).Click();
        protected void ClickOnClickableElement(By locator) => Wait.Until(EC.ElementToBeClickable(locator)).Click();
        protected void ClickOnExistingElement(By locator) => Wait.Until(EC.ElementExists(locator)).Click();
        protected IWebElement WaitAndFind(By locator)
        {
            Wait.Until(EC.ElementIsVisible(locator));
            return Driver.FindElement(locator);
        }

        protected void HoverAndClick(By locatorForHover, By locatorToClick)
        {
            // Wait and hover on element
            var hoverElement = Wait.Until(EC.ElementIsVisible(locatorForHover));
            Actions action = new Actions(Driver);
            action.MoveToElement(hoverElement).Perform();

            // Wait and click on element
            var clickElement = Wait.Until(EC.ElementIsVisible(locatorToClick));
            clickElement.Click();
        }

        protected void SelectByTextFromDropdown(By locator, string value)
        {
            var element = LocateElement(locator);
            SelectElement dropDown = new SelectElement(element);
            dropDown.SelectByText(value);
        }
    }
}
