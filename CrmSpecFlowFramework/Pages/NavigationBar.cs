﻿using OpenQA.Selenium;


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

        public SalesAndMarketingPage GoToSalesAndMarketing()
        {
            Click(SalesAndMarketing);
            return new SalesAndMarketingPage(Driver);
        }

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
    }
}