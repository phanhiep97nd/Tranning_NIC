''-----------------------------------------------------------------------
' <copyright file="BasicBai1.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'---------------------------------------------------------------------

'''' ------------------------------------
''' Project  : Traning_VB.net
''' Class  : BasicBai1
''' ------------------------------------ 
''' <summary>
''' BasicBai1
''' </summary>
''' <history>
'''  [HiepPV] 06/07/2021 Created
''' </history>
''' ------------------------------------
Public Class BasicBai1

    '''' ------------------------------------
    ''' <summary>
    ''' Hiển thị tên người dùng nhập vào
    ''' </summary>
    ''' -----------------------------------
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
