<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Buy.aspx.vb" Inherits="Traning_Web_Form.Buy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        /*.lable5{
            align-items:center;
            margin-bottom:auto;
            margin-top:auto;
        }*/
        div {
            margin: 10px;
            font-weight: bold;
        }
        .LableImage{
            margin-bottom:auto;
            margin-top:auto;
        }
        .btn{
            margin:15px;
        }
        .messageErr{
            color:red;
        }
    </style>
    <%--<script>
        function cancelClick() {
            console.log('a')
            document.getElementById("Message").innerHTML="ddd"
        }
    </script>--%>
</head>
<body style="margin-bottom: 0px">
    <form id="form1" runat="server" style="display: flex">
        <div>
            <div>
                <asp:Label ID="Label1" runat="server" Text="Item Code" Width="150px"></asp:Label>
                <asp:TextBox ID="ItemCode" runat="server" Height="18px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvitemCode" runat="server" 
                    ControlToValidate="ItemCode" ErrorMessage="Please Fill Item Code" CssClass="messageErr">
                </asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:Label ID="Label2" runat="server" Text="Item name" Width="150px"></asp:Label>
                <asp:TextBox ID="ItemName" runat="server" Height="18px" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="ItemName" ErrorMessage="Please Fill Item Name" CssClass="messageErr">
                </asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:Label ID="Label3" runat="server" Text="Quantity" Width="150px"></asp:Label>
                <asp:TextBox ID="Quantity" runat="server" Height="18px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="Quantity" ErrorMessage="Please Fill Quantity" CssClass="messageErr">
                </asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:Label ID="Label4" runat="server" Text="Price" Width="150px"></asp:Label>
                <asp:TextBox ID="Price" runat="server" Height="18px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="Price" ErrorMessage="Please Fill Price" CssClass="messageErr">
                </asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:Label CssClass="lable5" ID="Label5" runat="server" Text="Bid End Date" Width="150px"></asp:Label>
                <asp:Calendar ID="Calendar1" runat="server" Style="display: inline"></asp:Calendar>
            </div>
            <div>
                <asp:Label CssClass="LableImage" ID="Label6" runat="server" Text="Product Image" Width="150px"></asp:Label>
                <asp:Image ID="Image" ImageUrl="~/image/image.jpg" runat="server" />
            </div>
            <div>
                <asp:Label ID="Message" runat="server" Text="" Width="250px"></asp:Label>
            </div>
        </div>
        <div style="margin-left:200px" >
            <div style="text-align:center">Credit Card No</div>
            <div style="align-items:center">
                <asp:TextBox ID="CardNo" runat="server" Height="18px" Width="255px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="CardNo" ErrorMessage="Please Fill Card No" CssClass="messageErr">
                </asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:Label ID="Label7" runat="server" Text="Required quantity" Width="150px"></asp:Label>
                <asp:TextBox ID="ReqQuantity" runat="server" Height="18px" Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="ReqQuantity" ErrorMessage="Please Fill Required quantity" CssClass="messageErr">
                </asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:Button CssClass="btn" ID="btnConfirm" runat="server" Text="Confirm" />
                <asp:Button CssClass="btn" ID="btnCancel" runat="server" Text="Cancel" OnClientClick="cancelClick()"/>
            </div>
            <br />
            <div>
                <asp:Button ID="btnBuy" runat="server" Text="Buy" Height="50px" Width="80px"/>
            </div>
        </div>
    </form>
</body>
</html>
