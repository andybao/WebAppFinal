using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5101BFinalProject.Models
{
    public class ClientGiftshop
    {
        private string _gift_sender_first_name;
        private string _gift_sender_last_name;
        private string _gift_recipient_first_name;
        private string _gift_recipient_last_name;
        private string _gift_type;
        private string _gift_desc;


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



    }
}