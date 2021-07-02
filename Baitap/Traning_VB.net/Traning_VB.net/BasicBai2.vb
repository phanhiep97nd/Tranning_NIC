Public Class BasicBai2
    Public Sub CheckScrappy()
        For i As Integer = 1 To 15 Step 1
            Console.WriteLine("(Số lần nhập còn lại:" & (15 - i) & ")")
            Console.WriteLine("Mời bạn nhập: ")
            Dim userInput As String
            userInput = Console.ReadLine()
            Console.Clear()
            If userInput = "Scrappy" Then
                Console.WriteLine("Scrappy was the name entered by the user.")
                Console.ReadLine()
                Exit Sub
            End If
        Next
        Console.Clear()
    End Sub
End Class
