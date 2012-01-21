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
            ScenarioContext.Current.Add("protagonist", New Human)
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

        <[Given]("I have a new game")> _
        Public Sub GivenIHaveANewGame()
            ScenarioContext.Current.Get(Of Game)("game").Opponent = New Computer
            ScenarioContext.Current.Get(Of Game)("game").Start()
            ScenarioContext.Current.Get(Of Game)("game").State.Should.Be("Game Started")
        End Sub

        <[When]("I press start")> _
        Public Sub WhenIPressStart()
            ScenarioContext.Current.Get(Of Game)("game").Start()
        End Sub

        <[When]("I select to go (.*)")> _
        Public Sub WhenISelectToGo(ByVal turn As String)
            Select Case turn
                Case "first"
                    ScenarioContext.Current.Get(Of Game)("game").Invoker = ScenarioContext.Current.Get(Of Player)("protagonist")
                Case Else
                    ScenarioContext.Current.Get(Of Game)("game").Invoker = ScenarioContext.Current.Get(Of Game)("game").Opponent
            End Select
        End Sub

        <[Then]("the result should be (.*) on the screen")> _
        Public Sub ThenTheResultShouldBe(ByVal result As String)
            ScenarioContext.Current.Get(Of Game)("game").State.Should.Be(result)
        End Sub

        <[Then]("the result should be my turn")> _
        Public Sub ThenTheResultShouldBeMyTurn()
            ScenarioContext.Current.Get(Of Game)("game").Invoker.Should.Be(ScenarioContext.Current.Get(Of Player)("protagonist"))
        End Sub

        <[Then]("the result should be the other player's turn")> _
        Public Sub ThenTheResultShouldBeTheOtherPlayersTurn()
            ScenarioContext.Current.Get(Of Game)("game").Invoker.Should.Be(ScenarioContext.Current.Get(Of Game)("game").Opponent)
        End Sub

    End Class

End Namespace
