''-----------------------------------------------------------------------
' <copyright file="InputOutputBai3.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'---------------------------------------------------------------------
Imports System.IO


'''' ------------------------------------
''' Project  : Traning_VB.net
''' Class  : InputOutputBai3
''' ------------------------------------ 
''' <summary>
''' InputOutputBai3
''' </summary>
''' <history>
'''  [HiepPV] 06/07/2021 Created
''' </history>
''' ------------------------------------
Public Class InputOutputBai3
    Public Const PATH As String = "D:\prji_nic_vbnet\70_member\HiepPV\File_Test_Read_Write\ListUser.txt"

    '''' ------------------------------------
    ''' <summary>
    ''' Thực hiện hiện menu chính của bài và thực hiện các logic
    ''' </summary>
    ''' -----------------------------------
    Public Sub ShowMenu()
        Dim isLoopSubMenu As Boolean
        If Not FileIO.FileSystem.FileExists(PATH) Then
            Console.WriteLine("File Không tồn tại!!!")
            Console.ReadKey()
            Exit Sub
        End If
        Console.WriteLine("----List User ----")
        Do
            isLoopSubMenu = True
            Console.WriteLine("Các thao tác chính: ")
            Console.WriteLine("1.Thêm mới User")
            Console.WriteLine("2.Hiển thị danh sách User")
            Console.WriteLine("3.Tổng score các User")
            Console.WriteLine("4.Thoát về menu chính")
            Console.WriteLine("Mời bạn chọn: ")
            Dim choose As String
            choose = Console.ReadLine()
            Console.Clear()
            Select Case choose
                Case "1"
                    Console.WriteLine("---1.Thêm mới User")
                    Console.WriteLine("*********")
                    Dim user = New User
                    Console.WriteLine("Mời bạn nhập User Name:")
                    user.UserName = Console.ReadLine()
                    Console.WriteLine("Mời bạn nhập tuổi:")
                    user.Age = Integer.Parse(Console.ReadLine())
                    Console.WriteLine("Mời bạn nhập địa chỉ:")
                    user.Address = Console.ReadLine()
                    Console.WriteLine("Mời bạn nhập điểm số:")
                    user.Score = Decimal.Parse(Console.ReadLine())
                    AddUser(user)
                    Console.WriteLine(">> Thêm User thành công!!")
                Case "2"
                    Console.WriteLine("---2.Hiển thị danh sách User")
                    Console.WriteLine("*********")
                    Dim listUser = New List(Of User)
                    listUser = GetListUser()
                    For Each item In listUser
                        Console.WriteLine("Tên:{0}, Tuổi:{1}, Địa chỉ:{2}, Điểm:{3}", item.UserName, item.Age, item.Address, item.Score)
                    Next
                    Console.WriteLine("*********")
                Case "3"
                    Console.WriteLine("---3.Tổng score các User")
                    Console.WriteLine("*********")
                    Dim listUser = New List(Of User)
                    Dim totalScore As Decimal
                    listUser = GetListUser()
                    For Each item In listUser
                        totalScore += item.Score
                    Next
                    Console.WriteLine("Tổng Score của các user là: " & totalScore)
                    Console.WriteLine("*********")
                Case "4"
                    isLoopSubMenu = False
                Case Else
                    Console.WriteLine("Bạn chưa chọn đúng giá trị menu! Mời chọn lại!")
            End Select
        Loop While isLoopSubMenu
    End Sub

    '''' ------------------------------------
    ''' <summary>
    ''' Thực hiện thêm mới user
    ''' </summary>
    ''' <param name="user">user muốn thêm mới</param>
    ''' -----------------------------------
    Private Sub AddUser(user As User)
        Using sw As New StreamWriter(PATH, True)
            sw.WriteLine(user.UserName & "||" & user.Address & "||" & user.Age & "||" & user.Score)
        End Using
    End Sub

    '''' ------------------------------------
    ''' <summary>
    ''' Lấy ra danh sách user
    ''' </summary>
    ''' <returns>danh sách user</returns>
    ''' -----------------------------------
    Private Function GetListUser() As List(Of User)
        Dim listUser = New List(Of User)
        Using sr As StreamReader = New StreamReader(PATH)
            Dim line As String
            line = sr.ReadLine()
            While (line <> Nothing)
                Dim user = New User()
                user.UserName = line.Split("||")(0)
                user.Address = line.Split("||")(1)
                user.Age = Integer.Parse(line.Split("||")(2))
                user.Score = Decimal.Parse(line.Split("||")(3))
                listUser.Add(user)
                line = sr.ReadLine()
            End While
        End Using
        listUser.Sort(Function(x, y) x.UserName.CompareTo(y.UserName))
        Return listUser
    End Function
End Class

'''' ------------------------------------
''' Project  : Traning_VB.net
''' Class  : User
''' ------------------------------------ 
''' <summary>
''' Class User
''' </summary>
''' <history>
'''  [HiepPV] 06/07/2021 Created
''' </history>
''' ------------------------------------
Public Class User
    Private _userName As String
    Private _age As Integer
    Private _address As String
    Private _score As Decimal

    Public Property UserName As String
        Get
            Return _userName
        End Get
        Set(value As String)
            _userName = value
        End Set
    End Property

    Public Property Age As Integer
        Get
            Return _age
        End Get
        Set(value As Integer)
            _age = value
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

    Public Property Score As Decimal
        Get
            Return _score
        End Get
        Set(value As Decimal)
            _score = value
        End Set
    End Property
End Class
