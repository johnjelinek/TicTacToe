
Namespace TicTacToe.App.Models
    Public Interface Game

        Property Opponent As Player
        Property State As String
        Property Invoker As Player

        Sub Start()

    End Interface
End Namespace
