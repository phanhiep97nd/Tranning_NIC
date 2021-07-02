Imports System
Imports System.Net.Mime.MediaTypeNames

Module Program
    Sub Main(args As String())
        Dim isLoopMainMenu As Boolean
        Dim isLoopSubMenu As Boolean
        Do
            isLoopMainMenu = False
            Console.WriteLine("---Traning VB.Net-----")
            Console.WriteLine("Mời bạn chọn: ")
            Console.WriteLine("1.VB.Net Basic")
            Console.WriteLine("2.Lập trình hướng đối tượng và tính đa hình")
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
                    Dim oop = New OOP()
                Case "7"
                    Environment.Exit(0)
                Case Else
                    Console.WriteLine("Bạn chưa chọn đúng giá trị menu! Mời chọn lại!")
                    isLoopMainMenu = True
            End Select
        Loop While isLoopMainMenu
    End Sub
End Module
