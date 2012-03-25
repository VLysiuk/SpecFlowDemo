Feature: Dealer game
	As a dealer
	I have to play a game because it is my job


Scenario: More then 17
	Given dealer has drawn ten and eight
	When dealer has total score more then 17
	Then he cannot take a card

Scenario: Player finished
	Given player has finished drawing
	When  dealer has total score less then 17
	Then he should take a card while his total score less then 17

Scenario: Player not finished
	Given player has not finished drawing
	When  dealer has total score less then 17
	Then he should take a card
