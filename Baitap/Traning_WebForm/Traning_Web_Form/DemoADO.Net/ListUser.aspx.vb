''-----------------------------------------------------------------------
' <copyright file="ListUser.aspx.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'---------------------------------------------------------------------

'''' ------------------------------------
''' Project  : DemoADO
''' Class  : ListUser
''' ------------------------------------ 
''' <summary>
''' Thực hiện các logic cho màn hình List User
''' </summary>
''' <history>
'''  [HiepPV] 08/07/2021 Created
''' </history>
''' ------------------------------------
Public Class ListUser
    Inherits System.Web.UI.Page

    '''' ------------------------------------
    ''' <summary>
    ''' Hàm được gọi khi load trang
    ''' </summary>
    ''' <param name="sender">sender</param>
    ''' <param name="e">EventArgs</param>
    ''' -----------------------------------
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            gvbind()
        Else
        End If
    End Sub

    '''' ------------------------------------
    ''' <summary>
    ''' Hàm thực hiện đẩy dữ liệu cho DataGrid
    ''' </summary>
    ''' -----------------------------------
    Private Sub gvbind()
        Dim ds = New DataSet()
        ds = UserModel.LoadData()
        GridView1.DataSource = ds
        GridView1.DataBind()
    End Sub

    '''' ------------------------------------
    ''' <summary>
    ''' Hàm được gọi click button Edit của DataGrid
    ''' </summary>
    ''' <param name="sender">sender</param>
    ''' <param name="e">EventArgs</param>
    ''' -----------------------------------
    Protected Sub GridView1_RowEditing(sender As Object, e As GridViewEditEventArgs)
        GridView1.EditIndex = e.NewEditIndex
        gvbind()
        GridView1.Columns(4).Visible = False
    End Sub

    '''' ------------------------------------
    ''' <summary>
    ''' Hàm được gọi click button Cancel của DataGrid
    ''' </summary>
    ''' <param name="sender">sender</param>
    ''' <param name="e">EventArgs</param>
    ''' -----------------------------------
    Protected Sub GridView1_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        GridView1.EditIndex = -1
        gvbind()
        GridView1.Columns(4).Visible = True
    End Sub

    '''' ------------------------------------
    ''' <summary>
    ''' Hàm được gọi click button Delete của DataGrid
    ''' </summary>
    ''' <param name="sender">sender</param>
    ''' <param name="e">EventArgs</param>
    ''' -----------------------------------
    Protected Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Dim id As Integer = Integer.Parse(GridView1.DataKeys(e.RowIndex).Value.ToString())
        Dim row As GridViewRow = GridView1.Rows(e.RowIndex)
        Dim check = UserModel.Delete(id)
        If check Then
            Label1.Text = "Delete thành công!!"
        Else
            Label1.Text = "Delete thất bạn!!"
        End If
        gvbind()
    End Sub

    '''' ------------------------------------
    ''' <summary>
    ''' Hàm được gọi click button Update của DataGrid
    ''' </summary>
    ''' <param name="sender">sender</param>
    ''' <param name="e">EventArgs</param>
    ''' -----------------------------------
    Protected Sub GridView1_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        Label1.Text = "Update"
        Dim id As Integer = Integer.Parse(GridView1.DataKeys(e.RowIndex).Value.ToString())
        Dim row As GridViewRow = GridView1.Rows(e.RowIndex)
        Dim user = New User()
        user.Id = id
        Dim textBoxName As TextBox = row.Cells(0).Controls(0)
        user.Name = textBoxName.Text
        Dim textBoxBirthday As TextBox = row.Cells(1).Controls(0)
        user.Birthday = Date.Parse(textBoxBirthday.Text)
        Dim textBoxPlace As TextBox = row.Cells(2).Controls(0)
        user.Birthplace = textBoxPlace.Text
        GridView1.EditIndex = -1
        Dim check As Boolean = UserModel.Update(user)
        If check Then
            Label1.Text = "Update thành công!!"
        Else
            Label1.Text = "Update thất bạn!!"
        End If
        gvbind()
        GridView1.Columns(4).Visible = True
    End Sub
End Class