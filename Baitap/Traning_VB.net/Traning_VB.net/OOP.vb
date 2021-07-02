Public Class B
    Public B()
    Public Sub SM()
        Console.WriteLine(“Hello from B.SM().”)
    End Sub
    Public Overridable Sub VIM()
        Console.WriteLine(“Hello from B.VIM().”)
    End Sub
    Public Sub NIM()
        Console.WriteLine(“Hello from B.NIM().”)
    End Sub
End Class
Public Class C
    Inherits B
    Overrides Sub VIM()
        Console.WriteLine(“Hello from C.VIM().”)
    End Sub
End Class

Public Class OOP
    Dim b = New B()
    Dim c = New C()
    Public Sub New()
        b.VIM()
        b.NIM()
        c.VIM()
        c.NIM()
    End Sub
End Class
