<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="formValidation.aspx.cs" Inherits="lab2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="username" runat="server">Имя</asp:TextBox>
            <asp:Label ID="Label1" runat="server" ForeColor="Maroon"></asp:Label>
        </div>
        <p>
            <asp:TextBox ID="password" runat="server" TextMode="SingleLine" placeholder="Пароль"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" ForeColor="Maroon"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="password_confirm" runat="server" TextMode="SingleLine" placeholder="Подтверждение пароля"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" ForeColor="Maroon"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="email" runat="server" >gnusin@ya.ru</asp:TextBox>
            <asp:Label ID="Label4" runat="server" ForeColor="Maroon"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="age" runat="server" TextMode="Number" placeholder="Возраст">18</asp:TextBox>
            <asp:Label ID="Label5" runat="server" ForeColor="Maroon"></asp:Label>
        </p>
        <asp:Button ID="submit" runat="server" OnClick="submit_Click" Text="Проверить" />
        <p>
            <asp:Label ID="result" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
