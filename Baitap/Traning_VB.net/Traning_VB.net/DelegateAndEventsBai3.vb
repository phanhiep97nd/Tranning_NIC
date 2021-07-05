Public Class DelegateAndEventsBai3
    Public Delegate Sub GotFiveHandler()
    Public Event GotFive As GotFiveHandler
    Private id As Integer


    Public Property Id1 As Integer
        Get
            Return id
        End Get
        Set(value As Integer)
            id = value
            If value = 5 Then RaiseEvent GotFive()
        End Set
    End Property

    Private Sub ActiveEvents()
        Console.WriteLine("@#$%^&")
        Console.WriteLine("Sự kiện được kích hoạt vì giá trị nhập bằng 5!!!!!!!")
        Console.WriteLine("@#$%^&")
    End Sub

    Public Sub RunTest()
        Dim events = New DelegateAndEventsBai3()
        AddHandler GotFive, AddressOf ActiveEvents
        For i As Integer = 1 To 5
            Console.WriteLine("Mời bạn nhập số lần {0}", i)
            Id1 = Console.ReadLine()
        Next
    End Sub
End Class
