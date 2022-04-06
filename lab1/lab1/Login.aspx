<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="lab1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style2 {
            height: 26px;
        }
        .auto-style3 {
            text-align: center;
            font-size: xx-large;
        }
        .auto-style4 {
            text-align: right;
        }
        .auto-style6 {
            height: 26px;
            width: 264px;
            text-align: center;
        }
        .auto-style8 {
            text-align: center;
            width: 264px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style4">
            <div class="auto-style3">
                вход</div>
            <table align="center">
                <tr>
                    <td class="auto-style2">логин</td>
                    <td class="auto-style6">
                        <asp:TextBox ID="username" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <asp:RequiredFieldValidator ID="label_username" runat="server" ControlToValidate="username" ErrorMessage="введите логин!" ForeColor="Maroon"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">пароль</td>
                    <td class="auto-style6">
                        <asp:TextBox ID="password" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <asp:RequiredFieldValidator ID="label_password" runat="server" ControlToValidate="password" ErrorMessage="введите пароль!" ForeColor="Maroon"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style8">
                        <asp:Button ID="btn_login" runat="server" OnClick="btn_login_Click" Text="войти" Width="180px" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style8">
                        <asp:Label ID="fail" runat="server" ForeColor="Maroon"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
