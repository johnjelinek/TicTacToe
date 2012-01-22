﻿
Namespace TicTacToe.App.Models
    Public Interface Game

        Property Name As String
        ReadOnly Property Protagonist As Player
        ReadOnly Property Antagonist As Player
        ReadOnly Property State As GameState
        ReadOnly Property Invoker As Player
        ReadOnly Property FirstInvoker As Player
        ReadOnly Property GameBoard As Array
        ReadOnly Property MarksAvailable As List(Of Integer)
        ReadOnly Property SomeoneWins As Boolean

        Sub Start()
        Sub Start(protagonist As Player, antagonist As Player)
        Sub Mark(index As Integer)
        Sub SwitchPlayers()
        Sub SwitchPlayers(ByRef player As Player)

    End Interface
End Namespace
