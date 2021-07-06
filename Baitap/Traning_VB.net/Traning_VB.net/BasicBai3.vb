''-----------------------------------------------------------------------
' <copyright file="BasicBai3.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'---------------------------------------------------------------------

'''' ------------------------------------
''' Project  : Traning_VB.net
''' Class  : BasicBai3
''' ------------------------------------ 
''' <summary>
''' BasicBai3
''' </summary>
''' <history>
'''  [HiepPV] 06/07/2021 Created
''' </history>
''' ------------------------------------
Public Class BasicBai3
    Private number1 As Integer
    Private number2 As Integer

    '''' ------------------------------------
    ''' <summary>
    ''' Lấy các giá trị cần thiết từ bán phím
    ''' </summary>
    ''' -----------------------------------
    Private Sub GetValue()
        Console.WriteLine("Mời bạn nhập số thứ nhất:")
        number1 = Console.ReadLine()
        Console.WriteLine("Mời bạn nhập số thứ hai:")
        number2 = Console.ReadLine()
    End Sub

    '''' ------------------------------------
    ''' <summary>
    ''' Thực hiện tính toán
    ''' </summary>
    ''' -----------------------------------
    Public Sub Calculate()
        GetValue()
        Dim isLoop As Boolean
        Do
            isLoop = False
            Console.WriteLine("Các chức năng:")
            Console.WriteLine("Add - Thực hiện cộng 2 giá trị integer và hiển thị kết quả")
            Console.WriteLine("Subtract - Thực hiện trừ 2 giá trị integer và hiển thị kết quả")
            Console.WriteLine("Multiply - Thực hiện nhân 2 giá trị integer và hiển thị kết quả")
            Console.WriteLine("Divide - Thực hiện chia 2 giá trị integer và hiển thị kết quả")
            Console.WriteLine("=> Mời bạn nhập chức năng: ")
            Dim choose As String
            choose = Console.ReadLine()
            Console.Clear()
            Console.WriteLine("Số thứ nhất: " & number1)
            Console.WriteLine("Số thứ hai: " & number2)
            Select Case choose
                Case "Add"
                    Console.WriteLine("Kết quả phép cộng hai số là: " & (number1 + number2))
                    Console.ReadLine()
                Case "Subtract"
                    Console.WriteLine("Kết quả phép trừ hai số là: " & (number1 - number2))
                    Console.ReadLine()
                Case "Multiply"
                    Console.WriteLine("Kết quả phép nhân hai số là: " & (number1 * number2))
                    Console.ReadLine()
                Case "Divide"
                    Console.WriteLine("Kết quả phép chia hai số là: " & (number1 \ number2))
                    Console.ReadLine()
                Case Else
                    Console.WriteLine("Chức năng bạn nhập không tồn tại! Mời nhập lại!")
                    isLoop = True
            End Select
        Loop While isLoop
    End Sub
End Class
