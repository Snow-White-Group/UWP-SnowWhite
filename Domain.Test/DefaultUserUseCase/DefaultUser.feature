Feature: DefaultUserFeature
	In order to see something on the mirror
	As an unauthenticated user
	I want to read some unpersonalized information on the mirror

@SNOW-UC-DU
Scenario: Switch to DefaultUser
	Given the device gets booted
	When the default user gets triggered
	Then the weather should be loaded
	And the news should be loaded
	And the user should be switched to the DefaultUser
	And the DefaultUserPage should be delivered