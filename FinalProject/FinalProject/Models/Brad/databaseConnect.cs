using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;

namespace bradCampbell_FinalAssignment.Models
{
    public class databaseConnect
    {
        private const string _host = "calvin.humber.ca";
        private const string _port = "1521";
        private const string _sid = "grok";
        private const string _username = "";
        private const string _password = "";
        private static string _connectionString = OracleConnString(_host, _port, _sid, _username, _password);
        private OracleConnection conn = new OracleConnection(_connectionString);

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