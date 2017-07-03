Feature: StartUpFeature
	On StartUP the system has do device if a setup is requierd.
	If a setup is requiered it should be striggert

@SNOW-UC-SP
Scenario: Trigger setup
	Given snow white core is started
	When no mirror name gets found
	Then setupUC should be triggerd

@SNOW-UC-SP
Scenario: Trigger default user
	Given snow white core is started
	When mirror names are found
	Then the default user should be triggerd