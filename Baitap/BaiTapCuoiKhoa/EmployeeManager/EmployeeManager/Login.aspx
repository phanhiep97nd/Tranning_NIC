<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="EmployeeManager.Login" %>


<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Login</title>
    <link rel="stylesheet" type="" href="../Style/Login.css">
    <style>
        #Message{
            color:red;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div class="login-box">
            <h1>Login   
                    <img src="../Image/logo.png"></h1>
            <div>
                <asp:Label ID="Message" runat="server" Text="" ></asp:Label>
            </div>
            <div class="textbox">
                <i class="fas fa-user"></i>
                <asp:TextBox ID="userName" placeholder="Tài Khoản" runat="server"></asp:TextBox>
            </div>

            <div class="textbox">
                <i class="fas fa-lock"></i>
                <asp:TextBox ID="password" TextMode="Password" placeholder="Mật khẩu" runat="server"></asp:TextBox>
            </div>

            <asp:Button ID="Login" CssClass="btn" runat="server" Text="Đăng nhập" />
        </div>
    </form>
</body>

</html>
