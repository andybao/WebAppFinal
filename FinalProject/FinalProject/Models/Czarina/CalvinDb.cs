using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;

namespace _5101BFinalProject.Models
{
    public class CalvinDb
    {
        private const string _host = "calvin.humber.ca";
        private const string _port = "1521";
        private const string _sid = "grok";
        private const string _user = OracleCredentials.username;
        private const string _pass = OracleCredentials.password;
        private static string _connectionString = OracleConnString(_host, _port, _sid, _user, _pass);
        private OracleConnection conn = new OracleConnection(_connectionString);
        private int _rows;

        private string connectionString { get { return OracleConnString(_host, _port, _sid, _user, _pass); } }

        // METHODS
        public List<GiftShopT> Get(GiftShopT gshop)
        {
            List<GiftShopT> _giftshop = new List<GiftShopT>();
            OracleCommand cmd;
            OracleDataReader reader;

            string query;

            if (gshop.Gift_Id != 0)
            {
                query = "SELECT * FROM gift_shop WHERE gift_id = :gshop_id";

                conn.Open();

                cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add(new OracleParameter("gshop_id", gshop.Gift_Id));
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    GiftShopT giftshop = new GiftShopT();
                    {
                        giftshop.Gift_Id = Convert.ToInt32(reader["gift_id"]);
                        giftshop.Gift_Sender_First_Name = reader["gift_sender_first_name"].ToString();
                        giftshop.Gift_Sender_Last_Name = reader["gift_sender_last_name"].ToString();
                        giftshop.Gift_Recipient_First_Name = reader["gift_recipient_first_name"].ToString();
                        giftshop.Gift_Recipient_Last_Name = reader["gift_recipient_last_name"].ToString();
                        giftshop.Gift_Type = reader["gift_type"].ToString();
                        giftshop.Gift_Desc = reader["gift_desc"].ToString();
                        giftshop.Gift_Price = Convert.ToDouble(reader["gift_price"]);
                        giftshop.Gift_Sender_Id = Convert.ToInt32(reader["gift_sender_id"]);
                        giftshop.Gift_Recipient_Id = Convert.ToInt32(reader["gift_recipient_id"]);
                    }
                    _giftshop.Add(giftshop);
                }
                reader.Close();
                cmd.Dispose();
                conn.Close();
                return _giftshop;
            }

            if (!String.IsNullOrWhiteSpace(gshop.Gift_Desc))
            {
                query = "SELECT * FROM gift_shop WHERE gift_desc LIKE '%' || :gshop_desc || '%'";

                conn.Open();


                cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add(new OracleParameter("gshop_desc", gshop.Gift_Desc));
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    GiftShopT gs_temp = new GiftShopT();
                    {
                        gs_temp.Gift_Id = Convert.ToInt32(reader["gift_id"]);
                        gs_temp.Gift_Sender_First_Name = reader["gift_sender_first_name"].ToString();
                        gs_temp.Gift_Sender_Last_Name = reader["gift_sender_last_name"].ToString();
                        gs_temp.Gift_Recipient_First_Name = reader["gift_recipient_first_name"].ToString();
                        gs_temp.Gift_Recipient_Last_Name = reader["gift_recipient_last_name"].ToString();
                        gs_temp.Gift_Type = reader["gift_type"].ToString();
                        gs_temp.Gift_Desc = reader["gift_desc"].ToString();
                        gs_temp.Gift_Price = Convert.ToDouble(reader["gift_price"]);
                        gs_temp.Gift_Sender_Id = Convert.ToInt32(reader["gift_sender_id"]);
                        gs_temp.Gift_Recipient_Id = Convert.ToInt32(reader["gift_recipient_id"]);
                    }
                    _giftshop.Add(gs_temp);
                }
                reader.Close();
                cmd.Dispose();
                conn.Close();
                return _giftshop;
            }


            query = "SELECT * FROM gift_shop ORDER BY gift_id";

            conn.Open();

