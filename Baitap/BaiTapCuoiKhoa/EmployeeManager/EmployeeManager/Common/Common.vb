''-----------------------------------------------------------------------
' <copyright file="Common.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'---------------------------------------------------------------------
Imports System.Security.Cryptography

''' ------------------------------------
''' Project  : EmployeeManager
''' Class  : Common
''' ------------------------------------ 
''' <summary>
''' Class chứa các hàm dùng chung
''' </summary>
''' <history>
'''  [HiepPV] 10/07/2021 Created
''' </history>
''' ------------------------------------
Public Class Common
    ''' ------------------------------------
    ''' <summary>
    ''' Hàm mã hóa MD5
    ''' </summary>
    ''' <param name="input">String cần mã hóa</param>
    ''' <returns>Chuỗi đã được mã hóa</returns>
    ''' -----------------------------------
    Public Shared Function EncryptPass(input As String) As String
        Using hasher As MD5 = MD5.Create()    ' create hash object

            ' Convert to byte array and get hash
            Dim dbytes As Byte() =
             hasher.ComputeHash(Encoding.UTF8.GetBytes(input))

            ' sb to create string from bytes
            Dim sBuilder As New StringBuilder()

            ' convert byte data to hex string
            For n As Integer = 0 To dbytes.Length - 1
                sBuilder.Append(dbytes(n).ToString("X2"))
            Next n

            Return sBuilder.ToString()
        End Using
    End Function

    ''' ------------------------------------
    ''' <summary>
    ''' Lấy về chuỗi HTML chứa message validate để hiển thị message validate
    ''' </summary>
    ''' <param name="input">List message validate</param>
    ''' <returns>Đoạn mã HTML chứa các thông báo để hiển thị lỗi</returns>
    ''' -----------------------------------
    Public Shared Function GetErrorMessageValidate(input As List(Of String)) As String
        Dim message As New StringBuilder
        For Each item In input
            message.Append("<div class='alert alert-danger' role='alert'><strong>Error!</strong> " & item & "</div>")
        Next
        Return message.ToString
    End Function

    ''' ------------------------------------
    ''' <summary>
    ''' Lấy về chuỗi HTML chứa message validate khi import csv để hiển thị message
    ''' </summary>
    ''' <param name="input">List message validate</param>
    ''' <returns>Đoạn mã HTML chứa các thông báo để hiển thị lỗi</returns>
    ''' -----------------------------------
    Public Shared Function GetErrorMessageImportCsv(input As List(Of String)) As String
        Dim message As String = ""
        If input.Count <> 0 Then
            For Each item In input
                message += item & "; "
            Next
        End If
        If String.Empty.Equals(message) Then
            Return String.Empty
        Else
            Return "<div class='alert alert-danger' role='alert'><strong>Error!</strong> " & message & "</div>"
        End If
    End Function
End Class
