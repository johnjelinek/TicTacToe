
Namespace TicTacToe.App.Models
    Public Interface Game

        Property Name As String
        Property Opponent As Player
        ReadOnly Property State As String
        ReadOnly Property Invoker As Player

        ReadOnly Property GameBoard As Array

        Sub Start()
        Sub Start(ByVal turn As String, ByVal player As Player)
        Sub Mark(index As Integer)

    End Interface
End Namespace
