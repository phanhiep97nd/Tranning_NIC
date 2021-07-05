Namespace MyNameSpaces
    Public Class FordMustang

    End Class
    Public Class FordIndigo

    End Class
    Public Class FordSaloom

    End Class
    Public Class McLarenF1

    End Class
    Public Class JaguarSaloon

    End Class
End Namespace
Public Class Namespaces
    Public Sub CopyArray()
        Dim array1() As Integer = {5, 7, 1, 3, 0, 9, 11}
        Console.Write("Mảng 1: ")
        Console.WriteLine("a" & array1.Length)
        For Each item In array1
            Console.Write(" " & item)
        Next
        Console.WriteLine("")
        Dim array2(6) As Integer
        Array.Copy(array1, array2, array1.Length)
        Console.WriteLine(">>>>> Thực hiện Copy....")
        Console.WriteLine("mảng 2: ")
        For Each item In array2
            Console.Write(" " & item)
        Next
        Console.WriteLine("")
    End Sub
End Class
