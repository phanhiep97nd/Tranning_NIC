Public Class DelegateAndEventsBai4

End Class
Public Class MyAnimals
    Public Delegate Sub CheckCallHandler()
    Public Event CheckCall As CheckCallHandler
    Private BodyTemp As Integer

    Public Property BodyTemp1 As Integer
        Get
            RaiseEvent CheckCall()
            Return BodyTemp
        End Get
        Set(value As Integer)
            BodyTemp = value
        End Set
    End Property
    Private Sub ShowMessage()
        Console.WriteLine("Property của BodyTemp đã được gọi!!!!")
    End Sub

    Public Sub RunTest()
        AddHandler CheckCall, AddressOf ShowMessage
        Console.WriteLine("Nhập giá trị cho BodyTemp(số):")
        BodyTemp1 = Console.ReadLine()
        Console.WriteLine("Giá trị BodyTemp của MyAnimals vừa nhập là: " & BodyTemp1)
    End Sub
End Class