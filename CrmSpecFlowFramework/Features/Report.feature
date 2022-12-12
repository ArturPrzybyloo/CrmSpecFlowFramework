Feature: Reports


@RunReport
Scenario: Run Report
	Given User is on Reports Page
	Given User search for 'Project Profitability' Report
	When User run report
	Then Verify reports result in table
	Then Export report as csv file and verify result are not empty


@RemoveReportsFromLog
Scenario: Remove Event From Activity Log
	Given User is on Activity Log Page
	When User deletes first '3' Rows
	Then Verify that '3' Items are deleted
