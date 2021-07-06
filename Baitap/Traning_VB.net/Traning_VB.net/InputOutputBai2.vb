''-----------------------------------------------------------------------
' <copyright file="InputOutputBai2.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'---------------------------------------------------------------------
Imports System.IO

'''' ------------------------------------
''' Project  : Traning_VB.net
''' Class  : InputOutputBai2
''' ------------------------------------ 
''' <summary>
''' InputOutputBai2
''' </summary>
''' <history>
'''  [HiepPV] 06/07/2021 Created
''' </history>
''' ------------------------------------
Public Class InputOutputBai2

    '''' ------------------------------------
    ''' <summary>
    ''' Thực hiện copy file
    ''' </summary>
    ''' -----------------------------------
    Public Sub CopyFile()
        Dim path As String = "D:\prji_nic_vbnet\70_member\HiepPV\File_Test_Read_Write\"
        Dim fileName As String
        Dim folderName As String
        Console.WriteLine("Mời nhập tên file nguồn: ")
        fileName = Console.ReadLine()
        Console.WriteLine("Mời nhập tên thư mục chứa file đích: ")
        folderName = Console.ReadLine()
        If FileIO.FileSystem.FileExists(path & fileName) Then
            Try
                If Not System.IO.Directory.Exists(path & folderName) Then
                    System.IO.Directory.CreateDirectory(path & folderName)
                End If
                FileIO.FileSystem.CopyFile(path & fileName, path & folderName & "\" & fileName, True)
                Console.WriteLine(">>>Copy file đã hoàn tất!!")
            Catch e As Exception
                Console.WriteLine("The file could not be read:")
                Console.WriteLine(e.Message)
            End Try
            Console.ReadKey()
        Else
            Console.WriteLine("File Không tồn tại!!!")
            Console.ReadKey()
            Exit Sub
        End If
    End Sub
End Class
