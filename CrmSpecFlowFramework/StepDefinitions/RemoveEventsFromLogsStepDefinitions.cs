using CrmSpecFlowFramework.Pages;
using OpenQA.Selenium;

namespace CrmSpecFlowFramework.StepDefinitions
{
    [Binding]
    public sealed class RemoveEventsFromLogsStepDefinitions
    {
        NavigationBar navigationBar;
        ReportsPage reportsPage;
        ProjectsReportPage projectsReportPage;
        private readonly IWebDriver _driver;

        public RemoveEventsFromLogsStepDefinitions()
        {
            _driver = ScenarioContext.Current.Get<IWebDriver>("currentDriver");
        }

        [Given(@"User is on Activity Log Page")]
        public void GivenUserIsOnActivityLogPage()
        {
            throw new PendingStepException();
        }

        [When(@"User deletes first '([^']*)' Rows")]
        public void WhenUserDeletesFirstRows(string p0)
        {
            throw new PendingStepException();
        }

        [Then(@"Items are deleted")]
        public void ThenItemsAreDeleted()
        {
            throw new PendingStepException();
        }


    }
}