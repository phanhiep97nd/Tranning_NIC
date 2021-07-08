''-----------------------------------------------------------------------
' <copyright file="UserModel.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'---------------------------------------------------------------------
Imports System.Data.SqlClient

'''' ------------------------------------
''' Project  : DemoADO
''' Class  : UserModel
''' ------------------------------------ 
''' <summary>
''' Lớp chứa các hàm liên quan đến thao tác với DB
''' </summary>
''' <history>
'''  [HiepPV] 08/07/2021 Created
''' </history>
''' ------------------------------------
Public Class UserModel
    Const CONNECTION_STRING As String = "Data Source=PHANVANHIEP\SQLEXPRESS;Initial Catalog=TraningNIC;Integrated Security=SSPI;"

    '''' ------------------------------------
    ''' <summary>
    ''' Thực hiện lấy ra các user trong Db
    ''' </summary>
    ''' <returns>DataSet chứa tất cả các bản ghi</returns>
    ''' -----------------------------------
    Public Shared Function LoadData() As DataSet
        Dim conn = New SqlConnection(CONNECTION_STRING)

        conn.Open()

        Dim cmd = "Select * from DEMO_ADO"
        Dim dataAdapter = New SqlDataAdapter(cmd, conn)

        Dim dtSet = New DataSet()

        dataAdapter.Fill(dtSet, "DEMO_ADO")

        conn.Close()

        Return dtSet
    End Function

    '''' ------------------------------------
    ''' <summary>
    ''' Thực hiện update user trong DB
    ''' </summary>
    ''' <param name="user">ĐỐi tượng user cần update</param>
    ''' <returns>true: Thành công; False: Thất bại</returns>
    ''' -----------------------------------
    Public Shared Function Update(ByVal user As User) As Boolean
        Dim result As Boolean
        Dim conn = New SqlConnection(CONNECTION_STRING)
        conn.Open()
        Dim sqlTransaction As SqlTransaction = conn.BeginTransaction()
        Try
            Dim sb = New StringBuilder
            sb.Append("UPDATE DEMO_ADO")
            sb.Append(" SET")
            sb.Append(" NAME = @name")
            sb.Append(", BIRTHDAY  = @birthday")
            sb.Append(", BIRTHPLACE  = @birthplace")
            sb.Append(" WHERE")
            sb.Append(" ID = @id")
            Dim cmd = New SqlCommand(sb.ToString(), conn, sqlTransaction)
            'Dim cmd = New SqlCommand(sb.ToString(), conn)
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = user.Name
            cmd.Parameters.Add("@birthday", SqlDbType.DateTime).Value = user.Birthday
            cmd.Parameters.Add("@birthplace", SqlDbType.VarChar).Value = user.Birthplace
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = user.Id
            cmd.ExecuteNonQuery()
            sqlTransaction.Commit()
            result = True
        Catch ex As Exception
            sqlTransaction.Rollback()
            result = False
        Finally
            conn.Close()
        End Try
        Return result
    End Function

    '''' ------------------------------------
    ''' <summary>
    ''' Thực hiện xóa user trong DB
    ''' </summary>
    ''' <param name="id">ID của User cần xóa</param>
    ''' <returns>true: Thành công; False: Thất bại</returns>
    ''' -----------------------------------
    Public Shared Function Delete(ByVal id As Integer) As Boolean
        Dim conn = New SqlConnection(CONNECTION_STRING)
        conn.Open()
        Dim cmd = New SqlCommand("DELETE FROM DEMO_ADO WHERE ID = @id", conn)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = id
        Try
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
