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
            // Navigate to Activity Log
            navigationBar = new NavigationBar(_driver);
            navigationBar.GoToActivityLog();
        }

        [When(@"User deletes first '(.*)' Rows")]
        public void WhenUserDeletesFirstRows(int numbersOfRows)
        {
            // Delete first X rows based on parameter
            activityLogPage = new ActivityLogPage(_driver);
            _rows = activityLogPage.GetRowsContent(numbersOfRows);
            activityLogPage.DeleteItems(numbersOfRows);
        }

        [Then(@"Verify that '(.*)' Items are deleted")]
        public void ThenVerifyThatItemsAreDeleted(int itemsDeleted)
        {
            // Verify that rows were deleted based on elements text content
            activityLogPage.VerifyDeletionOfRows(itemsDeleted, _rows);
        }
    }
}