<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="lab3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style2 {
            height: 26px;
        }
    </style>
    </head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:RadioButtonList ID="menu" runat="server" AutoPostBack="True" OnSelectedIndexChanged = "OnSelectedIndexChanged">
                <asp:ListItem Value="add">Добавление</asp:ListItem>
                <asp:ListItem Value="delete">Удаление</asp:ListItem>
                <asp:ListItem Selected="True" Value="view">Просмотр</asp:ListItem>
                <asp:ListItem Value="edit">Изменение</asp:ListItem>
            </asp:RadioButtonList>
        </div>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Заказчики]"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Width="350px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="surname" HeaderText="surname" SortExpression="surname" />
                <asp:BoundField DataField="bdYear" HeaderText="bdYear" SortExpression="bdYear" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Заказы]"></asp:SqlDataSource>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
                <asp:BoundField DataField="customerID" HeaderText="customerID" SortExpression="customerID" />
                <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
                <asp:BoundField DataField="quantity" HeaderText="quantity" SortExpression="quantity" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:Panel ID="table_add_c" runat="server">
            <table style="width: 222px">
                <tr>
                    <td class="auto-style2">ID</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="input_add_c_id" runat="server" style="width: 128px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>name</td>
                    <td>
                        <asp:TextBox ID="input_add_c_name" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>surname</td>
                    <td>
                        <asp:TextBox ID="input_add_c_surname" runat="server" Width="131px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">bdYear</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="input_add_c_bdYear" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Button ID="button_add_c" runat="server" Text="Добавить" />
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </form>
</body>
</html>
