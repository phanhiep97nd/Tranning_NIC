''-----------------------------------------------------------------------
' <copyright file="User.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'---------------------------------------------------------------------

'''' ------------------------------------
''' Project  : DemoADO
''' Class  : User
''' ------------------------------------ 
''' <summary>
''' Lớp chứa đối tượng User
''' </summary>
''' <history>
'''  [HiepPV] 08/07/2021 Created
''' </history>
''' ------------------------------------
Public Class User
    Private _id As Integer
    Private _name As String
    Private _birthday As Date
    Private _birthplace As String

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property Name As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

    Public Property Birthday As Date
        Get
            Return _birthday
        End Get
        Set(value As Date)
            _birthday = value
        End Set
    End Property

    Public Property Birthplace As String
        Get
            Return _birthplace
        End Get
        Set(value As String)
            _birthplace = value
        End Set
    End Property
End Class
