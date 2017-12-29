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
        private FunctionHelper helper;
        private Label[] labelArray;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            helper = new FunctionHelper(lbl_demo_db_error_msg_display_);

            labelArray = new Label[]
            {
                lbl_demo_db_error_msg_display_,
                lbl_demo_query_all_columns_from_a_table_display_,
                lbl_demo_query_columns_by_where_clause_display_,
                lbl_demo_query_columns_by_keyword_display_,
                lbl_demo_query_one_column_by_its_name_display_,
                lbl_demo_insert_one_item_display_,
                lbtn_demo_update_one_item_display_,
                lbl_demo_delete_one_item_display_
            };

        }

        protected void lbtn_demo_query_all_columns_from_a_table_click(object sender, EventArgs e)
        {
            string table = "lee_msgs";

            string resultString = "";

            List<string[]> resultQueryList = helper.getAllColumnsFromATable(table);
            
            resultString = helper.generateResultString(resultQueryList);
            lbl_demo_query_all_columns_from_a_table_display_.Text = resultString;
        }

        protected void lbtn_demo_query_columns_by_where_clause_click(object sender, EventArgs e)
        {
            string table = "lee_jobs";
            string resultString = "";

            Dictionary<string, string> whereClause = new Dictionary<string, string>();
            whereClause.Add("job_type", "VOLUNTEER");

            List<string[]> resultQueryList = helper.getColumnsValueByWhereClause(table, whereClause);

            resultString = helper.generateResultString(resultQueryList);
            lbl_demo_query_columns_by_where_clause_display_.Text = resultString;
        }

        protected void lbtn_demo_query_columns_by_keyword_click(object sender, EventArgs e)
        {
            string table = "lee_jobs";
            string column = "job_info";
            string keyWord = "operation";
            string resultString = "";

            List<string[]> resultQueryList = helper.getItemAndIDByKeyword(column, table, keyWord);

            resultString = helper.generateResultString(resultQueryList);

            lbl_demo_query_columns_by_keyword_display_.Text = resultString;
           
        }        

        protected void lbtn_demo_query_one_column_by_its_name_click(object sender, EventArgs e)
        {
            string table = "lee_jobs";
            string column = "job_title";
            string resultString = "";

            List<string[]> resultQueryList = helper.getColumnValue(column, table);

            resultString = helper.generateResultString(resultQueryList);

            lbl_demo_query_one_column_by_its_name_display_.Text = resultString;
        }

        protected void lbtn_demo_insert_one_item_click(object sender, EventArgs e)
        {
            string table = "lee_msgs";
            int resultCount;
            Dictionary<string, string> item = new Dictionary<string, string>();
            item.Add("msg_id", "12");
            item.Add("msg_info", "msg from insert demo");
            item.Add("msg_previous_owner_id", "-1");
            item.Add("msg_owner_id", "4");

            resultCount = helper.insertOneItem(table, item);

            if (resultCount == 1)
            {
                lbl_demo_insert_one_item_display_.Text = "Insert success, you can verify it from demo 1";
            } else
            {
                lbl_demo_insert_one_item_display_.Text = "Error";
                lbl_demo_insert_one_item_display_.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lbtn_demo_update_one_item_click(object sender, EventArgs e)
        {
            string table = "lee_msgs";
            int resultCount;

            Dictionary<string, string> item = new Dictionary<string, string>();
            item.Add("msg_info", "msg_from_update_demo");

            Dictionary<string, string> whereClause = new Dictionary<string, string>();
            whereClause.Add("msg_id", "12");

            resultCount = helper.updateOneItem(table, item, whereClause);

            if (resultCount == 1)
            {
                lbtn_demo_update_one_item_display_.Text = "Update success, you can verify it from demo 1";
            } else
            {
                lbtn_demo_update_one_item_display_.Text = "Error";
                lbtn_demo_update_one_item_display_.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lbtn_demo_delete_one_item_click(object sender, EventArgs e)
        {
            string table = "lee_msgs";
            int resultCount;

            Dictionary<string, string> whereClause = new Dictionary<string, string>();
            whereClause.Add("msg_id", "12");

            resultCount = helper.deleteOneItem(table, whereClause);
            
            if (resultCount == 1)
            {
                lbl_demo_delete_one_item_display_.Text = "Delete success, you can verify it from demo 1";
            } else
            {
                lbl_demo_delete_one_item_display_.Text = "Error";
                lbl_demo_delete_one_item_display_.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lbtn_demo_hide_click(object sender, EventArgs e)
        {
            initLabelArrayMsg();
        }

        private void initLabelArrayMsg()
        {
            foreach (var i in labelArray)
            {
                i.Text = "";
                i.ForeColor = System.Drawing.Color.Black;
            }
        }

    }
}