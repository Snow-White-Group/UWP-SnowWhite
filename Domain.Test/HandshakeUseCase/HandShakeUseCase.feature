Feature: HandShakeUseCase

@SNOW-UC-HS
Scenario: Trigger Handshake
	Given The Handshake use case gets triggert
	Then snow white core should established a connection to snow white cloud
	Then snow white core should get a display name from snow white cloud
	Then snow white core should get a secret name from snow white cloud 
	Then snow white core should store this infromation in local APP Settings 
	Then the defaultuser use case should be triggerd