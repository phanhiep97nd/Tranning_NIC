''-----------------------------------------------------------------------
' <copyright file="Home.aspx.vb" company="Luvina">
' Copyright (c) Luvina Corporation. All rights reserved.
' </copyright>
'---------------------------------------------------------------------
Imports System.Data.SqlClient
Imports System.IO

''' ------------------------------------
''' Project  : EmployeeManager
''' Class  : Home
''' ------------------------------------ 
''' <summary>
''' Các logic tại màn hình Home
''' </summary>
''' <history>
'''  [HiepPV] 10/07/2021 Created
''' </history>
''' ------------------------------------
Public Class Home
    Inherits System.Web.UI.Page

    ''' ------------------------------------
    ''' <summary>
    ''' Hàm thực hiện logic khi load trang
    ''' </summary>
    ''' <param name="sender">Sender</param>
    ''' <param name="e">Event</param>
    ''' -----------------------------------
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                ViewState("emailToSearch") = String.Empty
                'Check trạng thái đã đăng nhập chưa
                If Session("UserName") IsNot Nothing Then
                    'Nếu đã đăng nhập thì hiển thị tên user và hiển thị list employee
                    UserNameLabel.Text = "Welcome " & Session("UserName")
                    gvbind()
                Else
                    'Nếu chưa đăng nhập thì về MH login
                    Response.Redirect("Login.aspx", False)
                End If
            Else
                'Clear các label hiển thị message trên màn hình
                codeAlert.InnerHtml = String.Empty
                errMessageAdd.InnerHtml = String.Empty
                MessageErrorImport.InnerHtml = String.Empty
            End If
        Catch ex As Exception
            Response.Redirect("ErrorPage.aspx?message=" & ex.GetType().Name.ToString)
        End Try
    End Sub

    ''' ------------------------------------
    ''' <summary>
    ''' Hàm thực hiện logic trước khi page được Render
    ''' </summary>
    ''' <param name="sender">Sender</param>
    ''' <param name="e">Event</param>
    ''' -----------------------------------
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        EmailSearch.Text = ViewState("emailToSearch").ToString
    End Sub

    '''' ------------------------------------
    ''' <summary>
    ''' Hàm thực hiện đẩy dữ liệu cho DataGrid
    ''' </summary>
    ''' -----------------------------------
    Private Sub gvbind()
        Dim ds = New DataSet()
        Try
            ds = EmployeeModels.LoadData()
            GridView1.DataSource = ds
            GridView1.DataBind()
        Catch ex As Exception
            Response.Redirect("ErrorPage.aspx?message=" & ex.GetType().Name.ToString)
        End Try
    End Sub

    ''' ------------------------------------
    ''' <summary>
    ''' Hàm thực hiện đẩy dữ liệu cho Gridview
    ''' </summary>
    ''' <param name="emailSearch">Chuỗi email dùng để search</param>
    ''' -----------------------------------
    Private Sub gvbind(ByVal emailSearch As String)
        Dim ds = New DataSet()
        Try
            ds = EmployeeModels.LoadData(emailSearch)
            GridView1.DataSource = ds
            GridView1.DataBind()
        Catch ex As Exception
            Response.Redirect("ErrorPage.aspx?message=" & ex.GetType().Name.ToString)
        End Try
    End Sub

    '''' ------------------------------------
    ''' <summary>
    ''' Hàm xử lí logic khi click button Edit của DataGrid
    ''' </summary>
    ''' <param name="sender">sender</param>
    ''' <param name="e">EventArgs</param>
    ''' -----------------------------------
    Protected Sub GridView1_RowEditing(sender As Object, e As GridViewEditEventArgs)
        GridView1.EditIndex = e.NewEditIndex
        gvbind(EmailSearch.Text)
        'Ẩn button delete
        GridView1.Columns(6).Visible = False
    End Sub

    '''' ------------------------------------
    ''' <summary>
    ''' Hàm xử lí logic khi click button Cancel của DataGrid
    ''' </summary>
    ''' <param name="sender">sender</param>
    ''' <param name="e">EventArgs</param>
    ''' -----------------------------------
    Protected Sub GridView1_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        GridView1.EditIndex = -1
        gvbind(EmailSearch.Text)
        'Hiện lại button delete
        GridView1.Columns(6).Visible = True
    End Sub

    '''' ------------------------------------
    ''' <summary>
    ''' Hàm thực hiện logic khi click button Update của DataGrid
    ''' </summary>
    ''' <param name="sender">sender</param>
    ''' <param name="e">EventArgs</param>
    ''' -----------------------------------
    Protected Sub GridView1_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        Try
            'Lấy các giá trị từ màn hình
            Dim id As Integer = Integer.Parse(GridView1.DataKeys(e.RowIndex).Value.ToString())
            Dim row As GridViewRow = GridView1.Rows(e.RowIndex)

            Dim employee = New EmployeeEntity()
            employee.EmpId = id

            Dim textBoxName As TextBox = row.FindControl("EditFullName")
            employee.FullName = textBoxName.Text

            Dim textBoxEmail As TextBox = row.FindControl("EditEmail")
            employee.Email = textBoxEmail.Text

            Dim textBoxPhone As TextBox = row.FindControl("EditPhone")
            employee.Phone = textBoxPhone.Text

            Dim selectBoxJobTitle As DropDownList = row.FindControl("EditJobTitle")
            employee.JobTitle = selectBoxJobTitle.SelectedValue

            Dim textBoxAddress As TextBox = row.FindControl("EditAddress")
            employee.Address = textBoxAddress.Text

            'Validate
            Dim listErr As List(Of String) = Validation.validateEmployee(employee)

            If listErr.Count = 0 Then
                'Thoát trạng thái edit
                GridView1.EditIndex = -1

                'Thực hiện update
                Dim check As Boolean = EmployeeModels.Update(employee)

                'Hiển thị thong báo tương ứng
                If check Then
                    codeAlert.InnerHtml = Constants.HTML_SUCCESS_EDIT
                    Response.Write(Constants.SCRIPT_ALERT_CLOSE)
                Else
                    codeAlert.InnerHtml = Constants.HTML_ERROR_EDIT
                End If

                gvbind(ViewState("emailToSearch").ToString)
                GridView1.Columns(6).Visible = True
            Else
                codeAlert.InnerHtml = Common.GetErrorMessageValidate(listErr)
            End If
        Catch ex As Exception
            Response.Redirect("ErrorPage.aspx?message=" & ex.GetType().Name.ToString)
        End Try
    End Sub

    '''' ------------------------------------
    ''' <summary>
    ''' Hàm thực hiện logic khi click button Delete của DataGrid
    ''' </summary>
    ''' <param name="sender">sender</param>
    ''' <param name="e">EventArgs</param>
    ''' -----------------------------------
    Protected Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Try
            Dim id As Integer = Integer.Parse(GridView1.DataKeys(e.RowIndex).Value.ToString())
            Dim row As GridViewRow = GridView1.Rows(e.RowIndex)

            'Thực hiện delete
            Dim check = EmployeeModels.Delete(id)

            If check Then
                codeAlert.InnerHtml = Constants.HTML_SUCCESS_DELETE
                Response.Write(Constants.SCRIPT_ALERT_CLOSE)
            Else
                codeAlert.InnerHtml = Constants.HTML_ERROR_DELETE
            End If

            gvbind(ViewState("emailToSearch").ToString)
        Catch ex As Exception
            Response.Redirect("ErrorPage.aspx?message=" & ex.GetType().Name.ToString)
        End Try
    End Sub

    '''' ------------------------------------
    ''' <summary>
    ''' Hàm xử lí logic khi click paging của gridview
    ''' </summary>
    ''' <param name="sender">sender</param>
    ''' <param name="e">EventArgs</param>
    ''' -----------------------------------
    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        gvbind(ViewState("emailToSearch").ToString)
    End Sub

    ''' ------------------------------------
    ''' <summary>
    ''' Hàm thực hiện clear giá trị các hạng mục
    ''' </summary>
    ''' -----------------------------------
    Private Sub ClearControls()
        NewFullName.Text = String.Empty
        NewEmail.Text = String.Empty
        NewPhone.Text = String.Empty
        NewJobTitle.SelectedValue = String.Empty
        NewAddress.Text = String.Empty
        EmailSearch.Text = String.Empty
        GridView1.PageIndex = 0
        ViewState("emailToSearch") = String.Empty
    End Sub

    ''' ------------------------------------
    ''' <summary>
    ''' Hàm thực hiện logic khi click button Search
    ''' </summary>
    ''' <param name="sender">sender</param>
    ''' <param name="e">EventArgs</param>
    ''' -----------------------------------
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        GridView1.PageIndex = 0
        Dim emailToSearch = EmailSearch.Text
        ViewState("emailToSearch") = emailToSearch
        gvbind(emailToSearch)
    End Sub

    ''' ------------------------------------
    ''' <summary>
    ''' Hàm thực hiện logic khi click button Submit trong popup Add New Employee
    ''' </summary>
    ''' <param name="sender">Sender</param>
    ''' <param name="e">Event</param>
    ''' -----------------------------------
    Protected Sub AddNewEmployee_Click(sender As Object, e As EventArgs) Handles AddNewEmployee.Click
        Dim emp As New EmployeeEntity
        Try
            'Lấy các giá trị từ màn hình
            emp.FullName = NewFullName.Text
            emp.Email = NewEmail.Text
            emp.Phone = NewPhone.Text
            emp.JobTitle = NewJobTitle.SelectedValue
            emp.Address = NewAddress.Text
            'Validate
            Dim listErr As List(Of String) = Validation.validateEmployee(emp)

            If listErr.Count = 0 Then
                'Nếu không có lỗi validate thì thực hiện add employee
                If EmployeeModels.AddEmployee(emp) Then
                    'Nếu Add employee thành công thì hiện thông báo
                    codeAlert.InnerHtml = Constants.HTML_SUCCESS_ADD
                    'Tự động ẩn câu thông báo
                    Response.Write(Constants.SCRIPT_ALERT_CLOSE)
                    'Clear giá trị câc hạng mục
                    ClearControls()
                Else
                    'Nếu không add employee thành công thì hiển thị thông báo
                    codeAlert.InnerHtml = Constants.HTML_ERROR_ADD
                End If
            Else
                'Nếu có message validate thì giữ popup add employee mở và thực hiện hiển thị message 
                ClientScript.RegisterStartupScript(Me.GetType(), "Popup", "$('#myModal').modal('show')", True)
                errMessageAdd.InnerHtml = Common.GetErrorMessageValidate(listErr)
            End If
            gvbind()
        Catch ex As Exception
            Response.Redirect("ErrorPage.aspx?message=" & ex.GetType().Name.ToString)
        End Try
    End Sub

    ''' ------------------------------------
    ''' <summary>
    ''' Hàm thực hiện logic khi click button Export Csv
    ''' </summary>
    ''' <param name="sender">sender</param>
    ''' <param name="e">EventArgs</param>
    ''' -----------------------------------
    Protected Sub btnExportCsv_Click(sender As Object, e As EventArgs) Handles btnExportCsv.Click
        Try
            'Thiết định các giá trị export
            Response.Clear()
            Response.Buffer = True
            Response.AddHeader("content-disposition", "attachment;filename=ListEmployeesCsv.csv")
            Response.Charset = "utf-8"
            Response.ContentType = "application/text"
            GridView1.AllowPaging = False
            'Bind dữ liệu để export
            Me.gvbind(ViewState("emailToSearch").ToString)
            Dim sbuilder As StringBuilder = New System.Text.StringBuilder()
            'Lấy giá trị header
            For index As Integer = 0 To GridView1.Columns.Count - 1
                sbuilder.Append(GridView1.Columns(index).HeaderText + ","c)
            Next
            sbuilder.Append(vbCr & vbLf)
            'Lấy giá trị các row
            For i As Integer = 0 To GridView1.Rows.Count - 1
                Dim lbFullName As Label = GridView1.Rows(i).FindControl("fullName")
                sbuilder.Append(lbFullName.Text.Replace(",", "") + ",")
                Dim lbEmail As Label = GridView1.Rows(i).FindControl("email")
                sbuilder.Append(lbEmail.Text.Replace(",", "") + ",")
                Dim lbPhone As Label = GridView1.Rows(i).FindControl("phone")
                sbuilder.Append(lbPhone.Text.Replace(",", "") + ",")
                Dim lbJobTitle As Label = GridView1.Rows(i).FindControl("jobTitle")
                sbuilder.Append(lbJobTitle.Text.Replace(",", "") + ",")
                Dim lbAddress As Label = GridView1.Rows(i).FindControl("address")
                sbuilder.Append(lbAddress.Text.Replace(",", "") + ",")
                sbuilder.Append(vbCr & vbLf)
            Next
            'Ghi dữ liệu ra file csv
            Response.Output.Write(sbuilder.ToString(), Encoding.UTF8)
            Response.Flush()
        Catch ex As Exception
            Response.Redirect("ErrorPage.aspx?message=" & ex.GetType().Name.ToString, False)
        Finally
            Response.[End]()
        End Try
    End Sub

    ''' ------------------------------------
    ''' <summary>
    ''' Hàm thực hiện logic khi click button Import trong popup Import CSV
    ''' </summary>
    ''' <param name="sender">sender</param>
    ''' <param name="e">EventArgs</param>
    ''' -----------------------------------
    Protected Sub Import_Click(sender As Object, e As EventArgs) Handles Import.Click
        Dim listEmployee As New List(Of EmployeeEntity)
        Dim lineCount As Integer = 1
        Dim ErrorImport As New StringBuilder
        Dim listEmailInCsv As New List(Of String)
        Dim listPhonelInCsv As New List(Of String)
        Try
            'Kiểm tra nếu tồn tại file
            If FileUpload.HasFile Then
                'Upload file và lưu file vào folder trong project
                Dim csvPath As String = Server.MapPath("~/Files/") + Path.GetFileName(FileUpload.PostedFile.FileName)
                FileUpload.SaveAs(csvPath)

                'Đọc file Csv 
                Dim csvData As String = File.ReadAllText(csvPath)

                'Duyệt từng dòng của file
                For Each row As String In csvData.Split(ControlChars.Lf)
                    'Kiểm tra không phải là dòng trống và khác dòng đầu(Header)
                    If (Not String.IsNullOrEmpty(row.Replace(","c, "").Replace(vbCr, ""))) And lineCount <> 1 Then
                        Dim employee As New EmployeeEntity
                        Dim listErrValidate As New List(Of String)

                        'Thực hiện gán các giá trị cho đối tượng employee từ file csv
                        employee.FullName = row.Split(","c)(0)

                        employee.Email = row.Split(","c)(1)
                        'Kiểm tra email đã được import trước đó từ file csv (Vì hàm validate chỉ kiểm tra tồn tại trong DB)
                        If listEmailInCsv.Contains(employee.Email) Then
                            listErrValidate.Add(Constants.VALIDATE_EMP_EMAIL_EXIST)
                        End If
                        listEmailInCsv.Add(employee.Email)

                        employee.Phone = row.Split(","c)(2)
                        'Kiểm tra phone đã được import trước đó từ file csv
                        If listPhonelInCsv.Contains(employee.Phone) Then
                            listErrValidate.Add(Constants.VALIDATE_EMP_PHONE_EXIST)
                        End If
                        listPhonelInCsv.Add(employee.Phone)

                        employee.JobTitle = row.Split(","c)(3)

                        employee.Address = row.Split(","c)(4).Replace(vbCr, "")

                        listEmployee.Add(employee)

                        'Validate các giá trị cho đối tượng employee
                        listErrValidate.AddRange(Validation.validateEmployee(employee))
                        'Convert list các Error Message validate thành 1 chuỗi
                        Dim messageValidateEmp = Common.GetErrorMessageImportCsv(listErrValidate)
                        'Nếu có lỗi thì add các lỗi validate từng employee vào message lỗi
                        If Not String.Empty.Equals(messageValidateEmp) Then
                            ErrorImport.Append("Line " & lineCount & ":" & messageValidateEmp)
                        End If
                    End If
                    'Số dòng
                    lineCount += 1
                Next

                'Kiểm tra nếu không có lỗi thì thực hiện commit transaction và hiển thị thông báo
                If String.Empty.Equals(ErrorImport.ToString) Then
                    For Each employee In listEmployee
                        EmployeeModels.AddEmployee(employee)
                    Next
                    codeAlert.InnerHtml = Constants.HTML_SUCCESS_IMPORT
                Else
                    'Nếu có lỗi thì hiển thị message lỗi
                    codeAlert.InnerHtml = ErrorImport.ToString
                End If
            Else
                'Nếu không import file thì giữ nguyên popup và hiển thị message lỗi
                ClientScript.RegisterStartupScript(Me.GetType(), "Popup", "$('#modalUpFile').modal('show')", True)
                MessageErrorImport.InnerHtml = Constants.HTML_ERROR_NOFILE
            End If
        Catch ex As Exception
            Response.Redirect("ErrorPage.aspx?message=" & ex.GetType().Name.ToString)
        Finally
            'Binding datagrid
            gvbind()
        End Try
    End Sub

    ''' ------------------------------------
    ''' <summary>
    ''' Hàm thực hiện logic khi click button Logout
    ''' </summary>
    ''' <param name="sender">Sender</param>
    ''' <param name="e">Event</param>
    ''' -----------------------------------
    Protected Sub btnLogOut_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        Session.Remove("UserName")
        Response.Redirect("Login.aspx")
    End Sub

End Class