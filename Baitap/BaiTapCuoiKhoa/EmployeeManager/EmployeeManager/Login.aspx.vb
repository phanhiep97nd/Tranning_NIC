Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Login_Click(sender As Object, e As EventArgs) Handles Login.Click
        Dim user = New UserEntity()
        user.UserName = userName.Text
        user.Password = password.Text
        Dim listErr As List(Of String) = Validation.validateLogin(user)
        user.Password = Common.EncryptPass(password.Text)
        If listErr.Count <> 0 Then
            Dim messageErr As String = ""
            For Each item In listErr
                messageErr += item & vbCrLf
            Next
            Message.Text = messageErr
        Else
            If LoginModels.checkLogin(user) Then
                Session("UserName") = user.UserName
                Response.Redirect("Home.aspx")
            Else
                Message.Text = Constants.LOGIN_FALSE
            End If
        End If
    End Sub
End Class