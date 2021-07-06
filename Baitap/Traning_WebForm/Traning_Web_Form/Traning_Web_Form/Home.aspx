<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Home.aspx.vb" Inherits="Traning_Web_Form.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/Home.js" type="text/javascript"></script>
</head>
<body>
    <ul>
        <li><a runat="server" href="~/Login">Login</a></li>
        <li><a runat="server" href="~/Cart">View cart</a></li>
        <li><button onclick="registerClick()">Register</button></li>
    </ul>
</body>
</html>
