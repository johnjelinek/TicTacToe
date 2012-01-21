
Namespace TicTacToe.App.Models
    Public Interface Game

        Property Name As String
        Property Opponent As Player
        ReadOnly Property State As String

        Property Invoker As Player

        Sub Start()

    End Interface
End Namespace
