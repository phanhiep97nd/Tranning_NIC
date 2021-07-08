''-----------------------------------------------------------------------
' <copyright file="Buy.aspx.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'---------------------------------------------------------------------

'''' ------------------------------------
''' Project  : BidAndBuy
''' Class  : Buy
''' ------------------------------------ 
''' <summary>
''' Buy
''' </summary>
''' <history>
'''  [HiepPV] 08/07/2021 Created
''' </history>
''' ------------------------------------
Public Class Buy
    Inherits System.Web.UI.Page

    '''' ------------------------------------
    ''' <summary>
    ''' Được gọi khi tải trang
    ''' </summary>
    ''' <param name="sender">sender</param>
    ''' <param name="e">EventArgs</param>
    ''' -----------------------------------
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CardNo.Visible = False
        Label7.Visible = False
        ReqQuantity.Visible = False
        btnConfirm.Visible = False
        btnCancel.Visible = False
    End Sub

    '''' ------------------------------------
    ''' <summary>
    ''' Hàm được gọi click button Buy
    ''' </summary>
    ''' <param name="sender">sender</param>
    ''' <param name="e">EventArgs</param>
    ''' -----------------------------------
    Protected Sub btnBuy_Click(sender As Object, e As EventArgs) Handles btnBuy.Click
        CardNo.Visible = True
        Label7.Visible = True
        ReqQuantity.Visible = True
        btnConfirm.Visible = True
        btnCancel.Visible = True
    End Sub

    '''' ------------------------------------
    ''' <summary>
    ''' Hàm được gọi click button Confirm
    ''' </summary>
    ''' <param name="sender">sender</param>
    ''' <param name="e">EventArgs</param>
    ''' -----------------------------------
    Protected Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Response.Redirect("Home.aspx")
    End Sub

    '''' ------------------------------------
    ''' <summary>
    ''' Hàm được gọi click button Cancel
    ''' </summary>
    ''' <param name="sender">sender</param>
    ''' <param name="e">EventArgs</param>
    ''' -----------------------------------
    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Message.Text = "Ban da cancel Credit Cart No"
    End Sub
End Class