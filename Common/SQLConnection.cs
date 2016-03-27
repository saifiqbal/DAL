using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreBusiness;
using System.Configuration;
using DAL;
using System.Data.SqlClient;

/*
 * Created By Saifullah Iqbal
 * Dated : June 20 2014
 * Purpose: To Open and Close Sql Connection Explicitly 
 * Summary: Open Connection before using datareader etc and Close connection when datareader etc done its work.
 */

namespace DAL
{
    public class mySQLConnection
    {
        public static SqlConnection Open()
        {
            return SqlHelper.OpenSqlConnection(GetConnectionString());
        }

        public static bool SqlConnectionState(SqlConnection connection)
        {
            return SqlHelper.SqlConnectionState(connection);
        }

        public static void Close(SqlConnection connection)
        {
            SqlHelper.CloseSqlConnection(connection);
        }

        public static string GetConnectionString()
        {
            string strConnection;
            strConnection = System.Configuration.ConfigurationManager.ConnectionStrings["C2R3"].ConnectionString.ToString();
            return strConnection;
        }
    }
}
