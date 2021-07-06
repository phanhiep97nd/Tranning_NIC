''-----------------------------------------------------------------------
' <copyright file="MyException.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'---------------------------------------------------------------------

'''' ------------------------------------
''' Project  : Traning_VB.net
''' Class  : MyException
''' ------------------------------------ 
''' <summary>
''' Lớp Exception Custom
''' </summary>
''' <history>
'''  [HiepPV] 06/07/2021 Created
''' </history>
''' ------------------------------------
Public Class MyException
	Inherits System.ApplicationException

    '''' ------------------------------------
    ''' <summary>
    ''' In ra câu thông báo khi được gọi
    ''' </summary>
    ''' -----------------------------------
    Public Sub New()
		Console.WriteLine("Đã xảy ra lỗi!!!!!")
	End Sub
End Class
