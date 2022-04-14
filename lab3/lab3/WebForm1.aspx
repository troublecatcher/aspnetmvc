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
        .auto-style3 {
            width: 27%;
            margin-right: 0px;
        }
        .auto-style4 {
            height: 33px;
        }
        .auto-style5 {
            width: 0%;
        }
        .auto-style6 {
            text-align: left;
        }
    </style>
    </head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style3">
                <tr>
                    <td>
            <asp:RadioButtonList ID="menu" runat="server">
                <asp:ListItem Value="add" Selected="True">Добавление</asp:ListItem>
                <asp:ListItem Value="delete">Удаление</asp:ListItem>
                <asp:ListItem Value="edit">Изменение</asp:ListItem>
            </asp:RadioButtonList>
                    </td>
                    <td>
                        <asp:RadioButtonList ID="subMenu" runat="server">
                            <asp:ListItem Value="customer" Selected="True">Заказчики</asp:ListItem>
                            <asp:ListItem Value="order">Заказы</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td>
                        <asp:Button ID="select" runat="server" Text="Применить" OnClick="Select" />
                    </td>
                </tr>
            </table>
        </div>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Заказчики]"></asp:SqlDataSource>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Заказы]"></asp:SqlDataSource>
        <table class="auto-style5">
            <tr>
                <td class="auto-style6">
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
                </td>
                <td class="auto-style6"><asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None">
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
                </td>
            </tr>
        </table>
        <br />
&nbsp;<asp:Panel ID="table_add_c" runat="server" Width="324px">
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
                    <td class="auto-style4">surname</td>
                    <td class="auto-style4">
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
                        <asp:Button ID="button_add_c" runat="server" Text="Добавить" OnClick="button_add_c_Click" />
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="table_delete_c" runat="server" Width="324px">
            <table style="width: 222px">
                <tr>
                    <td class="auto-style2">ID</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="input_delete_c_id" runat="server" style="width: 128px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Button ID="button_delete_c" runat="server" Text="Удалить" OnClick="button_delete_c_Click" />
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="table_edit_c" runat="server" Width="324px">
            <table style="width: 222px">
                <tr>
                    <td class="auto-style2">ID</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="input_edit_c_id" runat="server" style="width: 128px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                </tr>
                <tr>
                    <td>name</td>
                    <td>
                        <asp:TextBox ID="input_edit_c_name" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>surname</td>
                    <td>
                        <asp:TextBox ID="input_edit_c_surname" runat="server" Width="131px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">bdYear</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="input_edit_c_bdYear" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Button ID="button_edit_c" runat="server" Text="Изменить" OnClick="button_edit_c_Click" />
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="table_add_o" runat="server" Width="328px">
            <table class="auto-style3">
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label17" runat="server" Text="ID"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="input_add_o_id" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="title"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="input_add_o_title" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label1" runat="server" Text="customerID"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="input_add_o_id_c" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="price"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="input_add_o_price" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="quantity"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="input_add_o_quantity" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="button_add_o" runat="server" Text="Добавить" OnClick="button_add_o_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="table_delete_o" runat="server" Width="328px">
            <table class="auto-style3">
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label5" runat="server" Text="customerID"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="input_delete_o_id_c" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        ID</td>
                    <td>
                        <asp:TextBox ID="input_delete_o_id" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="button_delete_o" runat="server" Text="Удалить" OnClick="button_delete_o_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="table_edit_o" runat="server" Width="328px">
            <table class="auto-style3">
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label18" runat="server" Text="ID"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="input_edit_o_id" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label13" runat="server" Text="customerID"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="input_edit_o_id_c" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label14" runat="server" Text="title"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="input_edit_o_title" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label15" runat="server" Text="price"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="input_edit_o_price" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label16" runat="server" Text="quantity"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="input_edit_o_quantity" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="button_edit_o" runat="server" Text="Изменить" OnClick="button_edit_o_Click"/>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </form>
</body>
</html>
