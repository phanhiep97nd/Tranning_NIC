''-----------------------------------------------------------------------
' <copyright file="Validation.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'---------------------------------------------------------------------
Imports System.Data.SqlClient

''' ------------------------------------
''' Project  : EmployeeManager
''' Class  : Validation
''' ------------------------------------ 
''' <summary>
''' Class chứa các hàm dùng để validate
''' </summary>
''' <history>
'''  [HiepPV] 10/07/2021 Created
''' </history>
''' ------------------------------------
Public Class Validation

    ''' ------------------------------------
    ''' <summary>
    ''' Hàm thực hiện logic validate userName và passwork
    ''' </summary>
    ''' <param name="user">user cần kiểm tra</param>
    ''' <returns>List Message validate</returns>
    ''' -----------------------------------
    Public Shared Function validateLogin(ByVal user As UserEntity) As List(Of String)
        Dim listErr = New List(Of String)

        If String.Empty.Equals(user.UserName) Then
            listErr.Add(Constants.VALIDATE_USERNAME_EMPTY)
        End If

        If String.Empty.Equals(user.Password) Then
            listErr.Add(Constants.VALIDATE_PASS_EMPTY)
        End If

        Return listErr
    End Function

    ''' ------------------------------------
    ''' <summary>
    ''' Hàm thực hiện logic validate giá trị các thuộc tính của đối tượng Employee
    ''' </summary>
    ''' <param name="emp">Employee cần kiểm tra</param>
    ''' <returns>List Message validate</returns>
    ''' -----------------------------------
    Public Shared Function validateEmployee(ByVal emp As EmployeeEntity) As List(Of String)
        Dim listErr = New List(Of String)

        Try
            If String.Empty.Equals(emp.FullName) Then
                listErr.Add(Constants.VALIDATE_EMP_FULLNAME_EMPTY)
            Else
                If Not Regex.IsMatch(emp.FullName, "^[a-zA-Z ]*$") Then
                    listErr.Add(Constants.VALIDATE_EMP_FULLNAME_CHAR)
                End If
                If emp.FullName.Length > 100 Then
                    listErr.Add(Constants.VALIDATE_EMP_FULLNAME_MAXLENGTH)
                End If
            End If

            If String.Empty.Equals(emp.Email) Then
                listErr.Add(Constants.VALIDATE_EMP_EMAIL_EMPTY)
            Else
                If Not Regex.IsMatch(emp.Email, "^.+@[a-z0-9]{1,}\.[a-zA-Z]{1,}$") Then
                    listErr.Add(Constants.VALIDATE_EMP_EMAIL_FORMAT)
                Else
                    If EmployeeModels.checkExistEmail(emp.EmpId, emp.Email) Then
                        listErr.Add(Constants.VALIDATE_EMP_EMAIL_EXIST)
                    End If
                End If
            End If

            If String.Empty.Equals(emp.JobTitle) Then
                listErr.Add(Constants.VALIDATE_EMP_JOBTITLE_EMPTY)
            Else
                Dim listJob As String() = {"Designer", "Developer", "Tester"}
                If Not listJob.Contains(emp.JobTitle) Then
                    listErr.Add(Constants.VALIDATE_EMP_JOBTITLE_VALUE)
                End If
            End If

            If Not String.Empty.Equals(emp.Phone) Then
                Dim validatePhone As Boolean = True
                If emp.Phone.Length <> 10 Then
                    listErr.Add(Constants.VALIDATE_EMP_PHONE_LENGTH)
                    validatePhone = False
                End If
                If Not Regex.IsMatch(emp.Phone, "^[0-9]*$") Then
                    listErr.Add(Constants.VALIDATE_EMP_PHONE_CHAR)
                    validatePhone = False
                End If
                If validatePhone Then
                    If EmployeeModels.checkExistPhone(emp.EmpId, emp.Phone) Then
                        listErr.Add(Constants.VALIDATE_EMP_PHONE_EXIST)
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return listErr
    End Function

End Class
