
Namespace TicTacToe.App.Models
    Public Class TicTacToe
        Implements Game

        Private _state As String

        Public Property Name As String Implements Game.Name
        Property Opponent As Player Implements Game.Opponent
        ReadOnly Property State As String Implements Game.State
            Get
                Return _state
            End Get
        End Property
        Property Invoker As Player Implements Game.Invoker

        Sub New()
            Name = "Tic Tac Toe"
        End Sub

        Sub Start() Implements Game.Start
            _state = "Game Started"
        End Sub

    End Class
End Namespace
