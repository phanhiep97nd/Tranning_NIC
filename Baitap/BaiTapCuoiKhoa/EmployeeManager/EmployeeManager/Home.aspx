<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Home.aspx.vb" Inherits="EmployeeManager.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Home</title>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto|Varela+Round|Open+Sans" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <link rel="stylesheet" type="" href="../Style/Home.css" />
</head>
<body>
    <div ID="codeAlert" runat="server"></div>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="table-responsive">
                <div class="table-wrapper">
                    <div class="table-title">
                        <div class="row">
                            <div class="col-xs-5">
                                <h4 style="color: yellow"><b>
                                    <asp:Label ID="UserNameLabel" runat="server" Text=""></asp:Label></b>!</h4>
                            </div>
                            <%--<button type="button" style="color: red;" class="btn btn-danger">Log Out</button>--%>
                            <asp:Button ID="btnLogOut" runat="server" ForeColor="Red" Text="Log Out" OnClientClick="return confirm('Are you sure?');" CssClass="btn btn-danger" />
                        </div>
                        <hr>
                        <div class="row">
                            <div class="col-xs-5">
                                <h2>Employees <b>Management</b></h2>
                            </div>
                            <div class="col-xs-7">
                                <%--<a href="#" class="btn btn-primary" data-toggle="modal"
                                    data-target="#myModal"><i class="material-icons">&#xE147;</i> <span>Add New
                                    Employee</span></a>--%>
                                <asp:LinkButton ID="btnAddEmp" runat="server" CssClass="btn btn-primary" data-toggle="modal" data-target="#myModal"><i class="material-icons">&#xE147;</i> <span>Add New
                                    Employee</span></asp:LinkButton>
                                <%--<a href="#" class="btn btn-primary"><i class="material-icons">&#xe9a3;</i> <span>Import to
                                    CSV</span></a>--%>
                                <asp:LinkButton ID="btnImportCsv" runat="server" CssClass="btn btn-primary"><i class="material-icons">&#xe9a3;</i> <span>Import to
                                    CSV</span></asp:LinkButton>
                                <%--<a href="#" class="btn btn-primary"><i class="material-icons">&#xE24D;</i> <span>Export to
                                    CSV</span></a>--%>
                                <asp:LinkButton ID="btnExportCsv" runat="server" CssClass="btn btn-primary"><i class="material-icons">&#xE24D;</i> <span>Export to
                                    CSV</span></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-inline d-flex justify-content-center md-form form-sm active-cyan-2 mt-2">
                            <%--<input class="form-control form-control-sm mr-3 w-75" type="text" placeholder="Search Employee By Email"
                                aria-label="Search">--%>
                            <asp:TextBox ID="EmailSearch" runat="server" CssClass="form-control form-control-sm mr-3 w-75" placeholder="Search Employee By Email"></asp:TextBox>
                            <%--<button type="button" class="btn btn-primary">Search</button>--%>
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" />
                        </div>
                    </div>
                </div>

                <!-- Modal -->
                <div class="modal fade" id="myModal" role="dialog">
                    <div class="modal-dialog">

                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4 class="modal-title">Add New Employee</h4>
                                <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="modal-body">
                                <div class="form-group">
                                    <label for="exampleFormControlInput1">Full Name</label>
                                    <asp:TextBox ID="NewFullName" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="exampleFormControlInput1">Email address</label>
                                    <asp:TextBox ID="NewEmail" type="email" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="exampleFormControlInput1">Phone</label>
                                    <asp:TextBox ID="NewPhone" type="number" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="exampleFormControlInput1">Job Title</label>
                                    <asp:DropDownList ID="NewJobTitle" runat="server" Width="100%" Height="45px" Style="border-color: #cccccc">
                                        <asp:ListItem Value="">Please Select</asp:ListItem>
                                        <asp:ListItem Value="Designer">Designer</asp:ListItem>
                                        <asp:ListItem Value="Developer">Developer</asp:ListItem>
                                        <asp:ListItem Value="Tester">Tester</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="exampleFormControlInput1">Address</label>
                                    <asp:TextBox ID="NewAddress" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                <asp:Button ID="AddNewEmployee" runat="server" Text="Submit" CssClass="btn btn-primary" />
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
        <div style="padding: 15px">
            <h1>List Employees</h1>
            <br />
            <asp:GridView ID="GridView1" runat="server" Width="100%" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" AllowPaging="True" Style="margin-bottom: 0px" CellSpacing="5"
                OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" DataKeyNames="EMP_ID" CssClass="myGrv">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <%--<asp:BoundField DataField="FULL_NAME" HeaderText="Name" />
                    <asp:BoundField DataField="EMAIL" HeaderText="Email" />
                    <asp:BoundField DataField="PHONE" HeaderText="Phone Number" />
                    <asp:BoundField DataField="JOB_TITLE" HeaderText="Job Title" />
                    <asp:BoundField DataField="ADDRESS" HeaderText="Address" />
                    <asp:CommandField ShowEditButton="True" ButtonType="Button" />
                    <asp:CommandField ShowDeleteButton="True" ButtonType="Button"/>--%>
                    <asp:TemplateField HeaderText="Full Name">
                        <ItemTemplate>
                            <asp:Label ID="fullName" runat="server"
                                Text='<%# DataBinder.Eval(Container, "DataItem.[FULL_NAME]") %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="EditFullName" runat="server" CssClass="form-control" Text='<%# DataBinder.Eval(Container, "DataItem.[FULL_NAME]") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <asp:Label ID="email" runat="server"
                                Text='<%# DataBinder.Eval(Container, "DataItem.[EMAIL]") %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="EditEmail" runat="server" CssClass="form-control form-control-sm"
                                Text='<%# DataBinder.Eval(Container, "DataItem.[EMAIL]") %>' type="email"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Phone Number">
                        <ItemTemplate>
                            <asp:Label ID="phone" runat="server"
                                Text='<%# DataBinder.Eval(Container, "DataItem.[PHONE]") %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="EditPhone" runat="server" CssClass="form-control"
                                Text='<%# DataBinder.Eval(Container, "DataItem.[PHONE]") %>' type="number"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Job Title">
                        <ItemTemplate>
                            <asp:Label ID="jobTitle" runat="server"
                                Text='<%# DataBinder.Eval(Container, "DataItem.[JOB_TITLE]") %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="EditJobTitle" runat="server" Width="100%" Height="45px" Style="border-color: #cccccc" SelectedValue='<%# DataBinder.Eval(Container.DataItem, "JOB_TITLE") %>'>
                                <asp:ListItem Value="Designer">Designer</asp:ListItem>
                                <asp:ListItem Value="Developer">Developer</asp:ListItem>
                                <asp:ListItem Value="Tester">Tester</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Address">
                        <ItemTemplate>
                            <asp:Label ID="address" runat="server"
                                Text='<%# DataBinder.Eval(Container, "DataItem.[ADDRESS]") %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="EditAddress" runat="server" CssClass="form-control" Text='<%# DataBinder.Eval(Container, "DataItem.[ADDRESS]") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="EditButton"
                                runat="server"
                                CommandName="Edit"
                                Text="Edit" CssClass="btn btn-link btn-sm" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton ID="UpdateButton" ForeColor="#299be4"
                                runat="server"
                                CommandName="Update"
                                Text="Update" />&nbsp;
                            <asp:LinkButton ID="Cancel" ForeColor="#299be4"
                                runat="server"
                                CommandName="Cancel"
                                Text="Cancel" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="deletebtn" runat="server" CommandName="Delete" CssClass="btn btn-link btn-sm"
                                Text="Delete" OnClientClick="return confirm('Are you sure?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle HorizontalAlign="Left" BackColor="#ffcccc" />
                <FooterStyle BackColor="#299be4" ForeColor="White" Font-Bold="True" />
                <HeaderStyle BackColor="#299be4" Font-Size="Large" Height="50px" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                <PagerStyle BackColor="#299be4" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <br />
        </div>
        <div>
            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
