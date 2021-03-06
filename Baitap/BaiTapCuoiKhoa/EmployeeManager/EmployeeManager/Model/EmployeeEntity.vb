''-----------------------------------------------------------------------
' <copyright file="EmployeeEntity.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'---------------------------------------------------------------------

''' ------------------------------------
''' Project  : EmployeeManager
''' Class  : EmployeeEntity
''' ------------------------------------ 
''' <summary>
''' Class chứa đối tượng Employee
''' </summary>
''' <history>
'''  [HiepPV] 10/07/2021 Created
''' </history>
''' ------------------------------------
Public Class EmployeeEntity
    Private _empId As Integer
    Private _fullName As String
    Private _email As String
    Private _phone As String
    Private _jobTitle As String
    Private _address As String

    Public Property EmpId As Integer
        Get
            Return _empId
        End Get
        Set(value As Integer)
            _empId = value
        End Set
    End Property

    Public Property FullName As String
        Get
            Return _fullName
        End Get
        Set(value As String)
            _fullName = value
        End Set
    End Property

    Public Property Email As String
        Get
            Return _email
        End Get
        Set(value As String)
            _email = value
        End Set
    End Property

    Public Property Phone As String
        Get
            Return _phone
        End Get
        Set(value As String)
            _phone = value
        End Set
    End Property

    Public Property Address As String
        Get
            Return _address
        End Get
        Set(value As String)
            _address = value
        End Set
    End Property

    Public Property JobTitle As String
        Get
            Return _jobTitle
        End Get
        Set(value As String)
            _jobTitle = value
        End Set
    End Property
End Class
