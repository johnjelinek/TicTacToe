Imports TicTacToe.App.Models

Module Application

    Sub Main()

        Dim game = New TicTacToe.App.Models.TicTacToe
        Dim input = ""

        intro(game)
        
        Console.WriteLine()
        Console.WriteLine("Hit Enter to Start")
        Console.ReadLine()
        game.Start()
        Select Case game.State
            Case TicTacToe.App.Models.GameState.Created
                Do Until pickAnOpponent(game) > 0
                    pickAnOpponent(game)
                Loop
                Do Until whoIsFirst(game) > 0
                    whoIsFirst(game)
                Loop
                If game.Invoker Is game.Antagonist Then
                    makeYourMove(game)
                    Console.WriteLine()
                End If
                Do Until game.State = GameState.Finished
                    showTheBoard(game)
                    Console.WriteLine()
                    makeYourMove(game)
                    Console.WriteLine()
                Loop
                showTheBoard(game)
                Console.WriteLine("Game Over")
            Case TicTacToe.App.Models.GameState.InProgress
                Console.WriteLine("Game is in progress")
            Case TicTacToe.App.Models.GameState.Finished
                Console.WriteLine("Game Over")
            Case Else
                Console.WriteLine("Game has not yet started")
        End Select

        Console.ReadLine()
    End Sub

    Sub intro(ByRef game As Game)
        Console.WriteLine("Welcome to " & game.Name)
        Console.Write("===========")
        For index As Integer = 1 To game.Name.Length
            Console.Write("=")
        Next
    End Sub

    Private Function pickAnOpponent(game As Game) As Integer
        Console.WriteLine("Select your opponent")
        Console.WriteLine("[1] Computer")
        Console.Write("Please pick a number from available opponents: ")
        Select Case Console.ReadLine
            Case "1"
                game.Start(New Human, New Computer)
                Return 1
            Case Else
                Console.WriteLine("Invalid Choice" & vbNewLine)
                Return -1
        End Select
    End Function

    Private Function whoIsFirst(game As Game) As Integer
        Console.WriteLine("Who goes first?")
        Console.WriteLine("[1] Computer")
        Console.WriteLine("[2] You")
        Console.Write("Please pick a number for the available options: ")
        Select Case Console.ReadLine
            Case "1"
                game.SwitchPlayers(game.Antagonist)
                Console.WriteLine("Computer is ""X"" and You are ""O""")
                Return 1
            Case "2"
                game.SwitchPlayers(game.Protagonist)
                Console.WriteLine("You are ""X"" and Computer is ""O""")
                Return 1
            Case Else
                Console.WriteLine("Invalid Choice" & vbNewLine)
                Return -1
        End Select
    End Function

    Private Sub makeYourMove(game As Game)
        If TypeOf game.Invoker Is Human Then
            Console.WriteLine("You are up, make your mark")
            Console.Write("Pick a number on the board: ")
            Dim input As Integer
            If Integer.TryParse(Console.ReadLine, input) Then
                Try
                    game.Mark(input - 1)
                    game.SwitchPlayers()
                Catch ex As InvalidOperationException
                    Console.WriteLine(vbNewLine & ex.Message & vbNewLine)
                    makeYourMove(game)
                End Try
            Else
                Console.WriteLine("Invalid Choice" & vbNewLine)
            End If
        ElseIf TypeOf game.Invoker Is Computer Then
            Console.WriteLine("Computer is thinking")
            Threading.Thread.Sleep(1000)
            Try
                game.Mark(calculateMark(game) - 1)
                game.SwitchPlayers()
            Catch ex As InvalidOperationException
                Console.WriteLine(vbNewLine & ex.Message & vbNewLine)
                makeYourMove(game)
            End Try
        End If
    End Sub

    Private Sub showTheBoard(game As Game)
        For index = 1 To game.GameBoard.Length
            If index Mod 3 Then
                If game.MarksAvailable.Contains(index) Then
                    Console.Write(index)
                Else
                    Console.Write(CType(game.GameBoard(index - 1), GameIndex).Value)
                End If
            Else
                If game.MarksAvailable.Contains(index) Then
                    Console.WriteLine(index)
                Else
                    Console.WriteLine(CType(game.GameBoard(index - 1), GameIndex).Value)
                End If
            End If
        Next
    End Sub

    Private Function calculateMark(game As TicTacToe.App.Models.TicTacToe) As Integer
        If TypeOf game.Invoker Is Computer Then
            'Strategy:
            'Win: If the player has two in a row, play the third to get three in a row.
            If game.CanWin(game.Invoker) Then

            End If
            'Block: If the [opponent] has two in a row, play the third to block them.
            If game.CanBlock(game.Invoker) Then

            End If
            'Fork: Create an opportunity where you can win in two ways.
            If game.CanFork(game.Invoker) Then

            End If
            'Block opponent's Fork:
            If game.CanBlockFork(game.Invoker) Then
                '   Option 1: Create two in a row to force the opponent into defending, as long as it doesn't result in them creating a fork or winning. For example, if "X" has a corner, "O" has the center, and "X" has the opposite corner as well, "O" must not play a corner in order to win. (Playing a corner in this scenario creates a fork for "X" to win.)
                '   Option 2: If there is a configuration where the opponent can fork, block that fork.
            End If
            'Center: Play the center.
            If game.CanPlayCenter(game.Invoker) Then

            End If
            'Opposite corner: If the opponent is in the corner, play the opposite corner.
            If game.CanPlayOppositeCorner(game.Invoker) Then

            End If
            'Empty corner: Play in a corner square.
            If game.CanPlayEmptyCorner(game.Invoker) Then

            End If
            'Empty side: Play in a middle square on any of the 4 sides.
            If game.CanPlayEmptyEdge(game.Invoker) Then

            End If
        End If
    End Function

End Module
