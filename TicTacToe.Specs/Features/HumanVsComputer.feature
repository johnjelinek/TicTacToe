Feature: 
	In order to increase gaming competence
	As a human player
	I want to play against a computer player

Scenario: Start Game
	Given I have selected a computer opponent
	When I press start
	Then the result should be Game Started on the screen
