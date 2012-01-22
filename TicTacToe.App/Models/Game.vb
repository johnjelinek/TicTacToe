
Namespace TicTacToe.App.Models
    Public Interface Game


        ReadOnly Property Antagonist As Player
        ReadOnly Property FirstInvoker As Player
        ReadOnly Property GameBoard As Array
        ReadOnly Property Invoker As Player
        ReadOnly Property MarksAvailable As List(Of Integer)
        ReadOnly Property Name As String
        ReadOnly Property Protagonist As Player
        ReadOnly Property SomeoneWins As Boolean
        ReadOnly Property State As GameState

        Sub Mark(index As Integer)
        Sub Start()
        Sub Start(protagonist As Player, antagonist As Player)
        Sub SwitchPlayers()
        Sub SwitchPlayers(ByRef player As Player)

    End Interface
End Namespace
