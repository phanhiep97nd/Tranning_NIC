Public Class Employee
    Private _empId As Integer
    Private _fullName As String
    Private _email As String
    Private _phone As Integer
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

    Public Property Phone As Integer
        Get
            Return _phone
        End Get
        Set(value As Integer)
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
End Class
