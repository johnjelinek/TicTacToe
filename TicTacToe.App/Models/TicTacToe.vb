
Namespace TicTacToe.App.Models
    Public Class TicTacToe
        Implements Game

        Private _state As String
        Private _invoker As Player
        Private _gameBoard(8) As GameIndex

        Public Property Name As String Implements Game.Name
        Property Opponent As Player Implements Game.Opponent
        ReadOnly Property State As String Implements Game.State
            Get
                Return _state
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

        Sub New()
            Name = "Tic Tac Toe"
        End Sub

        Sub Start() Implements Game.Start
            _state = "Game Started"
        End Sub

        Sub Start(ByVal turn As String, ByVal player As Player) Implements Game.Start
            Select Case turn
                Case "first"
                    _invoker = player
                Case Else
                    _invoker = Me.Opponent
            End Select
        End Sub

        Public Sub Mark(index As Integer) Implements Game.Mark
            If _gameBoard.Where(Function(spot) spot IsNot Nothing).Count > 0 Then
                If _gameBoard.OrderBy(Function(marks) marks.Time).FirstOrDefault.Player Is Invoker Then
                    _gameBoard(index) = New GameIndex With {.Player = Invoker, .Time = Now.Date, .Value = "X"}
                Else
                    _gameBoard(index) = New GameIndex With {.Player = Invoker, .Time = Now.Date, .Value = "O"}
                End If
            Else
                _gameBoard(index) = New GameIndex With {.Player = Invoker, .Time = Now.Date, .Value = "X"}
            End If
            _invoker = Me.Opponent
        End Sub
    End Class
End Namespace
