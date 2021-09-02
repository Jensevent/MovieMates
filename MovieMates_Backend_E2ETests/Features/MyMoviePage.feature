Feature: MyMoviePage
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: I like a movie
	Given I have navigated to "http://localhost:3000/"
	Then I log in
	Then I navigate to "http://localhost:3000/movies"
	Then I mark a movie as watched