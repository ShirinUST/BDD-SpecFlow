Feature: Search

A short summary of the feature

@Product-Search
Scenario Outline: Search For Products
	Given User will be on the HomePage
	When User will type the '<searchtext>' in the searchbox
	* User clicks on search button
	Then Search results are loaded in the same page with '<urltext>'
Examples: 
  | searchtext |
  | water      |
  | java       |
  | hairgrass  |
