Public Class Constants
    Public Const CONNECTION_STRING = "Data Source=PHANVANHIEP\SQLEXPRESS;Initial Catalog=TraningNIC;Integrated Security=SSPI;"
    Public Const VALIDATE_USERNAME_EMPTY = "Tên đăng nhập là bắt buộc!!"
    Public Const VALIDATE_PASS_EMPTY = "Mật khẩu là bắt buộc!!"
    Public Const LOGIN_FALSE = "Tài Khoản hoặc mật khẩu không chính xác!!"
    Public Const SCRIPT_ALERT = "<script> document.getElementById('codeAlert').innerHTML = '<div class='alert alert - success' role='alert'><strong>Success!</strong> You have been signed in successfully!</div>'; window.setTimeout(function () {$('.alert').fadeTo(500, 0).slideUp(500, function () {$(this).remove();});}, 2000);</script>"
End Class
