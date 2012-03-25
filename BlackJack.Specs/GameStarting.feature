Feature: Game Starting
	In order to play a game
	As a player
	I want to have two cards in my hand


Scenario: Start Game
	Given Game is not started yet
	When I start the game
	Then I have 2 cards in my hand
	And Dealer has 2 cards in his hand
