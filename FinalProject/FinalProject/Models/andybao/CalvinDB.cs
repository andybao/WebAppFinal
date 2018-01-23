using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;

namespace FinalProject.Models
{
    public class CalvinDB
    {
        private const string host = OracleCredentials.host;
        private const string port = OracleCredentials.port;
        private const string sid = OracleCredentials.sid;
        private const string user = OracleCredentials.username;
        private const string pw = OracleCredentials.password;

        private static OracleConnection conn = new OracleConnection(OracleConnString(host, port, sid, user, pw));

        private Label errorDisplayHtmlLabel;

        public CalvinDB(Label htmlLabel)
        {
            errorDisplayHtmlLabel = htmlLabel;
        }

        public int DeleteDB(string table, Dictionary<string, string> whereClause)
        {
            int rows = -1;

            string command = "DELETE FROM " + table + " WHERE ";

            foreach (var i in whereClause)
            {
                command += i.Key + " = " + i.Value;
            }

            OracleCommand cmd = new OracleCommand(command, conn);

            try
            {
                conn.Open();                
                
                rows = cmd.ExecuteNonQuery();

            } catch (OracleException excep)
            {
                oracleExceptionHandle(excep);
            } finally
            {
                conn.Close();
            }

            return rows;
        }
        
        public int UpdateDB(string table, Dictionary<string, string> updateItem, Dictionary<string, string> whereClause)
        {
            int rows = 0;

            string command = "UPDATE " + table + " SET ";

            foreach (var i in updateItem)
            {
                command += i.Key + " = :" + i.Key + " ";
                if (!i.Key.Equals(updateItem.Last().Key))
                {
                    command += ",";
                }
            }

            command += "WHERE ";

            foreach (var i in whereClause)
            {
                command += i.Key + " = :" + i.Key;
            }

            OracleCommand cmd = new OracleCommand(command, conn);
            
            foreach (var i in updateItem)
            {
                cmd.Parameters.Add(new OracleParameter(i.Key, i.Value));
            }

            foreach (var i in whereClause)
            {
                cmd.Parameters.Add(new OracleParameter(i.Key, i.Value));
            }

            try
            {
                conn.Open();                
                
                rows = cmd.ExecuteNonQuery();

            } catch (OracleException excep)
            {
                oracleExceptionHandle(excep);
            } finally
            {
                conn.Close();
            }

            return rows;
            
        }

        public int InsertDB(string table, Dictionary<string, string> insertItem)
        {

            int rows = 0;

            string command = "INSERT INTO " + table + " (";

            foreach (var i in insertItem)
            {
                command += i.Key;
                if (i.Key.Equals(insertItem.Last().Key))
                {
                    command += ")";
                } else
                {
                    command += ", ";
                }
            }
            command += " VALUES (";

            foreach (var i in insertItem)
            {
                command += ":" + i.Key; 
                if (i.Key.Equals(insertItem.Last().Key))
                {
                    command += ")";
                } else
                {
                    command += ", ";
                }
            }
            OracleCommand cmd = new OracleCommand(command, conn);
            foreach (var i in insertItem)
            {
                cmd.Parameters.Add(new OracleParameter(i.Key, i.Value));
            }

            try
            {
                conn.Open();                
                
                rows = cmd.ExecuteNonQuery();

            } catch (OracleException excep)
            {
                oracleExceptionHandle(excep);
            } finally
            {
                conn.Close();
            }

            return rows;
        }

        public int QueryDB(string table)
        {
            return QueryDB(table, null);
        }

        public int QueryDB(string table, Dictionary<string, string> whereClause)
        {
            int resultInt = 0;
            string[] columns = { "COUNT(*)" };
            List<string[]> queryResultList = new List<string[]>();

            try
            {
                queryResultList = QueryDB(columns, table, whereClause);
            } catch (OracleException excep)
            {
                oracleExceptionHandle(excep);
            }

            return resultInt = Convert.ToInt32(queryResultList[0][0]);
        }

        public List<string[]> QueryDB(string column, string table, string keyWord)
        {
            string[] splitArray = column.Split(new char[] { '_' });
            string id = splitArray[0] + "_id";

            string[] columns = new string[] {id, column};
            List<string[]> resultList = new List<string[]>();

            List<string[]> tempQueryResult = QueryDB(columns, table);

            foreach (var i in tempQueryResult)
            {
                if (i[1].Equals(keyWord))
                {
                    resultList.Add(i);
                }
            }

            return resultList;
        }

        public List<string[]> QueryDB(string[] columns, string table)
        {
            return QueryDB(columns, table, null);
        }

        public List<string[]> QueryDB(string[] columns, string table, Dictionary<string, string> whereClause)
        {
            List<string[]> queryResultList = new List<string[]>();
            
            string queryString = "SELECT ";

            for (int i = 0; i < columns.Length; i ++)
            {
                queryString = queryString + columns[i];
                if (i < columns.Length - 1)
                {
                    queryString += ",";
                }
            }

            queryString = queryString + " FROM " + table;

            if (whereClause != null)
            {
                foreach (var item in whereClause)
                queryString = queryString + " WHERE " + item.Key + "='" + item.Value + "'";
            }

            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand(queryString, conn);
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string[] oneLineArray = new string[columns.Length];

                    for (int i = 0; i < columns.Length; i ++)
                    {
                        oneLineArray[i] = reader[columns[i]].ToString();
                    }
                    queryResultList.Add(oneLineArray);
                }
                reader.Close();
                
            } catch (OracleException excep)
            {
                oracleExceptionHandle(excep);
                
            } finally
            {                
                conn.Close();
            }
            
            return queryResultList;
        }

        private Dictionary<string, string> getTableDataType(string table)
        {
            Dictionary<string, string> dataTypeDict = new Dictionary<string, string>();
            string command = "SELECT column_name, data_type FROM all_tab_columns WHERE table_name='"
                            + table.ToUpper() + "'";

            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand(command, conn);
                OracleDataReader reader = cmd.ExecuteReader(); 
                while (reader.Read())
                {
                    dataTypeDict.Add(reader["column_name"].ToString(), reader["data_type"].ToString());
                }
                reader.Close();
            } catch (OracleException excep)
            {
                oracleExceptionHandle(excep);
            } finally
            {
                conn.Close();
            }
            return dataTypeDict;
        }

        private void oracleExceptionHandle(OracleException excep)
        {
            if (errorDisplayHtmlLabel != null)
            {
                errorDisplayHtmlLabel.Text = excep.Message;
                errorDisplayHtmlLabel.Visible = true;
                errorDisplayHtmlLabel.ForeColor = System.Drawing.Color.Red;
            }
        }

        private static string OracleConnString(string host, string port, string servicename, string user, string pass)
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