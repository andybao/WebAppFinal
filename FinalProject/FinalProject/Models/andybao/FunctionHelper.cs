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

        private const string TABLE_PERSONS = "persons";
        private const string TABLE_SURVEYS = "surveys";

        private string[] COLUMNS_SURVEYS = new string[]
        {
        "question_id",
        "question_text",
        "question_answer_yes",
        "question_answer_no",
        "question_answer_not_sure",
        "question_admin_id"
        };

        private string[] COLUMNS_PERSONS = new string[]
        {
            "person_id",
            "person_last_name",
            "person_first_name",
            "person_status",
            "person_pw"
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

        public List<string[]> getAllColumnsValueFromATable(string table)
        {
            return getColumnsValueByWhereClause(table, null);
        }

        public List<string[]> getColumnsValueByWhereClause(string table, Dictionary<string, string> whereClause)
        {
            List<string[]> resultList = new List<string[]>();
            string[] columns;

            switch (table)
            {
                case TABLE_PERSONS:
                    columns = COLUMNS_PERSONS;
                    break;
                case TABLE_SURVEYS:
                    columns = COLUMNS_SURVEYS;
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

        public int dbDuplicateValueCheck(string column, string table, string value)
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