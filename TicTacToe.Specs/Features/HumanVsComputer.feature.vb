﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by SpecFlow (http://www.specflow.org/).
'     SpecFlow Version:1.8.1.0
'     SpecFlow Generator Version:1.8.0.0
'     Runtime Version:4.0.30319.239
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------
#Region "Designer generated code"
'#pragma warning disable
Imports TechTalk.SpecFlow

Namespace SpecFlow.GeneratedTests
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.8.1.0"),  _
     System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     NUnit.Framework.TestFixtureAttribute(),  _
     NUnit.Framework.DescriptionAttribute("")>  _
    Partial Public Class Feature
        
        Private Shared testRunner As TechTalk.SpecFlow.ITestRunner
        
#ExternalSource("HumanVsComputer.feature",1)
#End ExternalSource
        
        <NUnit.Framework.TestFixtureSetUpAttribute()>  _
        Public Overridable Sub FeatureSetup()
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner
            Dim featureInfo As TechTalk.SpecFlow.FeatureInfo = New TechTalk.SpecFlow.FeatureInfo(New System.Globalization.CultureInfo("en-US"), "", "In order to increase gaming competence"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"As a human player"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"I want to play against"& _ 
                    " a computer player", ProgrammingLanguage.VB, CType(Nothing,String()))
            testRunner.OnFeatureStart(featureInfo)
        End Sub
        
        <NUnit.Framework.TestFixtureTearDownAttribute()>  _
        Public Overridable Sub FeatureTearDown()
            testRunner.OnFeatureEnd
            testRunner = Nothing
        End Sub
        
        <NUnit.Framework.SetUpAttribute()>  _
        Public Overridable Sub TestInitialize()
        End Sub
        
        <NUnit.Framework.TearDownAttribute()>  _
        Public Overridable Sub ScenarioTearDown()
            testRunner.OnScenarioEnd
        End Sub
        
        Public Overridable Sub ScenarioSetup(ByVal scenarioInfo As TechTalk.SpecFlow.ScenarioInfo)
            testRunner.OnScenarioStart(scenarioInfo)
        End Sub
        
        Public Overridable Sub ScenarioCleanup()
            testRunner.CollectScenarioErrors
        End Sub
        
        <NUnit.Framework.TestAttribute(),  _
         NUnit.Framework.DescriptionAttribute("Start Game")>  _
        Public Overridable Sub StartGame()
            Dim scenarioInfo As TechTalk.SpecFlow.ScenarioInfo = New TechTalk.SpecFlow.ScenarioInfo("Start Game", CType(Nothing,String()))
#ExternalSource("HumanVsComputer.feature",6)
Me.ScenarioSetup(scenarioInfo)
#End ExternalSource
#ExternalSource("HumanVsComputer.feature",7)
 testRunner.Given("I have selected a computer opponent")
#End ExternalSource
#ExternalSource("HumanVsComputer.feature",8)
 testRunner.When("I press start")
#End ExternalSource
#ExternalSource("HumanVsComputer.feature",9)
 testRunner.Then("the gamestate should be Created")
#End ExternalSource
            Me.ScenarioCleanup
        End Sub
        
        <NUnit.Framework.TestAttribute(),  _
         NUnit.Framework.DescriptionAttribute("Go First")>  _
        Public Overridable Sub GoFirst()
            Dim scenarioInfo As TechTalk.SpecFlow.ScenarioInfo = New TechTalk.SpecFlow.ScenarioInfo("Go First", CType(Nothing,String()))
#ExternalSource("HumanVsComputer.feature",11)
Me.ScenarioSetup(scenarioInfo)
#End ExternalSource
#ExternalSource("HumanVsComputer.feature",12)
 testRunner.Given("I have a new game")
#End ExternalSource
#ExternalSource("HumanVsComputer.feature",13)
 testRunner.When("I select to go first")
#End ExternalSource
#ExternalSource("HumanVsComputer.feature",14)
 testRunner.Then("the result should be my turn")
#End ExternalSource
            Me.ScenarioCleanup
        End Sub
        
        <NUnit.Framework.TestAttribute(),  _
         NUnit.Framework.DescriptionAttribute("Go Last")>  _
        Public Overridable Sub GoLast()
            Dim scenarioInfo As TechTalk.SpecFlow.ScenarioInfo = New TechTalk.SpecFlow.ScenarioInfo("Go Last", CType(Nothing,String()))
#ExternalSource("HumanVsComputer.feature",16)
Me.ScenarioSetup(scenarioInfo)
#End ExternalSource
#ExternalSource("HumanVsComputer.feature",17)
 testRunner.Given("I have a new game")
#End ExternalSource
#ExternalSource("HumanVsComputer.feature",18)
 testRunner.When("I select to go second")
#End ExternalSource
#ExternalSource("HumanVsComputer.feature",19)
 testRunner.Then("the result should be the other player's turn")
#End ExternalSource
            Me.ScenarioCleanup
        End Sub
        
        <NUnit.Framework.TestAttribute(),  _
         NUnit.Framework.DescriptionAttribute("I move first")>  _
        Public Overridable Sub IMoveFirst()
            Dim scenarioInfo As TechTalk.SpecFlow.ScenarioInfo = New TechTalk.SpecFlow.ScenarioInfo("I move first", CType(Nothing,String()))
#ExternalSource("HumanVsComputer.feature",21)
Me.ScenarioSetup(scenarioInfo)
#End ExternalSource
#ExternalSource("HumanVsComputer.feature",22)
 testRunner.Given("it is my turn")
#End ExternalSource
#ExternalSource("HumanVsComputer.feature",23)
 testRunner.And("no indeces are marked")
#End ExternalSource
#ExternalSource("HumanVsComputer.feature",24)
 testRunner.When("index 1 is marked")
#End ExternalSource
#ExternalSource("HumanVsComputer.feature",25)
 testRunner.Then("the value of index 1 should be X")
#End ExternalSource
#ExternalSource("HumanVsComputer.feature",26)
 testRunner.And("the date of index 1 should be 1/21/2012")
#End ExternalSource
#ExternalSource("HumanVsComputer.feature",27)
 testRunner.And("the player of index 1 should be me")
#End ExternalSource
#ExternalSource("HumanVsComputer.feature",28)
 testRunner.And("the invoker should be the opponent")
#End ExternalSource
            Me.ScenarioCleanup
        End Sub
    End Class
End Namespace
'#pragma warning restore
#End Region
