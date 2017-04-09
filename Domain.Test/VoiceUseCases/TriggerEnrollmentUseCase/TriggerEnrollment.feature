Feature: TriggerEnrollmentFeature
	In order to be able to use the mirror I need to train the System,
	so that I can authenticate myself by my voice. This Training 
	needs to be triggerd so that the mirror can prepare itself

@SNOW-UC-UE 
Scenario: Gatway triggers the enrollment
       Given The mirror is currently displaying the deault user
       When The gateway passes a EnrollmentRequest
       Then The mirror should show the enrollment page
	   And The mirror state should switch to enrollment
	   And The mirror state should persit the user to enroll
	   

