using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lab1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> List = new Dictionary<string, string>();
            List.Add("anton", "123");
            List.Add("da", "456");
            List.Add("net", "789");
            if (List.ContainsKey(username.Text))
                if (List[username.Text] == password.Text)
                    Response.Redirect("success.aspx");
                else
                    sorry();
            else sorry();
        }
        protected void sorry()
        {
            fail.Text = "неверный логин или пароль, попробуйте снова!";
        }
    }
}