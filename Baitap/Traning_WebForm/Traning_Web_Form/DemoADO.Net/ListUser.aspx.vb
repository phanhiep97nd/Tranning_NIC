Public Class ListUser
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ds = New DataSet()
        ds = UserModel.LoadData()
        GridView1.DataSource = ds
        GridView1.DataBind()
    End Sub

End Class