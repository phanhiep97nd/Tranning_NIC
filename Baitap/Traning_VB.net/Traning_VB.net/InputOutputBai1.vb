Imports System.IO
Imports System.Text.RegularExpressions

Public Class InputOutputBai1
    Public Sub ReadFile(ByVal pathSource As String, ByVal fileName As String)
        Dim path As String = pathSource & "\" & fileName
        If FileIO.FileSystem.FileExists(path) Then
            Try
                Dim totalLine As Integer
                Dim totalChar As Integer
                Dim totalWord As Integer
                Using sr As StreamReader = New StreamReader(path)
                    Dim line As String
                    line = sr.ReadLine()
                    While (line <> Nothing)
                        totalLine += 1
                        totalChar += GetNumberOfChar(line)
                        totalWord += GetNumberOfWord(line)
                        line = sr.ReadLine()
                    End While
                End Using
                Console.WriteLine("Số lượng dòng là: " & totalLine)
                Console.WriteLine("Số lượng kí tự là: " & totalChar)
                Console.WriteLine("Số lượng từ là: " & totalWord)
            Catch e As Exception
                Console.WriteLine("The file could not be read:")
                Console.WriteLine(e.Message)
            End Try
            Console.ReadKey()
        Else
            Console.WriteLine("File Không tồn tại!!!")
        End If
    End Sub
    Private Function GetNumberOfChar(ByVal str As String) As Integer
        'Console.WriteLine(Regex.Replace(str, "\s", ""))
        Return Regex.Replace(str, "\s", "").Length
    End Function
    Private Function GetNumberOfWord(ByVal str As String) As Integer
        str = Regex.Replace(str.Trim, "\s+", " ")
        Return Regex.Split(str, "\s").Length
    End Function
End Class
