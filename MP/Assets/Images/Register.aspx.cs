using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MP
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void cancel_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Bookings.aspx");
        }

        protected void create_button_Click(object sender, EventArgs e)
        {
            if (ValidateEmail() && ValidatePassword() && ValidateCheckboxes())
            {
                DatabaseClass database = new DatabaseClass();

                string firstName = firstname_textbox.Text;
                string lastName = lastname_textbox.Text;
                string phone = phone_textbox.Text;
                string email = email_textbox.Text;
                string password = this.password.Text;
                string encrypt_command = "SELECT MD5('" + password + "');";

                //Save data to database
                string encrypted_pass = database.password_encryptor(encrypt_command);
                database.InsertRegistrationInfo(firstName, lastName, phone, email, encrypted_pass);

                //Alerts successful registration
                string script = "alert('Registration successful!');";
                ClientScript.RegisterStartupScript(this.GetType(), "UploadSuccess", script, true);

                //Saves login to session
                Session["user"] = firstName;
                Session["LoggedIn"] = true;

                //Reset form
                firstname_textbox.Text = "";
                lastname_textbox.Text = "";
                phone_textbox.Text = "";
                email_textbox.Text = "";
                emailconfirm_textbox.Text = "";

                //reload page
                Response.Redirect(Request.RawUrl);
            }
        }

        protected bool Validateinput()
        {
            bool isValid = true;
            return isValid;
        }
        protected bool ValidateCheckboxes()
        {
            if (!privacy_checkbox.Checked || !acknowledgement_checkbox.Checked)
            {
                acknowledgeError.Attributes["style"] = "display: block;";
                return false;
            }

            acknowledgeError.Attributes["style"] = "";
            return true;
        }


        protected bool ValidateEmail()
        {
            string email = email_textbox.Text;
            string emailConfirm = emailconfirm_textbox.Text;

            // Regular expression pattern for email validation
            string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            // Validate email format
            if (!Regex.IsMatch(email, emailPattern))
            {
                emailError.Attributes["style"] = "display: block;";
                return false;
            }

            // Validate email and email confirmation match
            if (email != emailConfirm)
            {
                emailConfirmError.Attributes["style"] = "display: block;";
                return false;
            }

            // Both email validation checks passed
            emailError.Attributes["style"] = "";
            emailConfirmError.Attributes["style"] = "";
            return true;
        }


        protected bool ValidatePassword()
        {
            bool isValid = true;

            // Validate password length
            if (password.Text.Length < 8)
            {
                passwordError.Style["display"] = "block";
                isValid = false;
            }
            else
            {
                passwordError.Style["display"] = "none";
            }

            // Validate password and password confirmation match
            if (password.Text != passwordconfirm.Text && password.Text.Length > 8)
            {
                passwordConfirmError.Style["display"] = "block";
                isValid = false;
            }
            else
            {
                passwordConfirmError.Style["display"] = "none";
            }

            return isValid;
        }

    }
}