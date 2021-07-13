Public Class Home
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("UserName") IsNot Nothing Then
                UserNameLabel.Text = "Welcome " & Session("UserName")
                gvbind()
            Else
                Response.Redirect("Login.aspx")
            End If
        Else
            codeAlert.InnerHtml = ""
        End If
    End Sub

    Protected Sub btnLogOut_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        Session.Remove("UserName")
        Response.Redirect("Login.aspx")
    End Sub

    Protected Sub AddNewEmployee_Click(sender As Object, e As EventArgs) Handles AddNewEmployee.Click
        Label4.Text = "Tesst click submit!!"
        ClientScript.RegisterStartupScript(Me.GetType(), "Popup", "$('#myModal').modal('show')", True)
    End Sub

    '''' ------------------------------------
    ''' <summary>
    ''' Hàm thực hiện đẩy dữ liệu cho DataGrid
    ''' </summary>
    ''' -----------------------------------
    Private Sub gvbind()
        Dim ds = New DataSet()
        ds = EmployeeModels.LoadData()
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
        GridView1.Columns(6).Visible = False
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
        GridView1.Columns(6).Visible = True
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
        Dim check = EmployeeModels.Delete(id)
        If check Then
            codeAlert.InnerHtml = Constants.HTML_SUCCESS_DELETE
            Response.Write(Constants.SCRIPT_ALERT)
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
        Dim id As Integer = Integer.Parse(GridView1.DataKeys(e.RowIndex).Value.ToString())
        Dim row As GridViewRow = GridView1.Rows(e.RowIndex)
        Dim employee = New EmployeeEntity()
        employee.EmpId = id
        'Dim textBoxName As TextBox = row.Cells(0).Controls(0)
        Dim textBoxName As TextBox = row.FindControl("EditFullName")
        employee.FullName = textBoxName.Text
        'Dim textBoxEmail As TextBox = row.Cells(1).Controls(0)
        Dim textBoxEmail As TextBox = row.FindControl("EditEmail")
        employee.Email = textBoxEmail.Text
        'Dim textBoxPhone As TextBox = row.Cells(2).Controls(0)
        Dim textBoxPhone As TextBox = row.FindControl("EditPhone")
        employee.Phone = Integer.Parse(textBoxPhone.Text)
        'Dim textBoxJobTitle As TextBox = row.Cells(3).Controls(0)
        Dim selectBoxJobTitle As DropDownList = row.FindControl("EditJobTitle")
        employee.JobTitle = selectBoxJobTitle.SelectedValue
        'Dim textBoxAddress As TextBox = row.Cells(4).Controls(0)
        Dim textBoxAddress As TextBox = row.FindControl("EditAddress")
        employee.Address = textBoxAddress.Text
        Dim listErr As List(Of String) = Validation.validateEmployee(employee)
        If listErr.Count = 0 Then
            GridView1.EditIndex = -1
            Dim check As Boolean = EmployeeModels.Update(employee)
            If check Then
                codeAlert.InnerHtml = Constants.HTML_SUCCESS_EDIT
                Response.Write(Constants.SCRIPT_ALERT)
            End If
            gvbind()
            GridView1.Columns(6).Visible = True
        Else
            codeAlert.InnerHtml = Common.GetErrorMessageEdit(listErr)
        End If
    End Sub

    '''' ------------------------------------
    ''' <summary>
    ''' Hàm được gọi click button Edit của DataGrid
    ''' </summary>
    ''' <param name="sender">sender</param>
    ''' <param name="e">EventArgs</param>
    ''' -----------------------------------
    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        gvbind()
    End Sub

End Class