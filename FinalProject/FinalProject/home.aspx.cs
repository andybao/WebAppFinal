using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_demo_click(object sender, EventArgs e)
        {
            Response.Redirect("Demo/demo.aspx");
        }

        protected void lbtn_andrei_click(object sender, EventArgs e) { }

        protected void lbtn_bradley_click(object sender, EventArgs e) { }

        protected void lbtn_czarina_click(object sender, EventArgs e) { }

        protected void lbtn_raminder_click(object sender, EventArgs e) { }

        protected void lbtn_sophia_click(object sender, EventArgs e) { } 

        protected void lbtn_andy_click(object sender, EventArgs e) { }
    }
}