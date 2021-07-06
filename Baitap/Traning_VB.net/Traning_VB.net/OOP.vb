''-----------------------------------------------------------------------
' <copyright file="OOP.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'---------------------------------------------------------------------

'''' ------------------------------------
''' Project  : Traning_VB.net
''' Class  : B
''' ------------------------------------ 
''' <summary>
''' Class B
''' </summary>
''' <history>
'''  [HiepPV] 06/07/2021 Created
''' </history>
''' ------------------------------------
Public Class B
    Public B()
    '''' ------------------------------------
    ''' <summary>
    ''' In câu thông báo nhận diện class và hàm
    ''' </summary>
    ''' -----------------------------------
    Public Sub SM()
        Console.WriteLine(“Hello from B.SM().”)
    End Sub

    '''' ------------------------------------
    ''' <summary>
    ''' In câu thông báo nhận diện class và hàm
    ''' </summary>
    ''' -----------------------------------
    Public Overridable Sub VIM()
        Console.WriteLine(“Hello from B.VIM().”)
    End Sub

    '''' ------------------------------------
    ''' <summary>
    ''' In câu thông báo nhận diện class và hàm
    ''' </summary>
    ''' -----------------------------------
    Public Sub NIM()
        Console.WriteLine(“Hello from B.NIM().”)
    End Sub
End Class

'''' ------------------------------------
''' Project  : Traning_VB.net
''' Class  : C
''' ------------------------------------ 
''' <summary>
''' Class C kế thừa class B
''' </summary>
''' <history>
'''  [HiepPV] 06/07/2021 Created
''' </history>
''' ------------------------------------
Public Class C
    Inherits B

    '''' ------------------------------------
    ''' <summary>
    ''' In câu thông báo nhận diện class và hàm
    ''' </summary>
    ''' -----------------------------------
    Overrides Sub VIM()
        Console.WriteLine(“Hello from C.VIM().”)
    End Sub
End Class

'''' ------------------------------------
''' Project  : Traning_VB.net
''' Class  : OOP
''' ------------------------------------ 
''' <summary>
''' Thực hiện gọi ra các hàm của B và C
''' </summary>
''' <history>
'''  [HiepPV] 06/07/2021 Created
''' </history>
''' ------------------------------------
Public Class OOP
    Dim b = New B()
    Dim c = New C()

    '''' ------------------------------------
    ''' <summary>
    ''' Thực hiện gọi các hàm của B và C
    ''' </summary>
    ''' -----------------------------------
    Public Sub New()
        b.VIM()
        b.NIM()
        c.VIM()
        c.NIM()
    End Sub
End Class
