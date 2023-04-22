Feature: AddAcademicResearcher

Add a new Academic Researcher by XML File extracted of Lattes Platform

Scenario: Add Academic Researcher
	Given I have a XML File of an Academic Researcher
	When I request to Add a new one
	And I request the information of the Academic Researcher added
	Then I should see the data extracted