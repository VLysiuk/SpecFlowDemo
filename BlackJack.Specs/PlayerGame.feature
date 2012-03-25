Feature: Play a Game
	As a player
	I want to play a game
	So that I can win or lose



Scenario: Black Jack
	Given I have no cards in hand
	When I have got Black Jack
	And Diller havent got Black Jack
	Then I should see a message "Black Jack! You win"

Scenario: Player wins
	Given I have drawn queen and six and three
	And dealer has drawn ten and eight
	When I have more scores than dealer
	Then I should see a message "You win"

Scenario: Player lose
	Given I have drawn queen and six and three
	And dealer has drawn ten and jack
	When I have less scores than dealer
	Then I should see a message "You lose"

Scenario: Draw game
	Given I have drawn queen and six and three
	And dealer has drawn ten and nine
	When I have equal scores with dealer
	Then I should see a message "Draw"

Scenario: I busted
	Given I have drawn queen and king and three
	When I have busted
	Then I should see a message "You busted"

Scenario: Dealer busted
	Given dealer has drawn queen and king and three
	When dealer has busted
	Then I should see a message "You win"

Scenario: Take more cards
	Given I have two cards in hand
	When I take one more
	Then my total score is incresed