''-----------------------------------------------------------------------
' <copyright file="LoginModels.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'---------------------------------------------------------------------
Imports System.Data.SqlClient

''' ------------------------------------
''' Project  : EmployeeManager
''' Class  : LoginModels
''' ------------------------------------ 
''' <summary>
''' Chứa các hàm thao tác với DB cho chức năng login
''' </summary>
''' <history>
'''  [HiepPV] 10/07/2021 Created
''' </history>
''' ------------------------------------
Public Class LoginModels

    ''' ------------------------------------
    ''' <summary>
    ''' Hàm thực hiện thao tác với DB để kiểm tra userName và password có trùng khớp
    ''' </summary>
    ''' <param name="user">Đối tượng user cần kiểm tra</param>
    ''' <returns>True: Thông tin login trùng khớp; Otherwise: Thông tin login không trùng khớp</returns>
    ''' -----------------------------------
    Public Shared Function checkLogin(user As UserEntity) As Boolean
        Dim result As Boolean
        Dim conn = New SqlConnection(Constants.CONNECTION_STRING)
        Try
            conn.Open()
            Dim sb = New StringBuilder
            sb.Append("SELECT [PASSWORD] FROM USER_INFO")
            sb.Append(" WHERE")
            sb.Append(" USER_NAME = @userName")
            sb.Append(" AND PASSWORD = @pass")
            Dim cmd = New SqlCommand(sb.ToString(), conn)
            cmd.Parameters.Add("@userName", SqlDbType.VarChar).Value = user.UserName
            cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = user.Password

            Dim reader As SqlDataReader = cmd.ExecuteReader()

            If reader.HasRows Then
                result = True
            Else
                result = False
            End If
        Catch ex As Exception
            Throw ex
        Finally
            conn.Close()
        End Try
        Return result
    End Function
End Class
