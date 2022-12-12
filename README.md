# CrmAutomationFramework

Basic framework for automation test using C# and Selenium.

Tests are covering 3 test scenarios:
Scenario 1 – Create contact:
1. Login
2. Navigate to “Sales & Marketing” -> “Contacts”
3. Create new contact (Enter at least first name, last name, role and 2 categories: Customers and
Suppliers)
4. Open created contact and check that its data matches entered on the previous step


Scenario 2 – Run report:
1. Login
2. Navigate to “Reports & Settings” -> “Reports”
3. Find “Project Profitability” report
4. Run report and verify that some results were returned


Scenario 3 – Remove events from activity log:
1. Login
2. Navigate to “Reports & Settings” -> “Activity log”
3. Select first 3 items in the table
4. Click “Actions” -> “Delete”
5. Verify that items were deleted


Added logging per test step:
![image](https://user-images.githubusercontent.com/46795587/207082976-26c90858-73dd-4f5e-b85a-870ef4c8fb94.png)

