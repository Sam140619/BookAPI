using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.DataBase
{
    public class Connection
    {
        private static SqlConnection conn = null;

        public static string ConnectionString = null;

        public static SqlConnection GetConnection()
        {
            if (conn == null)
            {
                conn = new SqlConnection(ConnectionString);
            }

            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();

            return conn;
        }

        public static void CloseConnection()
        {
            conn.Close();
            conn.Dispose();
        }
    }
}