            cmd = new OracleCommand(query, conn);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                GiftShopT giftShop = new GiftShopT();
                {
                    giftShop.Gift_Id = Convert.ToInt32(reader["gift_id"]);
                    giftShop.Gift_Sender_First_Name = reader["gift_sender_first_name"].ToString();
                    giftShop.Gift_Sender_Last_Name = reader["gift_sender_last_name"].ToString();
                    giftShop.Gift_Recipient_First_Name = reader["gift_recipient_first_name"].ToString();
                    giftShop.Gift_Recipient_Last_Name = reader["gift_recipient_last_name"].ToString();
                    giftShop.Gift_Type = reader["gift_type"].ToString();
                    giftShop.Gift_Desc = reader["gift_desc"].ToString();
                    giftShop.Gift_Price = Convert.ToDouble(reader["gift_price"]);
                    giftShop.Gift_Sender_Id = Convert.ToInt32(reader["gift_sender_id"]);
                    giftShop.Gift_Recipient_Id = Convert.ToInt32(reader["gift_recipient_id"]);
                }
                _giftshop.Add(giftShop);
            }
            reader.Close();
            cmd.Dispose();
            conn.Close();
            return _giftshop;
        }

        public void Add(GiftShopT gshop)
        {
            string command = "INSERT INTO gift_shop (gift_id, gift_sender_first_name, gift_sender_last_name, gift_recipient_first_name, gift_recipient_last_name, gift_type, gift_desc, gift_price, gift_sender_id, gift_recipient_id) VALUES(:gs_id, :gs_sender_f_name, :g_sender_l_name, :g_recipient_f_name, :g_recipient_l_name, :gs_type, :gs_desc, :gs_price, :gs_sender_id, :gs_recipient_id)";

            conn.Open();

            OracleCommand cmd = new OracleCommand(command, conn);
            cmd.Parameters.Add(new OracleParameter("gs_id", gshop.Gift_Id));
            cmd.Parameters.Add(new OracleParameter("gs_sender_f_name", gshop.Gift_Sender_First_Name));
            cmd.Parameters.Add(new OracleParameter("gs_sender_l_name", gshop.Gift_Sender_Last_Name));
            cmd.Parameters.Add(new OracleParameter("gs_recipient_f_name", gshop.Gift_Recipient_First_Name));
            cmd.Parameters.Add(new OracleParameter("gs_recipient_l_name", gshop.Gift_Recipient_Last_Name));
            cmd.Parameters.Add(new OracleParameter("gs_type", gshop.Gift_Type));
            cmd.Parameters.Add(new OracleParameter("gs_desc", gshop.Gift_Desc));
            cmd.Parameters.Add(new OracleParameter("gs_price", gshop.Gift_Price));
            cmd.Parameters.Add(new OracleParameter("gs_sender_id", gshop.Gift_Sender_Id));
            cmd.Parameters.Add(new OracleParameter("gs_recipient_id", gshop.Gift_Recipient_Id));
            _rows = cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();
        }

        public void Update(GiftShopT gshop)
        {
            string command = "UPDATE gift_shop SET gift_sender_first_name = :gs_sender_f_name, gift_sender_last_name = :gs_sender_l_name, gift_recipient_first_name = :gs_recipient_f_name, gift_recipient_last_name = :gs_recipient_l_name, gift_type = :gs_type, gift_desc = :gs_desc, gift_price = :gs_price, gift_sender_id = :gs_sender_id, gift_recipient_id = :gs_recipient_id WHERE gift_id = :g_id";

            conn.Open();

            OracleCommand cmd = new OracleCommand(command, conn);
            cmd.Parameters.Add(new OracleParameter("gs_sender_f_name", gshop.Gift_Sender_First_Name));
            cmd.Parameters.Add(new OracleParameter("gs_sender_l_name", gshop.Gift_Sender_Last_Name));
            cmd.Parameters.Add(new OracleParameter("gs_recipient_f_name", gshop.Gift_Recipient_First_Name));
            cmd.Parameters.Add(new OracleParameter("gs_recipient_l_name", gshop.Gift_Recipient_Last_Name));
            cmd.Parameters.Add(new OracleParameter("gs_type", gshop.Gift_Type));
            cmd.Parameters.Add(new OracleParameter("gs_desc", gshop.Gift_Desc));
            cmd.Parameters.Add(new OracleParameter("gs_price", gshop.Gift_Price));
            cmd.Parameters.Add(new OracleParameter("gs_sender_id", gshop.Gift_Sender_Id));
            cmd.Parameters.Add(new OracleParameter("gs_recipient_id", gshop.Gift_Recipient_Id));
            cmd.Parameters.Add(new OracleParameter("gs_id", gshop.Gift_Id));

            _rows = cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();
        }

        public void Add(ClientGiftshop cgshop)
        {
            string command = "UPDATE gift_shop SET gift_sender_first_name = :gs_sender_f_name, gift_sender_last_name = :gs_sender_l_name, gift_recipient_first_name = :gs_recipient_f_name, gift_recipient_last_name = :gs_recipient_l_name, gift_type = :gs_type, gift_desc = :gs_desc, gift_price = 0.99, gift_sender_id = 1, gift_recipient_id = 2 WHERE gift_id = 1";

            conn.Open();

            OracleCommand cmd = new OracleCommand(command, conn);
            cmd.Parameters.Add(new OracleParameter("gs_sender_f_name", cgshop.Gift_Sender_First_Name));
            cmd.Parameters.Add(new OracleParameter("gs_sender_l_name", cgshop.Gift_Sender_Last_Name));
            cmd.Parameters.Add(new OracleParameter("gs_recipient_f_name", cgshop.Gift_Recipient_First_Name));
            cmd.Parameters.Add(new OracleParameter("gs_recipient_l_name", cgshop.Gift_Recipient_Last_Name));
            cmd.Parameters.Add(new OracleParameter("gs_type", cgshop.Gift_Type));
            cmd.Parameters.Add(new OracleParameter("gs_desc", cgshop.Gift_Desc));

            _rows = cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();
        }

        public void Delete(GiftShopT gshop)
        {
            string command = String.Format("DELETE FROM gift_shop WHERE gift_id = :gs_id", gshop.Gift_Id);

            conn.Open();
            OracleCommand cmd = new OracleCommand(command, conn);
            cmd.Parameters.Add(new OracleParameter("gs_id", gshop.Gift_Id));

            _rows = cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();
        }

        public int Rows
        {
            get { return _rows; }
            set { _rows = value; }
        }

        public static string OracleConnString(string host, string port, string servicename, string user, string pass)
        {
            return String.Format(
              "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})" +
              "(PORT={1}))(CONNECT_DATA=(SERVICE_NAME={2})));User Id={3};Password={4};",
              host,
              port,
              servicename,
              user,
              pass);
        }
    }

}