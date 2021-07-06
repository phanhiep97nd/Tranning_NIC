''-----------------------------------------------------------------------
' <copyright file="Example.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'---------------------------------------------------------------------

'''' ------------------------------------
''' Project  : Traning_VB.net
''' Class  : MyAnimals
''' ------------------------------------ 
''' <summary>
''' MyAnimals
''' </summary>
''' <history>
'''  [HiepPV] 06/07/2021 Created
''' </history>
''' ------------------------------------
Public Class MyAnimals
    Public Delegate Sub CheckCallHandler()
    Public Event CheckCall As CheckCallHandler
    Private BodyTemp As Integer

    Public Property BodyTemp1 As Integer
        Get
            RaiseEvent CheckCall()
            Return BodyTemp
        End Get
        Set(value As Integer)
            BodyTemp = value
        End Set
    End Property

    '''' ------------------------------------
    ''' <summary>
    ''' Hiển thị message
    ''' </summary>
    ''' -----------------------------------
    Private Sub ShowMessage()
        Console.WriteLine("Property của BodyTemp đã được gọi!!!!")
    End Sub

    '''' ------------------------------------
    ''' <summary>
    ''' Thực hiện chạy logic chính
    ''' </summary>
    ''' -----------------------------------
    Public Sub RunTest()
        AddHandler CheckCall, AddressOf ShowMessage
        Console.WriteLine("Nhập giá trị cho BodyTemp(số):")
        BodyTemp1 = Console.ReadLine()
        Console.WriteLine("Giá trị BodyTemp của MyAnimals vừa nhập là: " & BodyTemp1)
    End Sub
End Class