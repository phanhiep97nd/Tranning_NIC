''-----------------------------------------------------------------------
' <copyright file="ErrorPage.aspx.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'---------------------------------------------------------------------

''' ------------------------------------
''' Project  : EmployeeManager
''' Class  : IDBLayer
''' ------------------------------------ 
''' <summary>
''' Chưa code logic cho màn hình Error
''' </summary>
''' <history>
'''  [HiepPV] 10/07/2021 Created
''' </history>
''' ------------------------------------
Public Class ErrorPage
    Inherits System.Web.UI.Page

    ''' ------------------------------------
    ''' <summary>
    ''' Hàm thực hiện logic khi load trang
    ''' </summary>
    ''' <param name="sender">Sender</param>
    ''' <param name="e">Event</param>
    ''' -----------------------------------
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim message = Request.QueryString("message")
        MessageErr.Text = message
    End Sub

End Class