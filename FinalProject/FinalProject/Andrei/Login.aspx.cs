using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Final_Project_C_Sharp
{
    public partial class Login : System.Web.UI.Page
    {
        // Values to check against
        string auth_email = "andrei@humber.ca";
        string auth_password = "1";

        protected void Page_Load(object sender, EventArgs e)
        {
            // Clear all error messages
            error_email.Text = error_password.Text = "";

        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            // Set flag variable
            bool exit = false;

            // Check that email is not empty
            if ("" == txt_email.Text || null == txt_email.Text)
            {
                error_email.Text = "Email must be entered.";
                exit = true;
            }

            // Check that password is not empty
            if ("" == txt_password.Text || null == txt_password.Text)
            {
                error_password.Text = "Password must be entered.";
                exit = true;
            }

            if (!exit) { 

                string ck_email = txt_email.Text;
                string ck_password = txt_password.Text;

                // Check if user provided correct credentials. If yes, set Session['email'] & redirect user to another page
                if (ck_email == auth_email && ck_password == auth_password)
                {
                    Session["admin"] = "true";
                    Session["email"] = ck_email;
                    Response.Redirect("Authorized.aspx");
                }
                else {
                    error_login.Text = "Sorry, login credentials are wrong.";
                }
            }
            return;
        }
    }
}