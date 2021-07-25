''-----------------------------------------------------------------------
' <copyright file="Login.aspx.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'---------------------------------------------------------------------

''' ------------------------------------
''' Project  : EmployeeManager
''' Class  : Login
''' ------------------------------------ 
''' <summary>
''' Chứa các logic của chức năng Login
''' </summary>
''' <history>
'''  [HiepPV] 10/07/2021 Created
''' </history>
''' ------------------------------------
Public Class Login
    Inherits System.Web.UI.Page

    ''' ------------------------------------
    ''' <summary>
    ''' Hàm thực hiện các logic khi click button Login
    ''' </summary>
    ''' <param name="sender">Sender</param>
    ''' <param name="e">Event</param>
    ''' -----------------------------------
    Protected Sub Login_Click(sender As Object, e As EventArgs) Handles Login.Click
        Dim user = New UserEntity()
        Try
            'Lấy các giá tri từ màn hình
            user.UserName = userName.Text
            user.Password = password.Text
            'Validate
            Dim listErr As List(Of String) = Validation.validateLogin(user)
            'Mã hóa pass
            user.Password = Common.EncryptPass(password.Text)

            If listErr.Count <> 0 Then
                'Nếu có lỗi validate thì hiển thị lỗi
                Dim messageErr As String = ""
                For Each item In listErr
                    messageErr += item & vbCrLf
                Next
                Message.Text = messageErr
            Else
                'Nếu thông tin đăng nhập chính xác thì gán userName lên session và chuyển đến MH Home
                If LoginModels.checkLogin(user) Then
                    Session("UserName") = user.UserName
                    Response.Redirect("Home.aspx", False)
                Else
                    'Hiển thị message check login
                    Message.Text = Constants.LOGIN_FALSE
                End If
            End If
        Catch ex As Exception
            'Nếu có lỗi chương trình chuyển đến MH lỗi
            Response.Redirect("ErrorPage.aspx?message=" & ex.GetType().Name.ToString)
        End Try
    End Sub
End Class