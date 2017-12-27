using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProject.Models;
using Oracle.ManagedDataAccess.Client;

namespace FinalProject
{
    public partial class demo : System.Web.UI.Page
    {
        private FunctionHelper helper = new FunctionHelper();
        private CalvinDB db = new CalvinDB();
        private Panel[] uiPanelArray;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            uiPanelArray = new Panel[]
            {
                
            };
        }

        protected void lbtn_demo_query_lee_msgs_table_click (object sender, EventArgs e)
        {
            string table = "lee_msgs";
            string[] columns = {"msg_id", "msg_info", "msg_previous_owner_id", "msg_owner_id"};

            string resultString = "";

            List<string[]> resultQueryList = new List<string[]>();
            
            try
            {
                resultQueryList = db.QueryDB(columns, table);
            } catch(OracleException excep)
            {
                lbl_demo_query_msgs_table_display.Text = excep.Message;
            }

            foreach (string[] oneLineQueryArray in resultQueryList)
            {
                for (int i = 0; i < oneLineQueryArray.Length; i ++)
                {
                    resultString = resultString + oneLineQueryArray[i] + " ";
                }
                resultString += "<br />";
            }

            lbl_demo_query_msgs_table_display.Text = resultString;
        }

    }
}