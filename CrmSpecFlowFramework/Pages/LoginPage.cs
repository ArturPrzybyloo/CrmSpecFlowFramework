using CrmSpecFlowFramework.Config;
using OpenQA.Selenium;

namespace CrmSpecFlowFramework.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        // Locators
        public By LoginButton => By.Id("login_button");
        public By UserNameInput => By.Id("login_user");
        public By PasswordInput => By.Id("login_pass");

        internal bool IsLoginPageDisplayed() => IsElementDisplayedAfterWaiting(LoginButton);

        public void Login()
        {
            IsLoginPageDisplayed();
            SetText(UserNameInput, ConfigProvider.Environment.UserName);
            SetText(PasswordInput, ConfigProvider.Environment.Password);
            Click(LoginButton);
        }
    }
}
