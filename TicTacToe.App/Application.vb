Module Application

    Sub Main()

        Dim game = New TicTacToe.App.Models.TicTacToe

        Console.WriteLine("Welcome to " & game.Name)
        Console.Write("===========")
        For index As Integer = 1 To game.Name.Length
            Console.Write("=")
        Next

        Console.ReadLine()
    End Sub



End Module
