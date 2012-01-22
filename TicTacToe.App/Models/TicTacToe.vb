
Namespace TicTacToe.App.Models
    Public Class TicTacToe
        Implements Game

        Private _gameBoard(8) As GameIndex
        Private _invoker As Player
        Private _antagonist As Player
        Private _protagonist As Player
        Private _state As GameState

        ReadOnly Property State As GameState Implements Game.State
            Get
                Return _state
            End Get
        End Property
        Property Name As String Implements Game.Name
        ReadOnly Property Protagonist As Player Implements Game.Protagonist
            Get
                Return _protagonist
            End Get
        End Property
        ReadOnly Property Antagonist As Player Implements Game.Antagonist
            Get
                Return _antagonist
            End Get
        End Property
        ReadOnly Property Invoker As Player Implements Game.Invoker
            Get
                Return _invoker
            End Get
        End Property
        ReadOnly Property GameBoard As Array Implements Game.GameBoard
            Get
                Return _gameBoard
            End Get
        End Property
        ReadOnly Property FirstInvoker As Player Implements Game.FirstInvoker
            Get
                Dim plays As New List(Of GameIndex)
                For Each index As GameIndex In GameBoard
                    If index IsNot Nothing Then
                        plays.Add(index)
                    End If
                Next
                Return plays.OrderBy(Function(move) move.DateTimeStamp).FirstOrDefault.Player
            End Get
        End Property
        ReadOnly Property MarksAvailable As List(Of Integer) Implements Game.MarksAvailable
            Get
                Dim availableIndeces As New List(Of Integer)
                For index = 1 To GameBoard.Length
                    If GameBoard(index - 1) Is Nothing Then
                        availableIndeces.Add(index - 1)
                    End If
                Next
                Return availableIndeces
            End Get
        End Property

        Sub New()
            Name = "Tic Tac Toe"
        End Sub

        Sub Start() Implements Game.Start
            _state = GameState.Created
        End Sub

        Sub Start(ByVal protagonist As Player, ByVal antagonist As Player) Implements Game.Start
            _protagonist = protagonist
            _antagonist = antagonist
        End Sub

        Public Sub Mark(index As Integer) Implements Game.Mark
            Select Case State
                Case GameState.Created
                    _gameBoard(index) = New GameIndex With {.Player = Invoker, .DateTimeStamp = Now, .Value = "X"}
                    _state = GameState.InProgress
                Case GameState.InProgress
                    If Invoker Is FirstInvoker Then
                        _gameBoard(index) = New GameIndex With {.Player = Invoker, .DateTimeStamp = Now, .Value = "X"}
                    Else
                        _gameBoard(index) = New GameIndex With {.Player = Invoker, .DateTimeStamp = Now, .Value = "O"}
                    End If
                    If (_gameBoard.Length - MarksAvailable.Count) = _gameBoard.Length Then
                        _state = GameState.Finished
                    End If
            End Select
        End Sub

        Public Sub SelectOpponent(ByRef player As Player) Implements Game.SelectOpponent
            _antagonist = player
        End Sub

        Public Sub SwitchPlayers() Implements Game.SwitchPlayers
            If _invoker Is Antagonist Then
                _invoker = Protagonist
            Else
                _invoker = Antagonist
            End If
        End Sub

        Public Sub SwitchPlayers(ByRef player As Player) Implements Game.SwitchPlayers
            _invoker = player
        End Sub

    End Class

End Namespace
