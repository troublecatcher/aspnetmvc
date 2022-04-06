<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginPassing.aspx.cs" Inherits="lab2.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="username" runat="server">Логин</asp:TextBox>
        <div>
            <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <asp:Button ID="Button1" runat="server" Text="Передать" OnClick="Button1_Click" />
    </form>
</body>
</html>
