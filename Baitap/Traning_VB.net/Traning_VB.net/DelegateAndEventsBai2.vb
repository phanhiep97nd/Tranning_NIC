Public Class DelegateAndEventsBai2

End Class

Public Class ArrayDele
    Delegate Function ADel(ByVal arr() As Integer) As Integer()

    Private Function ArrayRev(ByVal arr() As Integer) As Integer()
        Array.Reverse(arr)
        Return arr
    End Function

    Private Function ArraySort(ByVal arr() As Integer) As Integer()
        Dim endIndex As Integer = arr.Length - 2
        For j As Integer = 0 To arr.Length - 1
            For i As Integer = 0 To endIndex
                Dim temp As Integer
                If arr(i) > arr(i + 1) Then
                    temp = arr(i + 1)
                    arr(i + 1) = arr(i)
                    arr(i) = temp
                End If
            Next
            endIndex -= 1
        Next
        Return arr
    End Function
    Public Function SetValueArray() As Integer()
        Dim arr(9) As Integer
        For i As Integer = 0 To arr.Length - 1
            Console.WriteLine("Nhập phần tử thứ {0} của mảng: ", i)
            arr(i) = Console.ReadLine()
        Next
        Return arr
    End Function
    Private Sub ShowArray(ByVal arr() As Integer)
        Console.WriteLine("Gía trị của mảng: ")
        For Each item In arr
            Console.Write(item & " ")
        Next
    End Sub

    Public Sub Main(ByVal arr() As Integer)
        Console.WriteLine("Mảng ban đầu:")
        ShowArray(arr)
        Console.WriteLine(vbCrLf & "%%%%%%%%%%%%")
        Dim aDel As ADel
        Console.WriteLine("Reverse:")
        aDel = AddressOf ArrayRev
        ShowArray(aDel.Invoke(arr))
        Console.WriteLine(vbCrLf & "%%%%%%%%%%%%")
        Console.WriteLine("Sort:")
        aDel = AddressOf ArraySort
        ShowArray(aDel.Invoke(arr))
        Console.WriteLine(vbCrLf & "%%%%%%%%%%%%")
    End Sub
End Class
