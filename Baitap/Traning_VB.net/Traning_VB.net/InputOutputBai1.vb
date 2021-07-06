''-----------------------------------------------------------------------
' <copyright file="InputOutputBai1.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'---------------------------------------------------------------------
Imports System.IO
Imports System.Text.RegularExpressions

'''' ------------------------------------
''' Project  : Traning_VB.net
''' Class  : InputOutputBai1
''' ------------------------------------ 
''' <summary>
''' InputOutputBai1
''' </summary>
''' <history>
'''  [HiepPV] 06/07/2021 Created
''' </history>
''' ------------------------------------
Public Class InputOutputBai1

    '''' ------------------------------------
    ''' <summary>
    ''' Thực hiện đọc file và tính toán
    ''' </summary>
    ''' <param name="pathSource">Đường dẫn</param>
    ''' <param name="fileName">tên file</param>
    ''' -----------------------------------
    Public Sub ReadFile(ByVal pathSource As String, ByVal fileName As String)
        Dim path As String = pathSource & "\" & fileName
        If FileIO.FileSystem.FileExists(path) Then
            Try
                Dim totalLine As Integer
                Dim totalChar As Integer
                Dim totalWord As Integer
                Using sr As StreamReader = New StreamReader(path)
                    Dim line As String
                    line = sr.ReadLine()
                    While (line <> Nothing)
                        totalLine += 1
                        totalChar += GetNumberOfChar(line)
                        totalWord += GetNumberOfWord(line)
                        line = sr.ReadLine()
                    End While
                End Using
                Console.WriteLine("Số lượng dòng là: " & totalLine)
                Console.WriteLine("Số lượng kí tự là: " & totalChar)
                Console.WriteLine("Số lượng từ là: " & totalWord)
            Catch e As Exception
                Console.WriteLine("The file could not be read:")
                Console.WriteLine(e.Message)
            End Try
            Console.ReadKey()
        Else
            Console.WriteLine("File Không tồn tại!!!")
        End If
    End Sub

    '''' ------------------------------------
    ''' <summary>
    ''' Tính toán số kí tự
    ''' </summary>
    ''' <param name="str">Chuỗi cần kiểm tra</param>
    ''' <returns>Số kí tự trong chuỗi</returns>
    ''' -----------------------------------
    Private Function GetNumberOfChar(ByVal str As String) As Integer
        Return Regex.Replace(str, "\s", "").Length
    End Function

    '''' ------------------------------------
    ''' <summary>
    ''' Tính toán số từ
    ''' </summary>
    ''' <param name="str">Chuỗi cần kiểm tra</param>
    ''' <returns>Số từ trong chuỗi</returns>
    ''' -----------------------------------
    Private Function GetNumberOfWord(ByVal str As String) As Integer
        str = Regex.Replace(str.Trim, "\s+", " ")
        Return Regex.Split(str, "\s").Length
    End Function
End Class
