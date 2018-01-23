using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _5101BFinalProject
{
    public partial class Login : System.Web.UI.Page
    {
        string admin_email = "czarina@humber.ca";
        string admin_pass = "5101";

        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_variable.Text = Request.QueryString["admin"];
            if (Session["email"] != null)
            {
                login_portal.InnerHtml = Session["email"].ToString();
            }
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            string check_email = email_log.Text;
            string check_pass = password_log.Text;

            if ((check_email == admin_email) && (check_pass == admin_pass))
            {
                Session["email"] = check_email;
                Response.Redirect("AdminPanel.aspx");
            }
            if (check_email == "" || check_pass == "")
            {
                lbl_login_err.Text = "Please login.";
            }
            else if ((check_email != admin_email || check_pass != admin_pass))
            {
                lbl_login_err.Text = "Access denied.";
            }
        }
    }
}