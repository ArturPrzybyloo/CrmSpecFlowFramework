using CrmSpecFlowFramework.Helpers;
using OpenQA.Selenium;

namespace CrmSpecFlowFramework.Pages
{
    public class ProjectsReportPage : BasePage
    {
        public ProjectsReportPage(IWebDriver driver) : base(driver) { }

        // Locators
        public By ProjectsReportPageTitle => By.XPath("//h1[contains(text(),'Reports')]");
        public By RunReportButton => By.Name("FilterForm_applyButton");
        public By ReportResultTable => By.XPath("//table[@class='listView']");
        public By ResultRows => By.XPath("//tr[contains(@class, 'listViewRow')]");
        public By ActionButton => By.XPath("//button[contains(@id, 'Action')]");
        public By ExportButton => By.XPath("//div[contains(text(), 'Export')]/parent::div");

        internal bool IsProjectsReportPageDisplayed() => IsElementDisplayedAfterWaiting(ProjectsReportPageTitle);

        public void RunReport()
        {
            ClickOnElementAfterWaiting(RunReportButton);
            WaitAndFind(ReportResultTable);
        }

        public void VerifyReportResults()
        {
            // Search for list of results and verify that it is not empty
            var results = LocateElements(ResultRows);
            results.Should().NotBeEmpty();
        }

        public void ExportReportAndVerifyResults()
        {
            // Export report to CSV and verify that file is not empty
            ClickOnElementAfterWaiting(ActionButton);
            ClickOnElementAfterWaiting(ExportButton);
            CsvReader csvReader = new CsvReader();
            var csv = csvReader.LoadCsvFile();
            csv.Should().NotBeEmpty();
            csvReader.DeleteCsvFile();
        }
    }
}
