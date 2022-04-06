<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="form.aspx.cs" Inherits="lab1.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="nickname" runat="server">Никнейм</asp:TextBox>
            <br />
            <asp:ListBox ID="ListBox1" runat="server" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged">
                <asp:ListItem Selected="True">Орк</asp:ListItem>
                <asp:ListItem>Эльф</asp:ListItem>
                <asp:ListItem>Маг</asp:ListItem>
                <asp:ListItem>Рыцарь</asp:ListItem>
            </asp:ListBox>
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value="purple">фиолетовый</asp:ListItem>
                <asp:ListItem Value="red">красный</asp:ListItem>
                <asp:ListItem Value="blue">синий</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                <asp:ListItem Selected="True" Value="radiant">свет</asp:ListItem>
                <asp:ListItem Value="dire">тьма</asp:ListItem>
            </asp:RadioButtonList>
            <asp:Button ID="submit" runat="server" OnClick="submit_Click" Text="Button" />
            <br />
        </div>
        <asp:Label ID="result" runat="server"></asp:Label>
    </form>
</body>
</html>
