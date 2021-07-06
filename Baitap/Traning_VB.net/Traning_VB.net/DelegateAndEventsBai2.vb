''-----------------------------------------------------------------------
' <copyright file="DelegateAndEventsBai2.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'---------------------------------------------------------------------

'''' ------------------------------------
''' Project  : Traning_VB.net
''' Class  : ArrayDele
''' ------------------------------------ 
''' <summary>
''' ArrayDele
''' </summary>
''' <history>
'''  [HiepPV] 06/07/2021 Created
''' </history>
''' ------------------------------------
Public Class ArrayDele
    Delegate Function ADel(ByVal arr() As Integer) As Integer()

    '''' ------------------------------------
    ''' <summary>
    ''' Viết mô tả của hàm số là làm nhiệm vụ gì vào đây
    ''' </summary>
    ''' <param name="arr">mảng cần đảo ngược</param>
    ''' <returns>Mảng đã đảo ngược</returns>
    ''' -----------------------------------
    Private Function ArrayRev(ByVal arr() As Integer) As Integer()
        Array.Reverse(arr)
        Return arr
    End Function

    '''' ------------------------------------
    ''' <summary>
    ''' Thực hiện sắp xếp mảng
    ''' </summary>
    ''' <param name="arr">mảng cần sắp xếp</param>
    ''' <returns>mảng đã sắp xếp</returns>
    ''' -----------------------------------
    Private Function ArraySort(ByVal arr() As Integer) As Integer()
        Dim endIndex As Integer = arr.Length - 2
        For j As Integer = 0 To arr.Length - 1
            For i As Integer = 0 To endIndex
                Dim temp As Integer
                If arr(i) > arr(i + 1) Then
                    temp = arr(i + 1)
                    arr(i + 1) = arr(i)
                    arr(i) = temp
                End If
            Next
            endIndex -= 1
        Next
        Return arr
    End Function
    '''' ------------------------------------
    ''' <summary>
    ''' Gán giá trị cho mảng
    ''' </summary>
    ''' <returns>Mảng vừa được gán giá trị</returns>
    ''' -----------------------------------
    Public Function SetValueArray() As Integer()
        Dim arr(9) As Integer
        For i As Integer = 0 To arr.Length - 1
            Console.WriteLine("Nhập phần tử thứ {0} của mảng: ", i)
            arr(i) = Console.ReadLine()
        Next
        Return arr
    End Function

    '''' ------------------------------------
    ''' <summary>
    ''' Hiển thị mảng
    ''' </summary>
    ''' <param name="arr">Mảng cần hiển thị</param>
    ''' -----------------------------------
    Private Sub ShowArray(ByVal arr() As Integer)
        Console.WriteLine("Gía trị của mảng: ")
        For Each item In arr
            Console.Write(item & " ")
        Next
    End Sub

    '''' ------------------------------------
    ''' <summary>
    ''' thực hiện các logic chính
    ''' </summary>
    ''' <param name="arr">mảng cần thực thi</param>
    ''' -----------------------------------
    Public Sub Main(ByVal arr() As Integer)
        Console.WriteLine("Mảng ban đầu:")
        ShowArray(arr)
        Console.WriteLine(vbCrLf & "%%%%%%%%%%%%")
        Dim aDel As ADel
        Console.WriteLine("Reverse:")
        aDel = AddressOf ArrayRev
        ShowArray(aDel.Invoke(arr))
        Console.WriteLine(vbCrLf & "%%%%%%%%%%%%")
        Console.WriteLine("Sort:")
        aDel = AddressOf ArraySort
        ShowArray(aDel.Invoke(arr))
        Console.WriteLine(vbCrLf & "%%%%%%%%%%%%")
    End Sub
End Class
