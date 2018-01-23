using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5101BFinalProject.Models
{
    public class GiftShopT
    {
        //FIELDS
        private int _gift_id;
        private string _gift_sender_first_name;
        private string _gift_sender_last_name;
        private string _gift_recipient_first_name;
        private string _gift_recipient_last_name;
        private string _gift_type;
        private string _gift_desc;
        private double _gift_price;
        private int _gift_sender_id;
        private int _gift_recipient_id;


        public int Gift_Id
        {
            get { return this._gift_id; }
            set { this._gift_id = value; }
        }

        public string Gift_Sender_First_Name
        {
            get { return this._gift_sender_first_name; }
            set { this._gift_sender_first_name = value; }
        }

        public string Gift_Sender_Last_Name
        {
            get { return this._gift_sender_last_name; }
            set { this._gift_sender_last_name = value; }
        }

        public string Gift_Recipient_First_Name
        {
            get { return this._gift_recipient_first_name; }
            set { this._gift_recipient_first_name = value; }
        }

        public string Gift_Recipient_Last_Name
        {
            get { return this._gift_recipient_last_name; }
            set { this._gift_recipient_last_name = value; }
        }

        public string Sender_Full_Name
        {
            get { return this._gift_sender_first_name + " " + this._gift_sender_last_name; }
        }

        public string Recipient_Full_Name
        {
            get { return this._gift_recipient_first_name + " " + this._gift_recipient_last_name; }
        }

        public string Gift_Type
        {
            get { return this._gift_type; }
            set { this._gift_type = value; }
        }

        public string Gift_Desc
        {
            get { return this._gift_desc; }
            set { this._gift_desc = value; }
        }

        public double Gift_Price
        {
            get { return this._gift_price; }
            set { this._gift_price = value; }
        }

        public int Gift_Sender_Id
        {
            get { return this._gift_sender_id; }
            set { this._gift_sender_id = value; }
        }

        public int Gift_Recipient_Id
        {
            get { return this._gift_recipient_id; }
            set { this._gift_recipient_id = value; }
        }

    }
}