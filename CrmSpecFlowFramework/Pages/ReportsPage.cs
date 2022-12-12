using OpenQA.Selenium;

namespace CrmSpecFlowFramework.Pages
{
    public class ReportsPage : BasePage
    {
        public ReportsPage(IWebDriver driver) : base(driver) { }

        //  Locators
        public By CreateButton => By.Id("SubPanel_create");
        public By ReportPageTitle => By.XPath("//span[contains(text(),'Reports')]");
        public By ReportSearch => By.Id("filter_text");

        internal bool IsReportPageDisplayed() => IsElementDisplayedAfterWaiting(ReportPageTitle);

        public ProjectsReportPage SearchForReport(string reportType)
        {
            WaitAndFind(ReportSearch);
            SetText(ReportSearch, reportType);
            ClickOnElementAfterWaiting(By.XPath($"//div[contains(text(),'{reportType}')]"));
            var projectsReportPage = new ProjectsReportPage(Driver);
            projectsReportPage.IsProjectsReportPageDisplayed();
            return projectsReportPage;
        }
    }
}
