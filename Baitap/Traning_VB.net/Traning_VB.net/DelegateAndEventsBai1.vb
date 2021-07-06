''-----------------------------------------------------------------------
' <copyright file="DelegateAndEventsBai1.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'---------------------------------------------------------------------

'''' ------------------------------------
''' Project  : Traning_VB.net
''' Class  : DelegateAndEventsBai1
''' ------------------------------------ 
''' <summary>
''' DelegateAndEventsBai1
''' </summary>
''' <history>
'''  [HiepPV] 06/07/2021 Created
''' </history>
''' ------------------------------------
Public Class DelegateAndEventsBai1
    Public Shared arr(4) As Integer

    '''' ------------------------------------
    ''' <summary>
    ''' Gán giá trị cho mảng
    ''' </summary>
    ''' -----------------------------------
    Public Sub SetValue()
        For i As Integer = 0 To arr.Length - 1
            Console.WriteLine("Mời bạn nhập phần tử thứ " & i + 1 & " : ")
            arr(i) = Console.ReadLine()
        Next
    End Sub

    '''' ------------------------------------
    ''' <summary>
    ''' hiển thị giá trị của mảng
    ''' </summary>
    ''' -----------------------------------
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
