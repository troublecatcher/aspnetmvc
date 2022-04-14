using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace lab3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
            table_add_c.Visible = false;
            table_delete_c.Visible = false;
            table_edit_c.Visible = false;
            table_add_o.Visible = false;
            table_delete_o.Visible = false;
            table_edit_o.Visible = false;
        }

        protected void Select(object sender, EventArgs e)
        {
            switch (subMenu.SelectedItem.Value)
            {
                case "customer":
                    switch (menu.SelectedItem.Value)
                    {
                        case "add":
                            table_add_c.Visible = true;
                            break;
                        case "delete":
                            table_delete_c.Visible = true;
                            break;
                        case "edit":
                            table_edit_c.Visible = true;
                            break;
                        default: break;
                    }
                    break;
                case "order":
                    switch (menu.SelectedItem.Value)
                    {
                        case "add":
                            table_add_o.Visible = true;
                            break;
                        case "delete":
                            table_delete_o.Visible = true;
                            break;
                        case "edit":
                            table_edit_o.Visible = true;
                            break;
                        default: break;
                    }
                    break;
                default: break;
            }
        }
        protected void button_add_c_Click(object sender, EventArgs e)
        {
            var id = input_add_c_id.Text;
            var name = input_add_c_name.Text;
            var surname = input_add_c_surname.Text;
            var year = input_add_c_bdYear.Text;
            SqlCommand cmd = new SqlCommand("INSERT INTO [Заказчики] VALUES(@id, @name, @surname, @year)", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@surname", surname);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.DataBind();
            GridView2.DataBind();
        }

        protected void button_add_o_Click(object sender, EventArgs e)
        {
            var id = input_add_o_id.Text;
            var title = input_add_o_title.Text;
            var idc = input_add_o_id_c.Text;
            var price = input_add_o_price.Text;
            var quantity = input_add_o_quantity.Text;
            SqlCommand cmd = new SqlCommand("INSERT INTO [Заказы] VALUES(@id, @title, @idc, @price, @quantity)", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@idc", idc);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.DataBind();
            GridView2.DataBind();
        }

        protected void button_delete_c_Click(object sender, EventArgs e)
        {
            var id = input_delete_c_id.Text;
            SqlCommand cmd = new SqlCommand("DELETE FROM [Заказчики] WHERE ID=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.DataBind();
            GridView2.DataBind();
        }

        protected void button_delete_o_Click(object sender, EventArgs e)
        {
            var id = input_delete_o_id.Text;
            var idc = input_delete_o_id_c.Text;
            SqlCommand cmd = new SqlCommand("DELETE FROM [Заказы] WHERE ID=@id OR customerID=@idc", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@idc", idc);
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.DataBind();
            GridView2.DataBind();
        }

        protected void button_edit_c_Click(object sender, EventArgs e)
        {
            var id = input_edit_c_id.Text;
            var name = input_edit_c_name.Text;
            var surname = input_edit_c_surname.Text;
            var year = input_edit_c_bdYear.Text;
            SqlCommand cmd = new SqlCommand("UPDATE [Заказчики] SET name = @name, surname = @surname, bdYear = @year WHERE ID = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@surname", surname);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.DataBind();
            GridView2.DataBind();
        }
        protected void button_edit_o_Click(object sender, EventArgs e)
        {
            var id = input_edit_o_id.Text;
            var title = input_edit_o_title.Text;
            var idc = input_edit_o_id_c.Text;
            var price = input_edit_o_price.Text;
            var quantity = input_edit_o_quantity.Text;
            SqlCommand cmd = new SqlCommand("UPDATE [Заказы] SET title = @title, customerID = @idc, price = @price, quantity = @quantity WHERE ID = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@idc", idc);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.DataBind();
            GridView2.DataBind();
        }
    }
}