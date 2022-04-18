using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lab1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void submit_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(nickname.Text))
            {
                result.Text = "Ваш ник - "
                + nickname.Text + ", вы играете за '"
                + ListBox1.SelectedItem + "', ваш цвет - "
                + DropDownList1.SelectedItem + ", ваша команда - "
                + RadioButtonList1.SelectedItem;
            }
        }
    }
}