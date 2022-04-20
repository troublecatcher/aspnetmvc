using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lab2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "";
            Label2.Text = "";
            Label3.Text = "";
            Label4.Text = "";
            Label5.Text = "";
            result.Text = "";
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
            Regex validateEmailRegex = new Regex("^\\S+@\\S+\\.\\S+$");

            if (String.IsNullOrEmpty(username.Text))
            {
                Label1.Text = "Имя не должно быть пустым!";
                return;
            }
            if (password.Text != password_confirm.Text)
            {
                Label3.Text = "Пароли не совпадают!";
                return;
            }
            if (password.Text.Length < 8)
            {
                Label2.Text = "Пароль меньше 8 символов!";
                return;
            }
            if (validateEmailRegex.IsMatch(email.Text) == false)
            {
                Label4.Text = "Неверно введен Email!";
                return;
            }
            if (Convert.ToInt32(age.Text) < 18 || Convert.ToInt32(age.Text) > 65)
            {
                Label5.Text = "Возраст меньше 18 или больше 65!";
                return;
            }
            result.Text = "всё хорошо";
        }
    }
}