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
                Return 1
            Case "2"
                game.SwitchPlayers(game.Protagonist)
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
                game.Mark(input - 1)
                game.SwitchPlayers()
            Else
                Console.WriteLine("Invalid Choice" & vbNewLine)
            End If
        ElseIf TypeOf game.Invoker Is Computer Then
            Console.WriteLine("Computer is thinking")
            Threading.Thread.Sleep(1000)
            game.Mark(game.MarksAvailable.FirstOrDefault() - 1)
            game.SwitchPlayers()
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

End Module
