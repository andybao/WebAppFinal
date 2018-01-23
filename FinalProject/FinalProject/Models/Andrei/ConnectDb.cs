using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;

namespace Final_Project_C_Sharp.Models
{
    public class ConnectDb
    {
        // Andrei Navumau "N01262150";
        // Andy Bao "N01257490";
        public static string username = "";
        public static string connectionString = String.Format(
            "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})" +
            "(PORT={1}))(CONNECT_DATA=(SERVICE_NAME={2})));User Id={3};Password={4};"
            , "calvin.humber.ca" // host
            , 1521 // port
            , "grok" // service name
            , username
            , "" // password
            );

        // Methods
        
    }
}