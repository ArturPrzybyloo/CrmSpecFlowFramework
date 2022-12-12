Feature: Contacts


@CreateContact
Scenario: Create contact
	Given User is on Create Contact Page
	When Create new contact with category 'Business' and role 'CEO'
	Then Verify that Contact is created
