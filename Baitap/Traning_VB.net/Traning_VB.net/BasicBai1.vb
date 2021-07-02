Public Class BasicBai1
    Public Sub ShowName()
        Console.WriteLine("Hãy nhập tên của bạn: ")
        Dim userInput As String
        userInput = Console.ReadLine()
        Console.Clear()
        Console.WriteLine("Tên của bạn là: " & userInput)
        Console.WriteLine("......Press OK để tiếp tục!!")
        Console.ReadLine()
    End Sub
End Class
