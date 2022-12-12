using OpenQA.Selenium;


namespace CrmSpecFlowFramework.Pages
{
    public class ActivityLogPage : BasePage
    {
        public ActivityLogPage(IWebDriver driver) : base(driver) { }

        // Locators
        public By ActivityLogPageTitle => By.XPath("//span[contains(text(),'Activity Log')]");
        public By RowContent => By.XPath("//td[@class='listViewTd']");
        public By ActionButton => By.XPath("//button[contains(@id, 'Action')]");
        public By Delete => By.XPath("//div[contains(text(), 'Delete')]/parent::div");
        public By ReloadMask => By.XPath("//div[@class='divMask']");

        internal bool IsActivityLogPageDisplayed() => IsElementDisplayedAfterWaiting(ActivityLogPageTitle);

        public List<string> GetRowsContent(int numberOfRows)
        {
            // Get content of activity log rows based on parameter and return it in a list
            var rows = LocateElements(RowContent);
            List<string> content = new List<string>();
            for (int i = 0; i < numberOfRows; i++)
            {
                content.Add(rows[i].Text);
            }
            return content;
        }

        public void DeleteItems (int numberOfItems)
        {
            // Select rows based on parameter and delete them
            for (int i = 1; i <= numberOfItems; i++)
            {
                Click(By.XPath($"(//input[contains(@onclick,'checkItem')])[{i}]"));
            }
            Click(ActionButton);
            ClickOnElementAfterWaiting(Delete);

            // Wait for alert to appear and click Accept
            var alert = WaitForAlertPresence();
            alert.Accept();
        }

        public void VerifyDeletionOfRows(int numberOfItems, List<string> deletedRowsContent)
        {
            // Verify content of first rows after deleting
            Thread.Sleep(1000);
            var content = GetRowsContent(numberOfItems);
            for(var i = 0; i < numberOfItems; i++)
            {
                content[i].Should().NotContainAny(deletedRowsContent);
            }
        }
    }
}
