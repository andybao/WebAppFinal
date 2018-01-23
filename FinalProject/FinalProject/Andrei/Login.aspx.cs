using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using Final_Project_C_Sharp.Models;


namespace Final_Project_C_Sharp
{
    public partial class Login : System.Web.UI.Page
    {
        // Values to check against
        string auth_email;
        string auth_password;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Clear all error messages
            error_email.Text = error_password.Text = "";

            // If admin is logged in already, show him FAQ page
            if (!String.IsNullOrEmpty((string)Session["admin"]))
            {
                Response.Redirect("Authorized.aspx");
            }

            // Get login credentials from DB
            // Establish connection
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = ConnectDb.connectionString;

            string command = "SELECT person_email, person_pw FROM " + ConnectDb.username + ".persons WHERE person_status = 'admin'";
            conn.Open();
            OracleCommand cmd = new OracleCommand(command, conn);
            OracleDataReader reader = cmd.ExecuteReader();

            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        auth_email = Convert.ToString(reader["person_email"]);
                        auth_password = Convert.ToString(reader["person_pw"]);
                    }
                }
            }
            catch { }
            conn.Close();

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