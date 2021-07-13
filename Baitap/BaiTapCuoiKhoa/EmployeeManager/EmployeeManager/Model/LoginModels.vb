Imports System.Data.SqlClient

Public Class LoginModels
    Public Shared Function checkLogin(user As UserEntity) As Boolean
        Dim result As Boolean
        Dim conn = New SqlConnection(Constants.CONNECTION_STRING)
        conn.Open()
        Try
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

        End Try
        Return result
    End Function
End Class
