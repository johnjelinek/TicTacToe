
Namespace TicTacToe.App.Models
    Public Class TicTacToe
        Implements Game

        Property Opponent As Player Implements Game.Opponent
        Property State As String Implements Game.State

        Sub Start() Implements Game.Start
            State = "Game Started"
        End Sub

    End Class
End Namespace
