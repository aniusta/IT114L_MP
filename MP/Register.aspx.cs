using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MP
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Request.QueryString.Get("showError") != null && Request.QueryString.Get("showError").ToLower() == "true")
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Account not recognised.')", true);
            //}


            if (Session["LoggedIn"] != null && (bool)Session["LoggedIn"])
            {
                //Saves the changed data to viewstate (for updating data to database)
                ViewState["FirstName"] = firstname_textbox.Text;
                ViewState["LastName"] = lastname_textbox.Text;
                ViewState["Phone"] = phone_textbox.Text;
                ViewState["Email"] = email_textbox.Text;

                firstname_textbox.Text = Session["firstname"]?.ToString();
                lastname_textbox.Text = Session["lastname"]?.ToString();
                phone_textbox.Text = Session["phonenumber"]?.ToString();
                email_textbox.Text = Session["emailaddress"]?.ToString();
                emailconfirm_textbox.Text = Session["emailaddress"]?.ToString();
                create_button.Text = "UPDATE";
                acknowledgeContainer.Visible = false;
            }
        }

        protected void cancel_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Bookings.aspx");
            //Response.Redirect(Request.RawUrl + "?showError=true");
        }

        protected void create_button_Click(object sender, EventArgs e)
        {
            DatabaseClass database = new DatabaseClass();

            if (Session["LoggedIn"] != null && (bool)Session["LoggedIn"])
            {
                if (Validateinput() && ValidateEmail() && ValidatePassword())
                {
                    //Retrieve data from viewstate
                    //Because postback happens before create_button_Click is run.
                    string firstName = ViewState["FirstName"].ToString();
                    string lastName = ViewState["LastName"].ToString();
                    string phone = ViewState["Phone"].ToString();
                    string email = ViewState["Email"].ToString();
                    string password = this.password.Text;
                    string encrypt_command = "SELECT MD5('" + password + "');";
                    string encrypted_pass = database.password_encryptor(encrypt_command);

                    //update if user is logged in
                    database.UpdateRegistrationInfo(firstName, lastName, phone, email, encrypted_pass, Session["user"].ToString());

                    //Saves updated information to session
                    Session["firstname"] = firstName;
                    Session["lastname"] = lastName;
                    Session["phonenumber"] = phone;
                    Session["emailaddress"] = email;

                    Response.Redirect(Request.RawUrl);
                }
            }
            else
            {
                if (Validateinput() && ValidateEmail() && ValidatePassword() && ValidateCheckboxes())
                {
                    string firstName = firstname_textbox.Text;
                    string lastName = lastname_textbox.Text;
                    string phone = phone_textbox.Text;
                    string email = email_textbox.Text;
                    string password = this.password.Text;
                    string encrypt_command = "SELECT MD5('" + password + "');";
                    string encrypted_pass = database.password_encryptor(encrypt_command);

                    database.InsertRegistrationInfo(firstName, lastName, phone, email, encrypted_pass);

                    //Alerts successful registration
                    string script = "alert('Registration successful!');";
                    ClientScript.RegisterStartupScript(this.GetType(), "UploadSuccess", script, true);

                    //Reset form
                    firstname_textbox.Text = "";
                    lastname_textbox.Text = "";
                    phone_textbox.Text = "";
                    email_textbox.Text = "";
                    emailconfirm_textbox.Text = "";

                }
            }
        }

        protected bool Validateinput()
        {
            bool isValid = true;

            isValid &= ValidateField(firstname_textbox, firstError, "First name is required.");
            isValid &= ValidateField(lastname_textbox, lastError, "Last name is required.");
            isValid &= ValidateField(email_textbox, emailError, "Email is required.");
            isValid &= ValidateField(password, passwordError, "Password is required.");

            return isValid;
        }

        private bool ValidateField(TextBox textbox, HtmlGenericControl errorElement, string errorMessage)
        {
            bool isValid = !string.IsNullOrEmpty(textbox.Text);

            errorElement.Style["display"] = isValid ? "none" : "block";
            errorElement.InnerText = isValid ? string.Empty : errorMessage;

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
                emailError.InnerText = "Error: Invalid Email.";
                return false;
            }

            // Validate email and email confirmation match
            if (email != emailConfirm)
            {
                emailConfirmError.Attributes["style"] = "display: block;";
                emailError.InnerText = "Error: Confirmed email does not match.";
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
                passwordError.InnerText = "Error: Invalid Password.";
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
                passwordError.InnerText = "Error: Confirmed password does not match.";
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