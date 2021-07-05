Public Class DelegateAndEventsBai1
    Public Shared arr(4) As Integer
    Public Sub SetValue()
        For i As Integer = 0 To arr.Length - 1
            Console.WriteLine("Mời bạn nhập phần tử thứ " & i + 1 & " : ")
            arr(i) = Console.ReadLine()
        Next
    End Sub
    Public Sub ShowValue()
        Console.Write("Giá trị của mảng sử dụng for: ")
        For i As Integer = 0 To arr.Length - 1
            Console.Write(arr(i) & " ")
        Next
        Console.WriteLine("")
        Console.Write("Giá trị của mảng sử dụng for Each: ")
        For Each item In arr
            Console.Write(item & " ")
        Next
        Console.WriteLine(vbCrLf & "Press Ok ....")
        Console.ReadLine()
    End Sub
End Class
