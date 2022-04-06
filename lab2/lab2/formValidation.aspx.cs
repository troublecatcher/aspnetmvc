using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lab2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox4_TextChanged()
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(username.Text) ||
                password.Text.Length < 8 ||
                password.Text != password_confirm.Text ||
                IsValidEmail(email.Text) == false ||
                Convert.ToInt32(age.Text) < 18 || Convert.ToInt32(age.Text) > 65)
            {
                result.Text = "попробуйте еще";
            }
            else
            {
                result.Text = "всё хорошо)";
            }
        }
        bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
    }
}