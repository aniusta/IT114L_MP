using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MP
{
    public partial class Admin_Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            errmsg.InnerText = "";
        }

        protected void login_button_Click(object sender, EventArgs e)
        {
            if (username_tb.Text == "admin" && password_tb.Text == "admin")
            {
                Response.Redirect("Report_Page.aspx");
            }
            else if (username_tb.Text == "" || password_tb.Text == "")
            {
                errmsg.InnerText = "fill in the boxes";
            }
            else
            {
                errmsg.InnerText = "username and/or password not found";
            }
        }
    }
}