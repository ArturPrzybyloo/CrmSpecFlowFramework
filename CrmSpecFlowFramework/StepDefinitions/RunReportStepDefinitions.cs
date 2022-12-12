using CrmSpecFlowFramework.Pages;
using OpenQA.Selenium;

namespace CrmSpecFlowFramework.StepDefinitions
{
    [Binding]
    public sealed class RunReportStepDefinition
    {
        NavigationBar navigationBar;
        ReportsPage reportsPage;
        ProjectsReportPage projectsReportPage;
        private readonly IWebDriver _driver;

        public RunReportStepDefinition()
        {
            _driver = ScenarioContext.Current.Get<IWebDriver>("currentDriver");
        }

        [Given(@"User is on Reports Page")]
        public void GivenUserIsOnReportsPage()
        {
            // Navigate to Reports
            navigationBar = new NavigationBar(_driver);
            navigationBar.GoToReports();
        }

        [Given(@"User search for '(.*)' Report")]
        public void GivenUserSearchForReport(string reportType)
        {
            // Search for report type
            reportsPage = new ReportsPage(_driver);
            reportsPage.SearchForReport(reportType);
        }

        [When(@"User run report")]
        public void WhenUserRunReport()
        {
            // Run report
            projectsReportPage = new ProjectsReportPage(_driver);
            projectsReportPage.RunReport();
        }

        [Then(@"Verify reports result in table")]
        public void ThenVerifyReportsResultInTable()
        {
            // Verify that result table is not empty
            projectsReportPage.VerifyReportResults();
        }

        [Then(@"Export report as csv file and verify result are not empty")]
        public void ThenExportReportAsCsvFileAndVerifyResultAreNotEmpty()
        {
            // Download CSV File and verify that it is not empty
            projectsReportPage.ExportReportAndVerifyResults();
        }
    }
}