Public Class Validation
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

    Public Shared Function validateEmployee(ByVal emp As EmployeeEntity) As List(Of String)
        Dim listErr = New List(Of String)
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
        Return listErr
    End Function
End Class
