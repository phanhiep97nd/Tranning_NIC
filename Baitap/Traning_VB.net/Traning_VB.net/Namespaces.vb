''-----------------------------------------------------------------------
' <copyright file="Namespaces.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'---------------------------------------------------------------------

Namespace MyNameSpaces
    '''' ------------------------------------
    ''' Project  : Traning_VB.net
    ''' Class  : FordMustang
    ''' ------------------------------------ 
    ''' <summary>
    ''' FordMustang
    ''' </summary>
    ''' <history>
    '''  [HiepPV] 06/07/2021 Created
    ''' </history>
    ''' ------------------------------------
    Public Class FordMustang

    End Class

    '''' ------------------------------------
    ''' Project  : Traning_VB.net
    ''' Class  : FordIndigo
    ''' ------------------------------------ 
    ''' <summary>
    ''' FordIndigo
    ''' </summary>
    ''' <history>
    '''  [HiepPV] 06/07/2021 Created
    ''' </history>
    ''' ------------------------------------
    Public Class FordIndigo

    End Class

    '''' ------------------------------------
    ''' Project  : Traning_VB.net
    ''' Class  : FordSaloom
    ''' ------------------------------------ 
    ''' <summary>
    ''' FordSaloom
    ''' </summary>
    ''' <history>
    '''  [HiepPV] 06/07/2021 Created
    ''' </history>
    ''' ------------------------------------
    Public Class FordSaloom

    End Class

    '''' ------------------------------------
    ''' Project  : Traning_VB.net
    ''' Class  : McLarenF1
    ''' ------------------------------------ 
    ''' <summary>
    ''' McLarenF1
    ''' </summary>
    ''' <history>
    '''  [HiepPV] 06/07/2021 Created
    ''' </history>
    ''' ------------------------------------
    Public Class McLarenF1

    End Class

    '''' ------------------------------------
    ''' Project  : Traning_VB.net
    ''' Class  : JaguarSaloon
    ''' ------------------------------------ 
    ''' <summary>
    ''' JaguarSaloon
    ''' </summary>
    ''' <history>
    '''  [HiepPV] 06/07/2021 Created
    ''' </history>
    ''' ------------------------------------
    Public Class JaguarSaloon

    End Class
End Namespace

'''' ------------------------------------
''' Project  : Traning_VB.net
''' Class  : Namespaces
''' ------------------------------------ 
''' <summary>
''' Namespaces
''' </summary>
''' <history>
'''  [HiepPV] 06/07/2021 Created
''' </history>
''' ------------------------------------
Public Class Namespaces
    '''' ------------------------------------
    ''' <summary>
    ''' Thực hiện logic copy giá trị mảng
    ''' </summary>
    ''' -----------------------------------
    Public Sub CopyArray()
        Dim array1() As Integer = {5, 7, 1, 3, 0, 9, 11}
        Console.Write("Mảng 1: ")
        Console.WriteLine("a" & array1.Length)
        For Each item In array1
            Console.Write(" " & item)
        Next
        Console.WriteLine("")
        Dim array2(6) As Integer
        Array.Copy(array1, array2, array1.Length)
        Console.WriteLine(">>>>> Thực hiện Copy....")
        Console.WriteLine("mảng 2: ")
        For Each item In array2
            Console.Write(" " & item)
        Next
        Console.WriteLine("")
    End Sub
End Class
