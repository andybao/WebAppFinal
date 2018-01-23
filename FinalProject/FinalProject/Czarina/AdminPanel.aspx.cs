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
    public partial class GiftShop : System.Web.UI.Page
    {
        CalvinDb db = new CalvinDb();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_gs_show_Click(object sender, EventArgs e)
        {
            _5101BFinalProject.Models.GiftShopT giftshop = new _5101BFinalProject.Models.GiftShopT();
            //giftshop.Gift_Id = Convert.ToInt32(txt_gift_id.Text);
            //giftshop.Gift_Desc = txt_gift_desc2.Text;
            _5101BFinalProject.Models.CalvinDb db = new _5101BFinalProject.Models.CalvinDb();
            
            try
            {
                GiftShopT gs = new GiftShopT();
                if (txt_gift_id.Text != "")
                {
                    gs.Gift_Id = Convert.ToInt32(txt_gift_id.Text);
                }
                if (txt_gift_desc2.Text != "")
                {
                    gs.Gift_Desc = txt_gift_desc2.Text;
                }
                List<GiftShopT> gstable = db.Get(gs);
                table_gifts.InnerHtml = "<table border='1px solid #000'><tr><th>Gift ID</th><th>Sender's Full Name</th><th>Recipient's Full Name</th><th>Gift Type</th><th>Gift Description</th><th>Gift Price</th><th>Gift Sender ID</th><th>Gift Recipient ID</th></tr>";
                foreach (GiftShopT item in gstable)
                {
                    table_gifts.InnerHtml += "<tr><td>" + item.Gift_Id.ToString() + "</td><td>" + item.Sender_Full_Name + "</td><td>" + item.Recipient_Full_Name + "</td><td>" + item.Gift_Type + "</td><td>" + item.Gift_Desc + "</td><td> $ " + Math.Round(item.Gift_Price, 2).ToString() + "</td><td>" + item.Gift_Sender_Id.ToString() + "</td><td>" + item.Gift_Recipient_Id.ToString() + "</td></tr>";
                }
                table_gifts.InnerHtml += "</table>";
            }
            catch (OracleException except)
            {
                lbl_search_err.Text = except.Message + ". ";
            }
            finally
            {
                //lbl_msg.Text += Convert.ToString(db.Rows) + " rows deleted.";
            }
        }

        protected void btn_gs_create_Click(object sender, EventArgs e)
        {
            _5101BFinalProject.Models.GiftShopT giftshop = new _5101BFinalProject.Models.GiftShopT();
            //giftshop.Gift_Id = Convert.ToInt32(txt_gift_id2.Text); // how to put into validation
            giftshop.Gift_Sender_First_Name = txt_sender_f_name.Text;
            giftshop.Gift_Sender_Last_Name = txt_sender_l_name.Text;
            giftshop.Gift_Recipient_First_Name = txt_recipient_f_name.Text;
            giftshop.Gift_Recipient_Last_Name = txt_recipient_l_name.Text;
            giftshop.Gift_Type = ddl_gift_type.SelectedItem.Value;
            giftshop.Gift_Desc = txt_gift_desc.Text;
            

            _5101BFinalProject.Models.CalvinDb db = new _5101BFinalProject.Models.CalvinDb();

            //if (Convert.ToInt32(txt_gift_id2.Text) == 0)
            if (txt_gift_id2.Text == "")
            {
                gift_id2_err.Text = "Please enter a valid number";
            }
            else if (txt_gift_price.Text == "")
            {
                gift_price_err.Text = "Please enter a valid number";
            }
            else if (txt_gift_sender_id.Text == "")
            {
                gift_sender_id_err.Text = "Please enter a valid number";
            }
            else if (txt_gift_recipient_id.Text == "")
            {
                gift_recipient_id_err.Text = "Please enter a valid number";
            }
            else
            {
                giftshop.Gift_Id = Convert.ToInt32(txt_gift_id2.Text);
                double giftprice = Convert.ToDouble(txt_gift_price.Text);
                giftshop.Gift_Price = Math.Round(giftprice, 2);
                giftshop.Gift_Sender_Id = Convert.ToInt32(txt_gift_sender_id.Text);
                giftshop.Gift_Recipient_Id = Convert.ToInt32(txt_gift_recipient_id.Text);

                gift_id2_err.Text = "";
                gift_price_err.Text = "";
                gift_sender_id_err.Text = "";
                gift_recipient_id_err.Text = "";

                try
                {

                    db.Add(giftshop);
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
                    // Recipient ID
                    if (except.Message.Contains("ORA-01400"))
                    {
                        gift_recipient_id_err.Text = "Please provide Recipient ID.";
                    }
                    else
                    {
                        gift_recipient_id_err.Text = "";
                    }
                    if (except.Message.Contains("ORA-01722"))
                    {
                        gift_recipient_id_err.Text = "Please input a valid number";
                    }
                    else
                    {
                        gift_recipient_id_err.Text = "";
                    }
                    if (except.Message.Contains("ORA-02291"))
                    {
                        gift_recipient_id_err.Text = "Recipient ID doesn't exist";
                    }
                    else
                    {
                        gift_recipient_id_err.Text = "";
                    }
                    // Sender ID
                    if (except.Message.Contains("ORA-01400"))
                    {
                        gift_sender_id_err.Text = "Please provide Sender ID.";
                    }
                    else
                    {
                        gift_sender_id_err.Text = "";
                    }
                    if (except.Message.Contains("ORA-01722"))
                    {
                        gift_sender_id_err.Text = "Please input a valid number";
                    }
                    else
                    {
                        gift_sender_id_err.Text = "";
                    }
                    if (except.Message.Contains("ORA-02291"))
                    {
                        gift_sender_id_err.Text = "Sender ID doesn't exist";
                    }
                    else
                    {
                        gift_sender_id_err.Text = "";
                    }
                    // Gift Price
                    if (except.Message.Contains("ORA-01400"))
                    {
                        gift_price_err.Text = "Please put price for the item.";
                    }
                    else
                    {
                        gift_price_err.Text = "";
                    }
                    if (except.Message.Contains("ORA-01722"))
                    {
                        gift_price_err.Text = "Please input a valid number";
                    }
                    else
                    {
                        gift_price_err.Text = "";
                    }
                    // Gift type
                    if (except.Message.Contains("ORA-02290"))
                    {
                        gift_type_err.Text = "Please select proper gift type.";
                    }
                    else
                    {
                        gift_type_err.Text = "";
                    }
                    // Gift Description
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
                    if (except.Message.Contains("ORA-01400"))
                    {
                        gift_id2_err.Text = "Please provide Gift ID.";
                    }
                    else
                    {
                        gift_id2_err.Text = "";
                    }
                    if (except.Message.Contains("ORA-00001"))
                    {
                        gift_id2_err.Text = "Gift ID already in use.";
                    }
                    else
                    {
                        gift_id2_err.Text = "";
                    }
                    if (except.Message.Contains("ORA-01722"))
                    {
                        gift_id2_err.Text = "Please input a valid number";
                    }
                    else
                    {
                        gift_id2_err.Text = "";
                    }


                    lbl_insert_err.Text = except.Message + ". ";
                }
                finally
                {
                    lbl_insert_err.Text += Convert.ToString(db.Rows) + " rows inserted.";
                }

            }

            
        }

        protected void btn_gs_update_Click(object sender, EventArgs e)
        {
            _5101BFinalProject.Models.GiftShopT giftshop = new _5101BFinalProject.Models.GiftShopT();
            giftshop.Gift_Id = Convert.ToInt32(txt_gift_id2.Text);
            giftshop.Gift_Sender_First_Name = txt_sender_f_name.Text;
            giftshop.Gift_Sender_Last_Name = txt_sender_l_name.Text;
            giftshop.Gift_Recipient_First_Name = txt_recipient_f_name.Text;
            giftshop.Gift_Recipient_Last_Name = txt_recipient_l_name.Text;
            giftshop.Gift_Type = ddl_gift_type.SelectedItem.Value;
            giftshop.Gift_Desc = txt_gift_desc.Text;
            double giftprice = Convert.ToDouble(txt_gift_price.Text);
            giftshop.Gift_Price = Math.Round(giftprice, 2);
            giftshop.Gift_Sender_Id = Convert.ToInt32(txt_gift_sender_id.Text);
            giftshop.Gift_Recipient_Id = Convert.ToInt32(txt_gift_recipient_id.Text);

            _5101BFinalProject.Models.CalvinDb db = new _5101BFinalProject.Models.CalvinDb();

            try
            {
                db.Update(giftshop);
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
                // Recipient ID
                if (except.Message.Contains("ORA-01400"))
                {
                    gift_recipient_id_err.Text = "Please provide Recipient ID.";
                }
                else
                {
                    gift_recipient_id_err.Text = "";
                }
                if (except.Message.Contains("ORA-01722"))
                {
                    gift_recipient_id_err.Text = "Please input a valid number";
                }
                else
                {
                    gift_recipient_id_err.Text = "";
                }
                if (except.Message.Contains("ORA-02291"))
                {
                    gift_recipient_id_err.Text = "Recipient ID doesn't exist";
                }
                else
                {
                    gift_recipient_id_err.Text = "";
                }
                // Sender ID
                if (except.Message.Contains("ORA-01400"))
                {
                    gift_sender_id_err.Text = "Please provide Sender ID.";
                }
                else
                {
                    gift_sender_id_err.Text = "";
                }
                if (except.Message.Contains("ORA-01722"))
                {
                    gift_sender_id_err.Text = "Please input a valid number";
                }
                else
                {
                    gift_sender_id_err.Text = "";
                }
                if (except.Message.Contains("ORA-02291"))
                {
                    gift_sender_id_err.Text = "Sender ID doesn't exist";
                }
                else
                {
                    gift_sender_id_err.Text = "";
                }
                // Gift Price
                if (except.Message.Contains("ORA-01400"))
                {
                    gift_price_err.Text = "Please put price for the item.";
                }
                else
                {
                    gift_price_err.Text = "";
                }
                if (except.Message.Contains("ORA-01722"))
                {
                    gift_price_err.Text = "Please input a valid number";
                }
                else
                {
                    gift_price_err.Text = "";
                }
                // Gift type
                if (except.Message.Contains("ORA-02290"))
                {
                    gift_type_err.Text = "Please select proper gift type.";
                }
                else
                {
                    gift_type_err.Text = "";
                }
                // Gift Description
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
                // Gift Id
                if (except.Message.Contains("ORA-02290"))
                {
                    gift_id2_err.Text = "Please provide Gift ID.";
                }
                else
                {
                    gift_id2_err.Text = "";
                }
                if (except.Message.Contains("ORA-01400"))
                {
                    gift_id2_err.Text = "Please provide Gift ID.";
                }
                else
                {
                    gift_id2_err.Text = "";
                }
                if (except.Message.Contains("ORA-00001"))
                {
                    gift_id2_err.Text = "Gift ID already in use.";
                }
                else
                {
                    gift_id2_err.Text = "";
                }
                if (except.Message.Contains("ORA-01722"))
                {
                    gift_id2_err.Text = "Please input a valid number";
                }
                else
                {
                    gift_id2_err.Text = "";
                }

                lbl_insert_err.Text = except.Message + ". ";
            }
            finally
            {
                lbl_insert_err.Text += Convert.ToString(db.Rows) + " rows updated.";
            }
        }

        protected void btn_gs_delete_Click(object sender, EventArgs e)
        {
            _5101BFinalProject.Models.GiftShopT giftshop = new _5101BFinalProject.Models.GiftShopT();
            giftshop.Gift_Id = Convert.ToInt32(txt_gift_id3.Text);
            _5101BFinalProject.Models.CalvinDb db = new _5101BFinalProject.Models.CalvinDb();

            try
            {
                db.Delete(giftshop);
            }
            catch (OracleException except)
            {
                if (except.Message.Contains("ORA-02290"))
                {
                    gift_id3_err.Text = "Please provide Gift ID.";
                }
                else
                {
                    gift_id3_err.Text = "";
                }
                if (except.Message.Contains("ORA-01400"))
                {
                    gift_id3_err.Text = "Please provide Gift ID.";
                }
                else
                {
                    gift_id3_err.Text = "";
                }
                
                if (except.Message.Contains("ORA-01722"))
                {
                    gift_id3_err.Text = "Please input a valid number";
                }
                else
                {
                    gift_id3_err.Text = "";
                }

                lbl_delete_err.Text = except.Message + ". ";
            }
            finally
            {
                lbl_delete_err.Text += Convert.ToString(db.Rows) + " rows deleted.";
            }
        }
    }
}