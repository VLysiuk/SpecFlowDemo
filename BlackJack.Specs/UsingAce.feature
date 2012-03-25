Feature: Using Ace
	As a player
	I want to use Ace value as one or eleven
	So that I can select the best option for me



Scenario: Use ace value as eleven
	Given I have no cards in hand
	When I take 10 and Ace
	Then I have Black Jack

Scenario: Use ace value as one
	Given I have no cards in hand
	When I take 10 and Queen and Ace
	Then I have Black Jack
