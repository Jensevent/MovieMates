Feature: HomePage
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers


Scenario: I like a movie
	Given I have navigated to "http://localhost:3000/"
	Then I log in
	Then I select genre "1"
	Then I click the like button


Scenario: I dislike a movie
	Given I have navigated to "http://localhost:3000/"
	Then I log in
	Then I select genre "1"
	Then I click the dislike button


Scenario: There is no movie with that genre
	Given I have navigated to "http://localhost:3000/"
	Then I log in
	Then I select genre "5"
	Then There are no movies available


Scenario: I log out
	Given I have navigated to "http://localhost:3000/"
	Then I log in
	Then I log out