Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Login_Click(sender As Object, e As EventArgs) Handles Login.Click
        Dim user = New UserEntity()
        user.UserName = userName.Text
        user.Password = password.Text
        Dim listErr As List(Of String) = Validation.validateLogin(user)
        If listErr.Count <> 0 Then
            Dim messageErr As String
            For Each item In listErr
                messageErr += item & vbCrLf
            Next
            Message.Text = messageErr
        Else

        End If

    End Sub
End Class