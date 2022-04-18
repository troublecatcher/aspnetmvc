using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lab2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = username.Text;
            string pswd = password.Text;

            if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(pswd))
            {
                Session["name"] = name;
                Session["pswd"] = pswd;

                Response.Redirect("loginGetting.aspx");
            }
        }
    }
}