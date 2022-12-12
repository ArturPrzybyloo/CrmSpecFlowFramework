using CrmSpecFlowFramework.Helpers;
using CrmSpecFlowFramework.Models;
using OpenQA.Selenium;


namespace CrmSpecFlowFramework.Pages
{
    public class CreateContactPage : BasePage
    {
        public CreateContactPage(IWebDriver driver) : base(driver) { }

        public By FirstNameInput => By.Name("first_name");
        public By LastNameInput => By.Name("last_name");
        public By RoleFrame => By.XPath("//div[@aria-label='Business Role']");
        public By CategorySelect => By.Id("DetailFormcategories-input");
        public By CategorySelectValue = By.XPath("//div[@aria-label='Category']");
        public By CategoryInput => By.XPath("//div[@id='DetailFormcategories-input-search-text']/input");
        public By SaveButton => By.Id("DetailForm_save");
        public By ContactFirstAndLastName => By.XPath("//div[@class='summary-header']/h3");
        public By ContactBusinessRole => By.XPath("//p[contains(text(),'Business Role')]/following-sibling::div");
        public By ContactCategory => By.XPath("//span[contains(text(),'Category')]/parent::li");


        internal bool IsCreateContactPageDisplayed() => IsElementDisplayedAfterWaiting(FirstNameInput);

        public User CreateContact(string category, string role)
        {
            var user = new User
            {
                Name = Faker.Name.First(),
                LastName = Faker.Name.Last(),
                Category = category,
                Role = role,
            };

            // Set text for First Name and Last name
            SetText(FirstNameInput, user.Name);
            SetText(LastNameInput, user.LastName);

            // Choose category
            WaitTillElementContainsText(CategorySelectValue, "none");
            HoverAndClick(CategorySelect, CategorySelect);
            WaitAndFind(CategoryInput).SendKeys(category);
            ClickOnElementAfterWaiting(By.XPath($"//div[contains(text(),'{category}')]"));

            // Choose role
            HoverAndClick(RoleFrame, RoleFrame);
            ClickOnElementAfterWaiting(By.XPath($"//div[contains(text(), '{role}')]/parent::div"));

            // Save user
            Click(SaveButton);

            // Return user object
            return user;
        }

        public void VerifyCreatingContact(User user)
        {
            // Wait for loading created contact profile
            WaitAndFind(ContactCategory);

            // Verify first and last name
            var name = GetTextOfElement(ContactFirstAndLastName);
            name.Should().ContainAll(user.Name, user.LastName);

            // Verify business role
            var role = GetTextOfElement(ContactBusinessRole);
            role.Should().Be(user.Role);

            // Verify Category
            var cateogry = GetTextOfElement(ContactCategory);
            cateogry.Should().Contain(user.Category);
        }
    }
}
