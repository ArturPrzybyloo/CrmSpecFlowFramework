using OpenQA.Selenium;


namespace CrmSpecFlowFramework.Pages
{
    public class ContactsPage :BasePage
    {
        public ContactsPage(IWebDriver driver) : base(driver) { }

        // Locators
        public By CreateContactButton => By.XPath("//span[contains(text(),'Create Contact')]/parent::a");

        internal bool IsLoginPageDisplayed() => IsElementDisplayedAfterWaiting(CreateContactButton);

        public CreateContactPage ClickCreateContact()
        {
            ClickOnElementAfterWaiting(CreateContactButton);
            var contactPage =  new CreateContactPage(Driver);
            contactPage.IsCreateContactPageDisplayed();
            return contactPage;
        }
    }
}
