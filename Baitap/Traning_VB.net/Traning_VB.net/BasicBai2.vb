''-----------------------------------------------------------------------
' <copyright file="BasicBai2.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'---------------------------------------------------------------------

'''' ------------------------------------
''' Project  : Traning_VB.net
''' Class  : BasicBai2
''' ------------------------------------ 
''' <summary>
''' BasicBai2
''' </summary>
''' <history>
'''  [HiepPV] 06/07/2021 Created
''' </history>
''' ------------------------------------
Public Class BasicBai2

    '''' ------------------------------------
    ''' <summary>
    ''' Kiểm tra người dùng có nhập đúng Scrappy không
    ''' </summary>
    ''' -----------------------------------
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
