Feature: Browse Movies
	As a User
	I want to Browse Movies
	So I can see the contents of the library
	
	Scenario: Browse empty library
		Given I have no movies stored
		When  I browse the movies
		Then  I should a notification explaining the listing is empty

	Scenario: Browse available movies
		Given I have some movies stored
		When  I browse the movies
		Then  I should see all the movies listed
		