Feature: 
	In order to increase gaming competence
	As a human player
	I want to play against a computer player

Scenario: Start Game
	Given I have a new game
	And I have selected a computer opponent
	When I press start
	Then the gamestate should be Created

Scenario: Go First
	Given I have a new game
	And I have selected a computer opponent
	When I select to go first
	Then the result should be my turn

Scenario: Go Last
	Given I have a new game
	And I have selected a computer opponent
	When I select to go second
	Then the result should be the other player's turn

Scenario: I make a mark
	Given I have a new game
	And I have selected a computer opponent
	And I selected to go first
	And it is my turn
	And no indeces are marked
	When index 1 is marked
	Then the value of index 1 should be X
	And the date of index 1 should be 1/21/2012
	And the player of index 1 should be me
	And the invoker should be the opponent