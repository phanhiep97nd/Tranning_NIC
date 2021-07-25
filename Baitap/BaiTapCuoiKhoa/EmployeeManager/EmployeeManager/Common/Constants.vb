''-----------------------------------------------------------------------
' <copyright file="Constants.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'---------------------------------------------------------------------

''' ------------------------------------
''' Project  : EmployeeManager
''' Class  : Constants
''' ------------------------------------ 
''' <summary>
''' Class chứa các biến số Constant
''' </summary>
''' <history>
'''  [HiepPV] 10/07/2021 Created
''' </history>
''' ------------------------------------
Public Class Constants
    Public Const CONNECTION_STRING = "Data Source=PHANVANHIEP\SQLEXPRESS;Initial Catalog=TraningNIC;Integrated Security=SSPI;"

    'Message Validate Login
    Public Const VALIDATE_USERNAME_EMPTY = "UserName is Required!!"
    Public Const VALIDATE_PASS_EMPTY = "Password is Required!!"
    Public Const LOGIN_FALSE = "UserName Or Password is Incorrect!!"

    'Message thông báo
    Public Const SCRIPT_ALERT_CLOSE = "<script> window.setTimeout(function () {$('.alert').fadeTo(500, 0).slideUp(500, function () {$(this).remove();});}, 2000);</script>"
    Public Const HTML_SUCCESS_EDIT = "<div class='alert alert-success' role='alert'><strong>Success!</strong> Edit Employee successfully!</div>"
    Public Const HTML_SUCCESS_ADD = "<div class='alert alert-success' role='alert'><strong>Success!</strong> Add New Employee successfully!</div>"
    Public Const HTML_SUCCESS_DELETE = "<div class='alert alert-warning' role='alert'><strong>Success!</strong> Delete Employee successfully!</div>"
    Public Const HTML_ERROR_EDIT = "<div class='alert alert-danger' role='alert'><strong>NOT Success!</strong> Edit Employee Not successfully!</div>"
    Public Const HTML_ERROR_DELETE = "<div class='alert alert-danger' role='alert'><strong>NOT Success!</strong> Delete Employee Not successfully!</div>"
    Public Const HTML_ERROR_ADD = "<div class='alert alert-danger' role='alert'><strong>NOT Success!</strong> Add New Employee Not successfully!</div>"
    Public Const HTML_ERROR_NOFILE = "<div class='alert alert-danger' role='alert'><strong>ERROR!</strong> No File Choosen!</div>"
    Public Const HTML_SUCCESS_IMPORT = "<div class='alert alert-success' role='alert'><strong>Success!</strong> Import Employee From CSV successfully!</div>"

    'Message validate
    Public Const VALIDATE_EMP_FULLNAME_EMPTY = "[Full Name] is Required!!"
    Public Const VALIDATE_EMP_FULLNAME_CHAR = "[Full Name] not matching characters : a-zA-Z!!"
    Public Const VALIDATE_EMP_FULLNAME_MAXLENGTH = "[Full Name] longer 100 characters!!"
    Public Const VALIDATE_EMP_EMAIL_EMPTY = "[Email] is Required!!"
    Public Const VALIDATE_EMP_EMAIL_EXIST = "[Email] is already exist!!"
    Public Const VALIDATE_EMP_EMAIL_FORMAT = "[Email] not matching format abc@mail.com!!"
    Public Const VALIDATE_EMP_JOBTITLE_EMPTY = "[Job Title] is Required!!"
    Public Const VALIDATE_EMP_JOBTITLE_VALUE = "[Job Title] must be in ['Designer', 'Developer', 'Tester']!!"
    Public Const VALIDATE_EMP_PHONE_EXIST = "[Phone number] is already exist!!"
    Public Const VALIDATE_EMP_PHONE_CHAR = "[Phone number] not matching characters : 0-9!!"
    Public Const VALIDATE_EMP_PHONE_LENGTH = "[Phone number] fixed length: 10!!"
End Class
