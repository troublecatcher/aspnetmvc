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
        </div>
        <p>
            <asp:TextBox ID="password" runat="server" TextMode="Password" >Пароль</asp:TextBox>
        </p>
        <p>
            <asp:TextBox ID="password_confirm" runat="server" TextMode="Password" >Подтверждение пароля</asp:TextBox>
        </p>
        <p>
            <asp:TextBox ID="email" runat="server" >gnusin@ya.ru</asp:TextBox>
        </p>
        <p>
            <asp:TextBox ID="age" runat="server" TextMode="Number">Возраст</asp:TextBox>
        </p>
        <asp:Button ID="submit" runat="server" OnClick="submit_Click" Text="Проверить" />
        <p>
            <asp:Label ID="result" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
