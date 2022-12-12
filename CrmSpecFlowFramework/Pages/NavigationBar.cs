using OpenQA.Selenium;


namespace CrmSpecFlowFramework.Pages
{
    public class NavigationBar : BasePage
    {
        public NavigationBar(IWebDriver driver) : base(driver) { }

        // Locators
        public By SalesAndMarketing => By.XPath("//a[@title='Sales & Marketing']");
        public By ContactPage => By.LinkText("Contacts");
        public By ReportsAndSettings => By.XPath("//a[@title='Reports & Settings']");
        public By ReportsPage => By.LinkText("Reports");
        public By ActivityLogPage => By.LinkText("Activity Log");

        public ContactsPage GoToContacts()
        {
            HoverAndClick(SalesAndMarketing, ContactPage);
            var contactsPage = new ContactsPage(Driver);
            contactsPage.IsLoginPageDisplayed();
            return contactsPage;
        }

        public ReportsPage GoToReports()
        {
            HoverAndClick(ReportsAndSettings, ReportsPage);
            var reportsPage = new ReportsPage(Driver);
            reportsPage.IsReportPageDisplayed();
            return reportsPage;
        }

        public ActivityLogPage GoToActivityLog()
        {
            HoverAndClick(ReportsAndSettings, ActivityLogPage);
            var activityLog = new ActivityLogPage(Driver);
            activityLog.IsActivityLogPageDisplayed();
            return activityLog;
        }
    }
}
