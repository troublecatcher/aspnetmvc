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
        }

        /*protected void Button1_Click1(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Заказчики values('" + TextBox1.Text + "', '" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            Label1.Text = "success";
            GridView1.DataBind();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
        }*/
        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            switch (menu.SelectedItem.Value)
            {
                case "add":
                    table_add_c.Visible = true;
                    break;
                case "delete":
                    break;
                case "view":
                    break;
                case "edit":
                    break;
                default:
                    break;
            }
        }
    }
}