using MySql.Data.MySqlClient;
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
        string command = "", encrypted_pass = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["LoggedIn"] != null && (bool)Session["LoggedIn"])
            {
                string user = Session["user"].ToString();
                login_button.Text = "Welcome, "+user;
            }
            else
            {
                login_button.Text = "SIGN IN";
            }
        }
        protected void logout_button_Clicked(object sender, EventArgs e)
        {
            Session["LoggedIn"] = false;
            Session["user"] = null;
            Response.Redirect(Request.RawUrl);
        }
        protected void signin_Click(object sender, EventArgs e)
        {
            string email = signemail_textbox.Text;
            DatabaseClass database = new DatabaseClass();
            string encrypt_command = "SELECT MD5('" + signpassword_textbox.Text + "');";

            errorMessage1.Style["display"] = "none";

            encrypted_pass = database.password_encryptor(encrypt_command);
            command = "SELECT email_address,password FROM contact_info_table WHERE email_address='" + email + "' AND password='" + encrypted_pass + "';";

            MySqlDataReader login_stat = database.user_sign_in(command);

            if (login_stat.HasRows)
            {
                //Login Success
                Session["LoggedIn"] = true;
                signemail_textbox.Text = "";
                signpassword_textbox.Text = "";

                //save name to session
                Session["user"] = database.GetFirstName(email);

                //reload page
                Response.Redirect(Request.RawUrl);



            }
            else
            {
                errorMessage1.Style["display"] = "block";
                signUpID.Style["margin-top"] = "0";
            }
        }
        protected void login_button_Click(object sender, EventArgs e)
        {
            if (login_button.Text == "SIGN IN")
            {
                loginModal.Style["display"] = "block";
            }
            else
            {
                loggedInModal.Style["display"] = "block";
            }
        }
    }
}