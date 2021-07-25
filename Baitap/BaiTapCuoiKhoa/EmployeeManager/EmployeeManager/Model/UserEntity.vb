''-----------------------------------------------------------------------
' <copyright file="UserEntity.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'---------------------------------------------------------------------

''' ------------------------------------
''' Project  : EmployeeManager
''' Class  : UserEntity
''' ------------------------------------ 
''' <summary>
''' Class chứa đối tượng User
''' </summary>
''' <history>
'''  [HiepPV] 10/07/2021 Created
''' </history>
''' ------------------------------------
Public Class UserEntity
    Private _userId As Integer
    Private _userName As String
    Private _password As String
    Private _encryptPass As String

    Public Property UserId As Integer
        Get
            Return _userId
        End Get
        Set(value As Integer)
            _userId = value
        End Set
    End Property

    Public Property UserName As String
        Get
            Return _userName
        End Get
        Set(value As String)
            _userName = value
        End Set
    End Property

    Public Property Password As String
        Get
            Return _password
        End Get
        Set(value As String)
            _password = value
        End Set
    End Property

    Public Property EncryptPass As String
        Get
            Return _encryptPass
        End Get
        Set(value As String)
            _encryptPass = value
        End Set
    End Property
End Class
