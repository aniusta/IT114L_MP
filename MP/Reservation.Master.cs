using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MP
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Contact.aspx");
        }
        protected void signin_Click(object sender, EventArgs e)
        {
        }
        protected void login_button_Click(object sender, EventArgs e)
        {
            loginModal.Style["display"] = "block";
        }
    }
}