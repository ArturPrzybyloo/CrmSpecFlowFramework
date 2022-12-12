using CrmSpecFlowFramework.Models;
using CrmSpecFlowFramework.Pages;
using OpenQA.Selenium;

namespace CrmSpecFlowFramework.StepDefinitions
{
    [Binding]
    public sealed class CreateContactStepDefinitions
    {
        NavigationBar navigationBar;
        CreateContactPage createContactPage;
        User user;
        private readonly IWebDriver _driver;

        public CreateContactStepDefinitions()
        {
            _driver = ScenarioContext.Current.Get<IWebDriver>("currentDriver");
        }


        [Given(@"User is on Create Contact Page")]
        public void GivenUserIsOnCreateContactPage()
        {
            // Naviage to Contancts => Create Contact
            navigationBar = new NavigationBar(_driver);
            var contacts = navigationBar.GoToContacts();
            contacts.ClickCreateContact();
        }

        [When(@"Create new contact with category '(.*)' and role '(.*)'")]
        public void WhenCreateNewContactWithCategoryAndRole(string category, string role)
        {
            // Create new contact and return user object
            createContactPage = new CreateContactPage(_driver);
            var user = createContactPage.CreateContact(category, role);
            this.user = user;
        }

        [Then(@"Verify that Contact is created")]
        public void ThenVerifyThatContactIsCreated()
        {
            // Verify creation of user
            createContactPage.VerifyCreatingContact(this.user);
        }
    }
}