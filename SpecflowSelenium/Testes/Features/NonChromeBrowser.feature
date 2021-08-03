Feature: NonChromeBrowser
	Testing non chrome browsers

@ToDoApp
Scenario: Add items to the ToDoApp - Firefox
	Given I select the first item
	And I select the second item
	And I enter the new value in textbox
	When I click the Submit button
	Then I verify wheter the item is added to the list
