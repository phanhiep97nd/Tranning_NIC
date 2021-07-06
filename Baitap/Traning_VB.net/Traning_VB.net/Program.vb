''-----------------------------------------------------------------------
' <copyright file="Program.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'---------------------------------------------------------------------
Imports System
Imports System.Net.Mime.MediaTypeNames

Module Program

    '''' ------------------------------------
    ''' <summary>
    ''' Hàm thực hiện việc chạy chương trình
    ''' </summary>
    ''' -----------------------------------
    Sub Main(args As String())
        Dim isLoopMainMenu As Boolean
        Dim isLoopSubMenu As Boolean
        Do
            isLoopMainMenu = True
            Console.WriteLine("---Traning VB.Net-----")
            Console.WriteLine("Mời bạn chọn: ")
            Console.WriteLine("1.VB.Net Basic")
            Console.WriteLine("2.Lập trình hướng đối tượng và tính đa hình")
            Console.WriteLine("3.Exception trong VB.Net")
            Console.WriteLine("4.NameSpaces")
            Console.WriteLine("5.Delegate và Events ")
            Console.WriteLine("6.Input/Output ")
            Console.WriteLine("7.Thoát chương trình!!")
            Dim userInputMainMenu As String
            userInputMainMenu = Console.ReadLine()
            Console.Clear()

            Select Case userInputMainMenu
                Case "1"
                    Console.WriteLine("----VB.Net Basic----")
                    Do
                        isLoopSubMenu = True
                        Console.WriteLine("Danh sách bài tập VB.Net Basic: ")
                        Console.WriteLine("1.Bài 1")
                        Console.WriteLine("2.Bài 2")
                        Console.WriteLine("3.Bài 3")
                        Console.WriteLine("4.Thoát về menu chính")
                        Console.WriteLine("Mời bạn chọn: ")
                        Dim choose As String
                        choose = Console.ReadLine()
                        Console.Clear()
                        Select Case choose
                            Case "1"
                                Console.WriteLine("---Bài 1: " & vbCrLf & " Viết 1 chương trình trình bằng VB.Net để thực hiện các việc sau:")
                                Console.WriteLine("	Hiển thị một thông báo yêu cầu người dùng nhập vào tên của mình. Khi nhập tên xong thì hiển thị tên đó lên trên màn hình.")
                                Console.WriteLine("*********")
                                Dim basicBai1 = New BasicBai1()
                                basicBai1.ShowName()
                            Case "2"
                                Console.WriteLine("---Bài 2")
                                Console.WriteLine(" Cho phép user nhập tên 15 lần." & vbCrLf & "+ Nếu tên nhập là Scrappy thì sẽ cho hiện thị là :" & vbCrLf & Chr(34) & "Scrappy was the name entered by the user." & Chr(34) & " Rồi thoát khỏi chương trình.")
                                Console.WriteLine("*********")
                                Dim basicBai2 = New BasicBai2()
                                basicBai2.CheckScrappy()
                            Case "3"
                                Console.WriteLine("---Bài 3")
                                Console.WriteLine("-	Nhận hai giá trị số nguyên và một chuỗi giá trị(hành động) từ người dùng. Tùy thuộc vào giá trị nhận được từ người sử dụng nhập vào là hành động gì thì sẽ xử lý cho từng hành động đó. ")
                                Dim basicBai3 = New BasicBai3()
                                basicBai3.Calculate()
                            Case "4"
                                isLoopSubMenu = False
                                isLoopMainMenu = True
                            Case Else
                                Console.WriteLine("Bạn chưa chọn đúng giá trị menu! Mời chọn lại!")
                        End Select
                    Loop While isLoopSubMenu
                Case "2"
                    Console.WriteLine("----Lập trình hướng đối tượng và tính đa hình----")
                    Console.WriteLine("Đề bài: " & vbCrLf & "-	Hãy tạo một lớp C là con của lớp B, có một method VIM viết override method VIM của lớp B.")
                    Console.WriteLine("-	Tạo một lớp khác (tên tùy ý) và viết đoạn mã khởi tạo đối tượng c của lớp C và b của lớp B, sau đó gọi như sau: b.VIM(), b.NIM(), c.VIM() và c.NIM. Giải thích kết quả.")
                    Console.WriteLine("******")
                    Dim oop = New OOP()
                Case "3"
                    Console.WriteLine("-----Exception trong VB.net---")
                    Console.WriteLine("Hãy viết một class ví dụ có sử dụng một Exception do bạn tự định nghĩa.")
                    Console.WriteLine("Trong đó Exception do bạn tự định nghĩa có tên là MyException, class root có tên là ExceptionDemo. ")
                    Console.WriteLine("Khi class root gặp bất kỳ Exception nào thì cũng được xử lý bởi MyException")
                    Console.WriteLine("******")
                    Try
                        Dim arr(3) As String
                        arr(4) = "a"
                        Console.WriteLine(arr(4))
                    Catch ex As Exception
                        Throw (New MyException())
                    End Try
                Case "4"
                    Console.WriteLine("----Namespaces---")
                    Console.WriteLine("-	Tạo ra 2 mảng: Tạo mảng 1 có 6 phần tử kiểu int. Mảng 2 cũng có 6 phần tử kiểu int. Copy nội dung của mảng 1 đến mảng 2. Chú ý sử dụng mehtod Array.Copy")
                    Dim nameSpaces = New Namespaces()
                    nameSpaces.CopyArray()
                Case "5"
                    Console.WriteLine("----Delegate And Events----")
                    Do
                        isLoopSubMenu = True
                        Console.WriteLine("Danh sách bài tập Delegate And Events: ")
                        Console.WriteLine("1.Bài 1")
                        Console.WriteLine("2.Bài 2")
                        Console.WriteLine("3.Bài 3")
                        Console.WriteLine("4.Bài 4")
                        Console.WriteLine("5.Thoát về menu chính")
                        Console.WriteLine("Mời bạn chọn: ")
                        Dim choose As String
                        choose = Console.ReadLine()
                        Console.Clear()
                        Select Case choose
                            Case "1"
                                Console.WriteLine("---Bài 1: " & vbCrLf & " Create a class with an array of integers, called Elements, as a member. The array should contain 5 elements. Create an indexer for this array. In the Main() funtion, do the following:")
                                Console.WriteLine("	a.	Accept the elements into the array the indexer.")
                                Console.WriteLine("	b.	Print the elements of the array by iterating through the array usung the indexer(also make use of the foreach loop).")
                                Console.WriteLine("*********")
                                Dim delagateAndEventsBai1 = New DelegateAndEventsBai1()
                                delagateAndEventsBai1.SetValue()
                                delagateAndEventsBai1.ShowValue()
                            Case "2"
                                Console.WriteLine("---Bài 2")
                                Console.WriteLine("*********")
                                Dim delagateAndEventsBai2 = New ArrayDele()
                                Dim arr As Integer()
                                arr = delagateAndEventsBai2.SetValueArray()
                                delagateAndEventsBai2.Main(arr)
                            Case "3"
                                Console.WriteLine("---Bài 3")
                                Console.WriteLine("Đề bài: Create event GotFive(). Accept 5 numbers from the user(using any of the loops). Id the user enters the number 5 then the event should be fired and the appropriate method called.")
                                Console.WriteLine("*********")
                                Dim delagateAndEventsBai3 = New DelegateAndEventsBai3()
                                delagateAndEventsBai3.RunTest()
                            Case "4"
                                Console.WriteLine("---Bài 4")
                                Console.WriteLine("Đề bài:Create a class called MyAnimals. The class MyAnimals should include a property called BodyTemp,  which is of type int. Create appropriate get/set accessors for the property. Also, ensure the property would be called when the GetBodyTemp method return a value.")
                                Console.WriteLine("*********")
                                Dim delagateAndEventsBai4 = New MyAnimals()
                                delagateAndEventsBai4.RunTest()
                            Case "5"
                                isLoopSubMenu = False
                                isLoopMainMenu = True
                            Case Else
                                Console.WriteLine("Bạn chưa chọn đúng giá trị menu! Mời chọn lại!")
                        End Select
                    Loop While isLoopSubMenu
                Case "6"
                    Console.WriteLine("----Input/Output ----")
                    Do
                        isLoopSubMenu = True
                        Console.WriteLine("Danh sách bài tập Input/Output: ")
                        Console.WriteLine("1.Bài 1")
                        Console.WriteLine("2.Bài 2")
                        Console.WriteLine("3.Bài 3")
                        Console.WriteLine("4.Thoát về menu chính")
                        Console.WriteLine("Mời bạn chọn: ")
                        Dim choose As String
                        choose = Console.ReadLine()
                        Console.Clear()
                        Select Case choose
                            Case "1"
                                Console.WriteLine("---Bài 1: " & vbCrLf & "Viết 1 chương trình thực hiện đọc nội dung 1 file văn bản sau đó in ra màn hình các thông tin sau")
                                Console.WriteLine("a.	Số lượng dòng.")
                                Console.WriteLine("b.	Số lượng kí tự.")
                                Console.WriteLine("c.	Số lượng từ.")
                                Console.WriteLine("*********")
                                Dim ioBai1 = New InputOutputBai1()
                                ioBai1.ReadFile("D:\prji_nic_vbnet\70_member\HiepPV\File_Test_Read_Write", "InputOutput_Bai1.txt")
                            Case "2"
                                Console.WriteLine("---Bài 2")
                                Console.WriteLine("Viết chương trình nhập vào tên một file nguồn và tên thư mục chứa file đích, hãy thực hiện")
                                Console.WriteLine("a.	Kiểm tra file nguồn có tồn tại không, nếu không tồn tại thoát khỏi chương trình.")
                                Console.WriteLine("b.	Nếu file nguồn đã tồn tại, kiểm tra thư mục đích đã tồn tại hay không, nếu chưa tồn tại, tạo mới thư mục này và copy file nguồn vào thư mục này.")
                                Console.WriteLine("*********")
                                Dim io2 = New InputOutputBai2()
                                io2.CopyFile()
                            Case "3"
                                Console.WriteLine("---Bài 3")
                                Console.WriteLine("Cho 1 đối tượng user bao gồm các thông tin sau: Username, age, address, score. Lập trình thực hiện:")
                                Console.WriteLine("a.	Hãy nhập một danh sách các user từ bàn phím và lưu danh sách user vào file.")
                                Console.WriteLine("b.	Đọc nội dung file vừa tạo, sắp xếp danh sách theo tên user và hiện thị ra màn hình.")
                                Console.WriteLine("c.	Tính tổng score của tất cả các user")
                                Console.WriteLine("*********")
                                Dim io3 = New InputOutputBai3()
                                io3.ShowMenu()
                            Case "4"
                                isLoopSubMenu = False
                                isLoopMainMenu = True
                            Case Else
                                Console.WriteLine("Bạn chưa chọn đúng giá trị menu! Mời chọn lại!")
                        End Select
                    Loop While isLoopSubMenu
                Case "7"
                    Environment.Exit(0)
                Case Else
                    Console.WriteLine("Bạn chưa chọn đúng giá trị menu! Mời chọn lại!")
            End Select
        Loop While isLoopMainMenu
    End Sub
End Module
