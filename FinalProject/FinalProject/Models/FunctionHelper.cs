using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;

namespace FinalProject.Models
{
    public class FunctionHelper
    {
        private const string NULL_VALUE_ERROR_MSG = "value cannot be null";

        private const string TABLE_LEE_PERSONS = "lee_persons";
        private const string TABLE_LEE_JOBS = "lee_jobs";
        private const string TABLE_LEE_GIFTS = "lee_gifts";
        private const string TABLE_LEE_MSGS = "lee_msgs";

        private string[] COLUMNS_LEE_PERSONS = new string[]
        {
            "person_id",
            "person_last_name",
            "person_first_name",
            "person_status",
            "person_phone",
            "person_address",
            "person_city",
            "person_state",
            "person_zip_code",
            "person_email",
            "person_balance",
            "person_password",
            "person_applied_job_id"
        };
        private string[] COLUMNS_LEE_JOBS = new string[]
        {
            "job_id",
            "job_type",
            "job_title",
            "job_info",
            "job_start_date",
            "job_end_date",
            "job_location",
            "job_salary",
            "job_contacts_id"
        };
        private string[] COLUMNS_LEE_GIFTS = new string[]
        {
            "gift_id",
            "gift_type",
            "gift_info",
            "gift_price",
            "gift_previous_owner_id",
            "gift_owner_id"
        };
        private string[] COLUMNS_LEE_MSGS = new string[]
        {
            "msg_id",
            "msg_info",
            "msg_previous_owner_id",
            "msg_owner_id"
        };
        private CalvinDB db;

        public FunctionHelper(Label dbErrorMsgHTMLLabel)
        {
            db = new CalvinDB(dbErrorMsgHTMLLabel);
        }

        public int deleteOneItem(string table, Dictionary<string, string> whereClause)
        {
            return db.DeleteDB(table, whereClause);
        }

        public int updateOneItem(string table, Dictionary<string, string> item, Dictionary<string, string> whereClause)
        {
            return db.UpdateDB(table, item, whereClause);
        }

        public int insertOneItem(string table, Dictionary<string, string> item)
        {
            return db.InsertDB(table, item);
        }

        public List<string[]> getItemAndIDByKeyword(string column, string table, string keyword)
        {
            List<string[]> resultList = db.QueryDB(column, table, keyword);

            return resultList;
        }

        public List<string[]> getAllColumnsFromATable(string table)
        {
            return getColumnsValueByWhereClause(table, null);
        }

        public List<string[]> getColumnsValueByWhereClause(string table, Dictionary<string, string> whereClause)
        {
            List<string[]> resultList = new List<string[]>();
            string[] columns;

            switch (table)
            {
                case TABLE_LEE_PERSONS:
                    columns = COLUMNS_LEE_PERSONS;
                    break;
                case TABLE_LEE_JOBS:
                    columns = COLUMNS_LEE_JOBS;
                    break;
                case TABLE_LEE_GIFTS:
                    columns = COLUMNS_LEE_GIFTS;
                    break;
                case TABLE_LEE_MSGS:
                    columns = COLUMNS_LEE_MSGS;
                    break;
                default:
                    columns = null;
                    break;
            }

            resultList = db.QueryDB(columns, table, whereClause);

            return resultList;
        }

        public List<string[]> getColumnValue(string column, string table)
        {
            List<string[]> resultQueryList = new List<string[]>();
            string[] columns = new string[] { column };

            resultQueryList = db.QueryDB(columns, table);
            /*
            string[] resultArray = new string[tempResultQueryList.Count];

            int j = 0;
            foreach(var i in tempResultQueryList)
            {
                resultArray[j] = i[0];
                j++;
            }*/

            return resultQueryList;
        }

        public int dbDuplicateValueCheck(string column, string table, string value, Label htmlLabel)
        {
            List<string[]> queryResultList = new List<string[]>();

            queryResultList = db.QueryDB(column, table, value);

            return queryResultList.Count;
            
        }

        public bool nullValueCheck(string value, Label htmlLabel)
        {
            if (htmlLabel != null && string.IsNullOrWhiteSpace(value))
            {
                displayErrorMsg(htmlLabel, NULL_VALUE_ERROR_MSG);
            }
            return string.IsNullOrWhiteSpace(value);
        }

        public string generateResultString(List<string[]> queryList)
        {
            string resultString = "";

            foreach (var i in queryList)
            {
                for (int j = 0; j < i.Length; j ++)
                {
                    resultString += i[j] + " ";
                }
                resultString += "<br />";
            }

            return resultString;
        }

        private void changeLabelTextToRed (Label htmlLabel)
        {
            htmlLabel.ForeColor = System.Drawing.Color.Red;
        }

        private void displayErrorMsg (Label htmlLabel, string errorMsg)
        {
            htmlLabel.Text = errorMsg;
            htmlLabel.Visible = true;
            changeLabelTextToRed(htmlLabel);
        }
                
    }
}