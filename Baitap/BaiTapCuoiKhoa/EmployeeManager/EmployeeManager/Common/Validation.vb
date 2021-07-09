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
End Class
