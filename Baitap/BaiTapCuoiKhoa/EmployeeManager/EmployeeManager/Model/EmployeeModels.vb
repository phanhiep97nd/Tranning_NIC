''-----------------------------------------------------------------------
' <copyright file="EmployeeModels.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'---------------------------------------------------------------------
Imports System.Data.SqlClient

''' ------------------------------------
''' Project  : EmployeeManager
''' Class  : EmployeeModels
''' ------------------------------------ 
''' <summary>
''' Chứa các hàm tháo tác với DB liên quan đến đối tượng Employee
''' </summary>
''' <history>
'''  [HiepPV] 10/07/2021 Created
''' </history>
''' ------------------------------------
Public Class EmployeeModels

    ''' ------------------------------------
    ''' <summary>
    ''' Thực hiện select Db lấy data để hiển thị gridview
    ''' </summary>
    ''' <returns>Dataset chưa giá trị vừa select từ DB</returns>
    ''' -----------------------------------
    Public Shared Function LoadData() As DataSet
        Dim conn = New SqlConnection(Constants.CONNECTION_STRING)
        Dim dtSet = New DataSet()
        Try
            conn.Open()

            Dim cmd = "Select * from EMPLOYEES ORDER BY EMP_ID DESC"
            Dim dataAdapter = New SqlDataAdapter(cmd, conn)

            dataAdapter.Fill(dtSet, "EMPLOYEES")
        Catch ex As Exception
            Throw ex
        Finally
            conn.Close()
        End Try
        Return dtSet
    End Function

    ''' ------------------------------------
    ''' <summary>
    ''' Thực hiện select Db search theo email lấy data để hiển thị gridview
    ''' </summary>
    ''' <param name="emailSearch">email dùng để search</param>
    ''' <returns>Dataset chưa giá trị vừa select từ DB</returns>
    ''' -----------------------------------
    Public Shared Function LoadData(ByVal emailSearch) As DataSet
        Dim conn = New SqlConnection(Constants.CONNECTION_STRING)
        Dim dtSet = New DataSet()
        Try
            conn.Open()
            Dim cmd = "Select * from EMPLOYEES WHERE EMAIL LIKE @email ORDER BY EMP_ID DESC"
            Dim dataAdapter = New SqlDataAdapter(cmd, conn)
            dataAdapter.SelectCommand.Parameters.AddWithValue("@email", "%" + emailSearch + "%")
            dataAdapter.Fill(dtSet, "EMPLOYEES")
        Catch ex As Exception
            Throw ex
        Finally
            conn.Close()
        End Try
        Return dtSet
    End Function

    '''' ------------------------------------
    ''' <summary>
    ''' Thực hiện update user trong DB
    ''' </summary>
    ''' <param name="employee">ĐỐi tượng user cần update</param>
    ''' <returns>true: Thành công; False: Thất bại</returns>
    ''' -----------------------------------
    Public Shared Function Update(ByVal employee As EmployeeEntity) As Boolean
        Dim result As Boolean
        Dim conn = New SqlConnection(Constants.CONNECTION_STRING)
        Try
            conn.Open()
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
            Dim cmd = New SqlCommand(sb.ToString(), conn)
            cmd.Parameters.Add("@fullName", SqlDbType.NVarChar).Value = employee.FullName
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = employee.Email
            cmd.Parameters.Add("@phone", SqlDbType.VarChar).Value = employee.Phone
            cmd.Parameters.Add("@jobTitle", SqlDbType.NVarChar).Value = employee.JobTitle
            cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = employee.Address
            cmd.Parameters.Add("@empId", SqlDbType.Int).Value = employee.EmpId

            If cmd.ExecuteNonQuery() <> 0 Then
                result = True
            Else
                result = False
            End If
        Catch ex As Exception
            result = False
            Throw ex
        Finally
            conn.Close()
        End Try
        Return result
    End Function

    '''' ------------------------------------
    ''' <summary>
    ''' Thực hiện xóa employee trong DB
    ''' </summary>
    ''' <param name="id">ID của employee cần xóa</param>
    ''' <returns>true: Thành công; False: Thất bại</returns>
    ''' -----------------------------------
    Public Shared Function Delete(ByVal id As Integer) As Boolean
        Dim conn = New SqlConnection(Constants.CONNECTION_STRING)
        Try
            conn.Open()
            Dim cmd = New SqlCommand("DELETE FROM EMPLOYEES WHERE EMP_ID = @id", conn)
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function

    '''' ------------------------------------
    ''' <summary>
    ''' Thực hiện thêm mới employee vào DB
    ''' </summary>
    ''' <param name="employee">employee cần thêm</param>
    ''' <returns>true: Thành công; False: Thất bại</returns>
    ''' -----------------------------------
    Public Shared Function AddEmployee(ByVal employee As EmployeeEntity) As Boolean
        Dim result As Boolean
        Dim conn = New SqlConnection(Constants.CONNECTION_STRING)
        Try
            conn.Open()
            Dim sb = New StringBuilder
            sb.Append("INSERT INTO EMPLOYEES(FULL_NAME, EMAIL, PHONE, JOB_TITLE, ADDRESS)")
            sb.Append(" VALUES")
            sb.Append(" (@fullName, @email, @phone, @jobTitle, @address)")
            Dim cmd = New SqlCommand(sb.ToString(), conn)
            cmd.Parameters.Add("@fullName", SqlDbType.NVarChar).Value = employee.FullName
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = employee.Email
            cmd.Parameters.Add("@phone", SqlDbType.VarChar).Value = employee.Phone
            cmd.Parameters.Add("@jobTitle", SqlDbType.NVarChar).Value = employee.JobTitle
            cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = employee.Address
            If cmd.ExecuteNonQuery() <> 0 Then
                result = True
            Else
                result = False
            End If
        Catch ex As Exception
            result = False
            Throw ex
        Finally
            conn.Close()
        End Try
        Return result
    End Function

    '''' ------------------------------------
    ''' <summary>
    ''' Thực hiện thêm mới employee vào DB có quản lí Transaction
    ''' </summary>
    ''' <param name="employee">employee cần thêm</param>
    ''' <param name="conn">Đối tượng SqlConnection</param>
    ''' <param name="sqlTransaction">Đối tượng SqlTransaction</param>
    ''' <returns>true: Thành công; False: Thất bại</returns>
    ''' -----------------------------------
    Public Shared Function AddEmployee(ByVal employee As EmployeeEntity, conn As SqlConnection, sqlTransaction As SqlTransaction) As Boolean
        Dim result As Boolean
        Try
            Dim sb = New StringBuilder
            sb.Append("INSERT INTO EMPLOYEES(FULL_NAME, EMAIL, PHONE, JOB_TITLE, ADDRESS)")
            sb.Append(" VALUES")
            sb.Append(" (@fullName, @email, @phone, @jobTitle, @address)")
            Dim cmd = New SqlCommand(sb.ToString(), conn, sqlTransaction)
            cmd.Parameters.Add("@fullName", SqlDbType.NVarChar).Value = employee.FullName
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = employee.Email
            cmd.Parameters.Add("@phone", SqlDbType.VarChar).Value = employee.Phone
            cmd.Parameters.Add("@jobTitle", SqlDbType.NVarChar).Value = employee.JobTitle
            cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = employee.Address
            If cmd.ExecuteNonQuery() <> 0 Then
                result = True
            Else
                result = False
            End If
        Catch ex As Exception
            result = False
            Throw ex
        End Try
        Return result
    End Function

    ''' ------------------------------------
    ''' <summary>
    ''' Kiểm tra email đã tồn tại trong DB chưa
    ''' </summary>
    ''' <param name="empId">Id của employee cần kiểm tra</param>
    ''' <param name="email">email cần kiểm tra</param>
    ''' <returns>true: Đã tồn tại; False: Chưa tồn tại</returns>
    ''' -----------------------------------
    Public Shared Function checkExistEmail(empId As Integer, email As String) As Boolean
        Dim result As Boolean
        Dim conn = New SqlConnection(Constants.CONNECTION_STRING)
        Try
            conn.Open()
            Dim sb = New StringBuilder
            sb.Append("SELECT * FROM EMPLOYEES")
            sb.Append(" WHERE")
            sb.Append(" EMP_ID <> @empId")
            sb.Append(" AND EMAIL = @email")
            Dim cmd = New SqlCommand(sb.ToString(), conn)
            cmd.Parameters.Add("@empId", SqlDbType.Int).Value = empId
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email
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

    ''' ------------------------------------
    ''' <summary>
    ''' Kiểm tra phone đã tồn tại trong DB chưa 
    ''' </summary>
    ''' <param name="empId">Id của employee cần kiểm tra</param>
    ''' <param name="phone">phone cần kiểm tra</param>
    ''' <returns>true: Đã tồn tại; False: Chưa tồn tại</returns>
    ''' -----------------------------------
    Public Shared Function checkExistPhone(empId As Integer, phone As String) As Boolean
        Dim result As Boolean
        Dim conn = New SqlConnection(Constants.CONNECTION_STRING)
        Try
            conn.Open()
            Dim sb = New StringBuilder
            sb.Append("SELECT * FROM EMPLOYEES")
            sb.Append(" WHERE")
            sb.Append(" EMP_ID <> @empId")
            sb.Append(" AND PHONE = @phone")
            Dim cmd = New SqlCommand(sb.ToString(), conn)
            cmd.Parameters.Add("@empId", SqlDbType.Int).Value = empId
            cmd.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone
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
