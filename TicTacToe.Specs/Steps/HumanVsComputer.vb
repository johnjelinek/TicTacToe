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
            ScenarioContext.Current.Get(Of Game)("game").State.Should.Be(App.Models.GameState.Created)
        End Sub

        <[Given]("it is my turn")> _
        Public Sub GivenItIsMyTurn()
            GivenIHaveANewGame()
            WhenISelectToGo("first")
            ScenarioContext.Current.Get(Of Game)("game").Invoker.Should.Be(ScenarioContext.Current.Get(Of Player)("protagonist"))
        End Sub

        <[Given]("no indeces are marked")> _
        Public Sub GivenNoIndecesAreMarked()
            CType(ScenarioContext.Current.Get(Of Game)("game").GameBoard, GameIndex()).Where(Function(index) index IsNot Nothing).Count.Should.Be(0)
        End Sub

        <[When]("I press start")> _
        Public Sub WhenIPressStart()
            ScenarioContext.Current.Get(Of Game)("game").Start()
        End Sub

        <[When]("I select to go (.*)")> _
        Public Sub WhenISelectToGo(ByVal turn As String)
            ScenarioContext.Current.Get(Of Game)("game").Start(turn, ScenarioContext.Current.Get(Of Player)("protagonist"))
        End Sub

        <[When]("index (.*) is marked")> _
        Public Sub WhenIndexIsMarked(ByVal index As Integer)
            ScenarioContext.Current.Get(Of Game)("game").Mark(index)
        End Sub

        <[Then]("the gamestate should be (.*)")> _
        Public Sub ThenTheGameStateShouldBe(ByVal result As String)
            Select Case result
                Case "Created"
                    ScenarioContext.Current.Get(Of Game)("game").State.Should.Be(GameState.Created)
                Case "In Progress"
                    ScenarioContext.Current.Get(Of Game)("game").State.Should.Be(GameState.InProgress)
                Case "Finished"
                    ScenarioContext.Current.Get(Of Game)("game").State.Should.Be(GameState.Finished)
                Case Else
                    ScenarioContext.Current.Pending()
            End Select
        End Sub

        <[Then]("the result should be my turn")> _
        Public Sub ThenTheResultShouldBeMyTurn()
            ScenarioContext.Current.Get(Of Game)("game").Invoker.Should.Be(ScenarioContext.Current.Get(Of Player)("protagonist"))
        End Sub

        <[Then]("the result should be the other player's turn")> _
        Public Sub ThenTheResultShouldBeTheOtherPlayersTurn()
            ScenarioContext.Current.Get(Of Game)("game").Invoker.Should.Be(ScenarioContext.Current.Get(Of Game)("game").Opponent)
        End Sub

        <[Then]("the value of index (.*) should be (.*)")> _
        Public Sub ThenTheValueOfIndexShouldBe(ByVal index As Integer, ByVal value As Char)
            CType(ScenarioContext.Current.Get(Of Game)("game").GameBoard(index), GameIndex).Value.Should.Be(value)
        End Sub

        <[Then]("the date of index (.*) should be (.*)")> _
        Public Sub ThenTheDateOfIndexShouldBe(ByVal index As Integer, ByVal day As Date)
            CType(ScenarioContext.Current.Get(Of Game)("game").GameBoard(index), GameIndex).DateTimeStamp.Date.Should.Be(day)
        End Sub

        <[Then]("the player of index (.*) should be me")> _
        Public Sub ThenThePlayerOfIndexShouldBeMe(ByVal index As Integer)
            CType(ScenarioContext.Current.Get(Of Game)("game").GameBoard(index), GameIndex).Player.Should.Be(ScenarioContext.Current.Get(Of Player)("protagonist"))
        End Sub

        <[Then]("the invoker should be the opponent")> _
        Public Sub ThenTheInvokerShouldBeTheOpponent()
            ScenarioContext.Current.Get(Of Game)("game").Invoker.Should.Be(ScenarioContext.Current.Get(Of Game)("game").Opponent)
        End Sub


    End Class

End Namespace
