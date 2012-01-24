
Namespace TicTacToe.App.Models
    Public Class TicTacToe
        Implements Game

        Private _antagonist As Player
        Private _gameBoard(8) As GameIndex
        Private _invoker As Player
        Private _name As String
        Private _protagonist As Player
        Private _state As GameState
        Private _canWin As Boolean
        Private _canBlock As Boolean
        Private _canFork As Boolean
        Private _canBlockFork As Boolean
        Private _canPlayCenter As Boolean
        Private _canPlayOppositeCorner As Boolean
        Private _canPlayEmptyCorner As Boolean
        Private _canPlayEmptyEdge As Boolean

        ReadOnly Property State As GameState Implements Game.State
            Get
                Return _state
            End Get
        End Property
        ReadOnly Property Name As String Implements Game.Name
            Get
                Return _name
            End Get
        End Property
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
                Dim availablePositions As New List(Of Integer)
                For markPosition = 1 To GameBoard.Length
                    If GameBoard(markPosition - 1) Is Nothing Then
                        availablePositions.Add(markPosition)
                    End If
                Next
                Return availablePositions
            End Get
        End Property
        ReadOnly Property SomeoneWins As Boolean Implements Game.SomeoneWins
            Get
                ' 3 Vertically
                If Not MarksAvailable.Contains(1) _
                    AndAlso Not MarksAvailable.Contains(4) _
                    AndAlso Not MarksAvailable.Contains(7) Then
                    If CType(GameBoard(0), GameIndex).Value = CType(GameBoard(3), GameIndex).Value _
                    AndAlso CType(GameBoard(3), GameIndex).Value = CType(GameBoard(6), GameIndex).Value Then
                        Return True
                    End If
                End If
                If Not MarksAvailable.Contains(2) _
                    AndAlso Not MarksAvailable.Contains(5) _
                    AndAlso Not MarksAvailable.Contains(8) Then
                    If CType(GameBoard(1), GameIndex).Value = CType(GameBoard(4), GameIndex).Value _
                    AndAlso CType(GameBoard(4), GameIndex).Value = CType(GameBoard(7), GameIndex).Value Then
                        Return True
                    End If
                End If
                If Not MarksAvailable.Contains(3) _
                    AndAlso Not MarksAvailable.Contains(6) _
                    AndAlso Not MarksAvailable.Contains(9) Then
                    If CType(GameBoard(2), GameIndex).Value = CType(GameBoard(5), GameIndex).Value _
                    AndAlso CType(GameBoard(5), GameIndex).Value = CType(GameBoard(8), GameIndex).Value Then
                        Return True
                    End If
                End If
                ' 3 Horizontally
                If Not MarksAvailable.Contains(1) _
                    AndAlso Not MarksAvailable.Contains(2) _
                    AndAlso Not MarksAvailable.Contains(3) Then
                    If CType(GameBoard(0), GameIndex).Value = CType(GameBoard(1), GameIndex).Value _
                    AndAlso CType(GameBoard(1), GameIndex).Value = CType(GameBoard(2), GameIndex).Value Then
                        Return True
                    End If
                End If
                If Not MarksAvailable.Contains(4) _
                    AndAlso Not MarksAvailable.Contains(5) _
                    AndAlso Not MarksAvailable.Contains(6) Then
                    If CType(GameBoard(3), GameIndex).Value = CType(GameBoard(4), GameIndex).Value _
                    AndAlso CType(GameBoard(4), GameIndex).Value = CType(GameBoard(5), GameIndex).Value Then
                        Return True
                    End If
                End If
                If Not MarksAvailable.Contains(7) _
                    AndAlso Not MarksAvailable.Contains(8) _
                    AndAlso Not MarksAvailable.Contains(9) Then
                    If CType(GameBoard(6), GameIndex).Value = CType(GameBoard(7), GameIndex).Value _
                    AndAlso CType(GameBoard(7), GameIndex).Value = CType(GameBoard(8), GameIndex).Value Then
                        Return True
                    End If
                End If
                ' 3 Diagonally \
                If Not MarksAvailable.Contains(1) _
                    AndAlso Not MarksAvailable.Contains(5) _
                    AndAlso Not MarksAvailable.Contains(9) Then
                    If CType(GameBoard(0), GameIndex).Value = CType(GameBoard(4), GameIndex).Value _
                    AndAlso CType(GameBoard(4), GameIndex).Value = CType(GameBoard(8), GameIndex).Value Then
                        Return True
                    End If
                End If
                ' 3 Diagonally /
                If Not MarksAvailable.Contains(3) _
                    AndAlso Not MarksAvailable.Contains(5) _
                    AndAlso Not MarksAvailable.Contains(7) Then
                    If CType(GameBoard(2), GameIndex).Value = CType(GameBoard(4), GameIndex).Value _
                    AndAlso CType(GameBoard(4), GameIndex).Value = CType(GameBoard(6), GameIndex).Value Then
                        Return True
                    End If
                End If
                Return False
            End Get
        End Property
        ReadOnly Property LastMark As GameIndex Implements Game.LastMark
            Get
                Dim plays As New List(Of GameIndex)
                For Each index As GameIndex In GameBoard
                    If index IsNot Nothing Then
                        plays.Add(index)
                    End If
                Next
                Return plays.OrderByDescending(Function(mark) mark.DateTimeStamp).FirstOrDefault
            End Get
        End Property
        ReadOnly Property Corners As List(Of Integer)
            Get
                Dim positions As New List(Of Integer)
                positions.Add(1)
                positions.Add(3)
                positions.Add(7)
                positions.Add(9)
                Return positions
            End Get
        End Property
        ReadOnly Property Edges As List(Of Integer)
            Get
                Dim positions As New List(Of Integer)
                positions.Add(2)
                positions.Add(4)
                positions.Add(6)
                positions.Add(8)
                Return positions
            End Get
        End Property
        ReadOnly Property Center As List(Of Integer)
            Get
                Dim position As New List(Of Integer)
                position.Add(5)
                Return position
            End Get
        End Property
        ReadOnly Property CanWin(player As Player) As Boolean
            Get
                Return _canWin
            End Get
        End Property
        ReadOnly Property CanBlock(player As Player) As Boolean
            Get
                Return _canBlock
            End Get
        End Property
        ReadOnly Property CanFork(player As Player) As Boolean
            Get
                Return _canFork
            End Get
        End Property
        ReadOnly Property CanBlockFork(player As Player) As Boolean
            Get
                Return _canBlockFork
            End Get
        End Property
        ReadOnly Property CanPlayCenter(player As Player) As Boolean
            Get
                Return _canPlayCenter
            End Get
        End Property
        ReadOnly Property CanPlayOppositeCorner(player As Player) As Boolean
            Get
                Return _canPlayOppositeCorner
            End Get
        End Property
        ReadOnly Property CanPlayEmptyCorner(player As Player) As Boolean
            Get
                Return _canPlayEmptyCorner
            End Get
        End Property
        ReadOnly Property CanPlayEmptyEdge(player As Player) As Boolean
            Get
                Return _canPlayEmptyEdge
            End Get
        End Property

        Sub New()
            _name = "Tic Tac Toe"
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
                    If MarksAvailable.Contains(index + 1) Then
                        If Invoker Is FirstInvoker Then
                            _gameBoard(index) = New GameIndex With {.Player = Invoker, .DateTimeStamp = Now, .Value = "X"}
                        Else
                            _gameBoard(index) = New GameIndex With {.Player = Invoker, .DateTimeStamp = Now, .Value = "O"}
                        End If
                    Else
                        Throw New InvalidOperationException("Unable to mark that spot")
                    End If
                    ' Wins
                    If SomeoneWins Then
                        _state = GameState.Finished
                    End If
                    ' Tie
                    If (_gameBoard.Length - MarksAvailable.Count) = _gameBoard.Length Then
                        _state = GameState.Finished
                    End If
            End Select
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
