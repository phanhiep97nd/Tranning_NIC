Public Class Constants
    'Public Const CONNECTION_STRING = "Data Source=PHANVANHIEP\SQLEXPRESS;Initial Catalog=TraningNIC;Integrated Security=SSPI;"
    Public Const CONNECTION_STRING = "Data Source=DESKTOP-BOS8M2P\SQLEXPRESS;Initial Catalog=TRAINING_NIC;Integrated Security=SSPI;"
    Public Const VALIDATE_USERNAME_EMPTY = "UserName is Required!!"
    Public Const VALIDATE_PASS_EMPTY = "Password is Required!!"
    Public Const LOGIN_FALSE = "UserName Or Password is Incorrect!!"
    Public Const SCRIPT_ALERT = "<script> window.setTimeout(function () {$('.alert').fadeTo(500, 0).slideUp(500, function () {$(this).remove();});}, 2000);</script>"
    Public Const HTML_SUCCESS_EDIT = "<div class='alert alert-success' role='alert'><strong>Success!</strong> Edit Employee successfully!</div>"
    Public Const HTML_SUCCESS_DELETE = "<div class='alert alert-warning' role='alert'><strong>Success!</strong> Delete Employee successfully!</div>"
    Public Const VALIDATE_EMP_FULLNAME_EMPTY = "Full Name is Required!!"
    Public Const VALIDATE_EMP_FULLNAME_CHAR = "Full Name not match characters : a-zA-Z!!"
    Public Const VALIDATE_EMP_FULLNAME_MAXLENGTH = "Full Name longer 100 characters!!"
End Class
