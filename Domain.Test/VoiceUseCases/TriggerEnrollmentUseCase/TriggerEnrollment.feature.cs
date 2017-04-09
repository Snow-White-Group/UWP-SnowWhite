﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.1.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Domain.Test.VoiceUseCases.TriggerEnrollmentUseCase
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("TriggerEnrollmentFeature", Description="\tIn order to be able to use the mirror I need to train the System,\r\n\tso that I ca" +
        "n authenticate myself by my voice. This Training \r\n\tneeds to be triggerd so that" +
        " the mirror can prepare itself", SourceFile="VoiceUseCases\\TriggerEnrollmentUseCase\\TriggerEnrollment.feature", SourceLine=0)]
    public partial class TriggerEnrollmentFeatureFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "TriggerEnrollment.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "TriggerEnrollmentFeature", "\tIn order to be able to use the mirror I need to train the System,\r\n\tso that I ca" +
                    "n authenticate myself by my voice. This Training \r\n\tneeds to be triggerd so that" +
                    " the mirror can prepare itself", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [TechTalk.SpecRun.FeatureCleanup()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        [TechTalk.SpecRun.ScenarioCleanup()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Succsessfully trigger enrollment", new string[] {
                "SNOW-UC-UE"}, SourceLine=6)]
        public virtual void SuccsessfullyTriggerEnrollment()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Succsessfully trigger enrollment", new string[] {
                        "SNOW-UC-UE"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
       testRunner.Given("The mirror is currently displaying the deault user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
    testRunner.And("the miror state is detection", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
       testRunner.When("The gateway passes a EnrollmentRequest to the TriggerEnrollmentInteractor", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
       testRunner.Then("The mirror should show the enrollment page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 12
    testRunner.And("The mirror state should switch to enrollment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
    testRunner.And("The mirror state should persit the user to enroll", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Can not trigger enrollment, because someone is using the mirror", new string[] {
                "SNOW-UC-UE"}, SourceLine=15)]
        public virtual void CanNotTriggerEnrollmentBecauseSomeoneIsUsingTheMirror()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Can not trigger enrollment, because someone is using the mirror", new string[] {
                        "SNOW-UC-UE"});
#line 16
this.ScenarioSetup(scenarioInfo);
#line 17
       testRunner.Given("The mirror is currently displaying some user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 18
    testRunner.And("the miror state is detection", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
       testRunner.When("The gateway passes a EnrollmentRequest to the TriggerEnrollmentInteractor", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
       testRunner.Then("The mirror should reject this trigger", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 21
    testRunner.And("No state should be changed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Can not trigger enrollment, because some is using this mirror for enrollment", new string[] {
                "SNOW-UC-UE"}, SourceLine=23)]
        public virtual void CanNotTriggerEnrollmentBecauseSomeIsUsingThisMirrorForEnrollment()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Can not trigger enrollment, because some is using this mirror for enrollment", new string[] {
                        "SNOW-UC-UE"});
#line 24
this.ScenarioSetup(scenarioInfo);
#line 25
       testRunner.Given("The mirror is currently enrolling some user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 26
       testRunner.When("The gateway passes a EnrollmentRequest to the TriggerEnrollmentInteractor", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 27
       testRunner.Then("The mirror should reject this trigger", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 28
    testRunner.And("No state should be changed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.TestRunCleanup()]
        public virtual void TestRunCleanup()
        {
            TechTalk.SpecFlow.TestRunnerManager.GetTestRunner().OnTestRunEnd();
        }
    }
}
#pragma warning restore
#endregion
