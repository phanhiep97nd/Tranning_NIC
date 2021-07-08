<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ListUser.aspx.vb" Inherits="DemoADO.Net.ListUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>List User</h1>
            <br />
            <asp:GridView ID="GridView1" runat="server" Width="100%" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AllowPaging="True" Style="margin-bottom: 0px"
                OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" DataKeyNames="ID">
                <Columns>
                    <asp:BoundField DataField="NAME" HeaderText="Name" />
                    <asp:BoundField DataField="BIRTHDAY" HeaderText="Birthday" />
                    <asp:BoundField DataField="BIRTHPLACE" HeaderText="Birthplace" />
                    <%--<asp:CommandField ShowEditButton="True" ButtonType="Button" />--%>
                    <%--<asp:CommandField ShowDeleteButton="True" ButtonType="Button"/>--%>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="EditButton"
                                runat="server"
                                CommandName="Edit"
                                Text="Edit" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton ID="UpdateButton"
                                runat="server"
                                CommandName="Update"
                                Text="Update" />&nbsp;
                            <asp:LinkButton ID="Cancel"
                                runat="server"
                                CommandName="Cancel"
                                Text="Cancel" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="deletebtn" runat="server" CommandName="Delete"
                                Text="Delete" OnClientClick="return confirm('Are you sure?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle HorizontalAlign="Right" />
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>
            <br />
        </div>
        <div>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
