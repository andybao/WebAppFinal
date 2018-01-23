using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using _5101BFinalProject.Models;

namespace _5101BFinalProject
{
    public partial class Giftshop : System.Web.UI.Page
    {

        CalvinDb db = new CalvinDb();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            _5101BFinalProject.Models.ClientGiftshop clientgiftshop = new _5101BFinalProject.Models.ClientGiftshop();
            clientgiftshop.Gift_Sender_First_Name = txt_sender_f_name.Text;
            clientgiftshop.Gift_Sender_Last_Name = txt_sender_l_name.Text;
            clientgiftshop.Gift_Recipient_First_Name = txt_recipient_f_name.Text;
            clientgiftshop.Gift_Recipient_Last_Name = txt_recipient_l_name.Text;
            clientgiftshop.Gift_Type = ddl_gift_type.SelectedItem.Value;
            clientgiftshop.Gift_Desc = txt_gift_desc.Text;

            _5101BFinalProject.Models.CalvinDb db = new _5101BFinalProject.Models.CalvinDb();

            try
            {
                db.Add(clientgiftshop);
            }
            catch (OracleException except)
            {
                if (txt_sender_f_name.Text == "")
                {
                    if (except.Message.Contains("ORA-01400"))
                    {
                        gift_send_f_name_err.Text = "Please provide Sender's first name.";
                    }
                }
                else
                {
                    gift_send_f_name_err.Text = "";
                }
                if (txt_sender_l_name.Text == "")
                {
                    if (except.Message.Contains("ORA-01400"))
                    {
                        gift_send_l_name_err.Text = "Please provide Sender's last name.";
                    }
                }
                else
                {
                    gift_send_l_name_err.Text = "";
                }
                if (txt_recipient_f_name.Text == "")
                {
                    if (except.Message.Contains("ORA-01400"))
                    {
                        gift_rec_f_name_err.Text = "Please provide Recipient's first name.";
                    }
                }
                else
                {
                    gift_rec_f_name_err.Text = "";
                }
                if (txt_recipient_l_name.Text == "")
                {
                    if (except.Message.Contains("ORA-01400"))
                    {
                        gift_rec_l_name_err.Text = "Please provide Recipient's last name.";
                    }
                }
                else
                {
                    gift_rec_l_name_err.Text = "";
                }
                // Gift Type
                if (except.Message.Contains("ORA-02290"))
                {
                    gift_type_err.Text = "Please select proper gift type.";
                }
                else
                {
                    gift_type_err.Text = "";
                }
                //Gift Description
                if (txt_gift_desc.Text == "")
                {
                    if (except.Message.Contains("ORA-01400"))
                    {
                        gift_desc_err.Text = "Please provide gift description.";
                    }
                }
                else
                {
                    gift_desc_err.Text = "";
                }

                




            }
            finally
            {
                thank_you_msg.Text = "Thank you, your order has been received.";
            }
        }
    }
}