Imports System.Data.SqlClient

Public Class EmployeeModels
    Public Shared Function LoadData() As DataSet
        Dim conn = New SqlConnection(Constants.CONNECTION_STRING)

        conn.Open()

        Dim cmd = "Select * from EMPLOYEES"
        Dim dataAdapter = New SqlDataAdapter(cmd, conn)

        Dim dtSet = New DataSet()

        dataAdapter.Fill(dtSet, "EMPLOYEES")

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
    Public Shared Function Update(ByVal employee As EmployeeEntity) As Boolean
        Dim result As Boolean
        Dim conn = New SqlConnection(Constants.CONNECTION_STRING)
        conn.Open()
        'Dim sqlTransaction As SqlTransaction = conn.BeginTransaction()
        Try
            Dim sb = New StringBuilder
            sb.Append("UPDATE EMPLOYEES")
            sb.Append(" SET")
            sb.Append(" FULL_NAME = @fullName")
            sb.Append(", EMAIL  = @email")
            sb.Append(", PHONE  = @phone")
            sb.Append(", JOB_TITLE  = @jobTitle")
            sb.Append(", ADDRESS  = @address")
            sb.Append(" WHERE")
            sb.Append(" EMP_ID = @empId")
            'Dim cmd = New SqlCommand(sb.ToString(), conn, sqlTransaction)
            Dim cmd = New SqlCommand(sb.ToString(), conn)
            cmd.Parameters.Add("@fullName", SqlDbType.NVarChar).Value = employee.FullName
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = employee.Email
            cmd.Parameters.Add("@phone", SqlDbType.Int).Value = employee.Phone
            cmd.Parameters.Add("@jobTitle", SqlDbType.NVarChar).Value = employee.JobTitle
            cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = employee.Address
            cmd.Parameters.Add("@empId", SqlDbType.Int).Value = employee.EmpId
            cmd.ExecuteNonQuery()
            'sqlTransaction.Commit()
            result = True
        Catch ex As Exception
            'sqlTransaction.Rollback()
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
        Dim conn = New SqlConnection(Constants.CONNECTION_STRING)
        conn.Open()
        Dim cmd = New SqlCommand("DELETE FROM EMPLOYEES WHERE EMP_ID = @id", conn)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = id
        Try
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
