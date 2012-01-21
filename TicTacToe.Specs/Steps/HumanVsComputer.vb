Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports TicTacToe.App.Models
Imports TechTalk.SpecFlow
Imports FluentAssertions

Namespace TicTacToe.Specs.Steps

    <Binding()> _
    Public Class HumanVsComputer
        <BeforeScenario()> _
        Public Sub BeforeScenario()
            ScenarioContext.Current.Add("game", New App.Models.TicTacToe)
        End Sub

        <[Given]("I have selected a (.*) opponent")> _
        Public Sub GivenIHaveSelectedAnOpponent(ByVal opponent As String)
            Select Case opponent
                Case "computer"
                    ScenarioContext.Current.Get(Of Game)("game").Opponent = New Computer
                Case Else
                    ScenarioContext.Current.Get(Of Game)("game").Opponent = New Human
            End Select
        End Sub

        <[When]("I press start")> _
        Public Sub WhenIPressStart()
            ScenarioContext.Current.Get(Of Game)("game").Start()
        End Sub

        <[Then]("the result should be (.*) on the screen")> _
        Public Sub ThenTheResultShouldBe(ByVal result As String)
            ScenarioContext.Current.Get(Of Game)("game").State.Should.Be(result)
        End Sub

    End Class

End Namespace
