Public Class Buy
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CardNo.Visible = False
        Label7.Visible = False
        ReqQuantity.Visible = False
        btnConfirm.Visible = False
        btnCancel.Visible = False
    End Sub

    Protected Sub btnBuy_Click(sender As Object, e As EventArgs) Handles btnBuy.Click
        CardNo.Visible = True
        Label7.Visible = True
        ReqQuantity.Visible = True
        btnConfirm.Visible = True
        btnCancel.Visible = True
    End Sub

    Protected Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Response.Redirect("Home.aspx")
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Message.Text = "Ban da cancel Credit Cart No"
    End Sub
End Class