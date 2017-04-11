Feature: TriggerEnrollmentFeature
	In order to be able to use the mirror I need to train the System,
	so that I can authenticate myself by my voice. This Training 
	needs to be triggerd so that the mirror can prepare itself

@SNOW-UC-TE
Scenario: Succsessfully trigger enrollment
       Given The mirror is currently displaying the deault user
	   And the miror state is detection
       When The gateway passes a EnrollmentRequest to the TriggerEnrollmentInteractor
       Then The mirror should show the enrollment page
	   And The mirror state should switch to enrollment
	   And The mirror state should persit the user to enroll

@SNOW-UC-TE
Scenario: Can not trigger enrollment, because someone is using the mirror
       Given The mirror is currently displaying some user
	   And the miror state is detection
       When The gateway passes a EnrollmentRequest to the TriggerEnrollmentInteractor
       Then The mirror should reject this trigger
	   And No state should be changed
	   
@SNOW-UC-TE
Scenario: Can not trigger enrollment, because some is using this mirror for enrollment
       Given The mirror is currently enrolling some user
       When The gateway passes a EnrollmentRequest to the TriggerEnrollmentInteractor
       Then The mirror should reject this trigger
	   And No state should be changed


