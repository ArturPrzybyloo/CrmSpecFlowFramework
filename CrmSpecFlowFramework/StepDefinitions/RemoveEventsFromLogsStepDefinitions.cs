using CrmSpecFlowFramework.Pages;
using OpenQA.Selenium;

namespace CrmSpecFlowFramework.StepDefinitions
{
    [Binding]
    public sealed class RemoveEventsFromLogsStepDefinitions
    {
        NavigationBar navigationBar;
        ActivityLogPage activityLogPage;
        private readonly IWebDriver _driver;
        List<string> _rows;

        public RemoveEventsFromLogsStepDefinitions()
        {
            _driver = ScenarioContext.Current.Get<IWebDriver>("currentDriver");
        }

        [Given(@"User is on Activity Log Page")]
        public void GivenUserIsOnActivityLogPage()
        {
            navigationBar = new NavigationBar(_driver);
            navigationBar.GoToActivityLog();
        }

        [When(@"User deletes first '(.*)' Rows")]
        public void WhenUserDeletesFirstRows(int numbersOfRows)
        {
            activityLogPage = new ActivityLogPage(_driver);
            _rows = activityLogPage.GetRowsContent(numbersOfRows);
            activityLogPage.DeleteItems(numbersOfRows);
        }

        [Then(@"Verify that '(.*)' Items are deleted")]
        public void ThenVerifyThatItemsAreDeleted(int itemsDeleted)
        {
            activityLogPage.VerifyDeletionOfRows(itemsDeleted, _rows);
        }
    }
}