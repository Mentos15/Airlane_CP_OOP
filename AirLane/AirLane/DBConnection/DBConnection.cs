using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLane.DBConnection
{
    class DBConnection
    {
        private static DBConnection instance;
        public static SqlConnection SqlConnection { get; private set; }
        private DBConnection()
        {
            SqlConnection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=CP;Integrated Security=True");
            SqlConnection.Open();
        }
        public static DBConnection getInstance()
        {
            if (instance == null)
                instance = new DBConnection();
            return instance;
        }
        public static void Close()
        {
            if (SqlConnection.State == System.Data.ConnectionState.Open)
                SqlConnection.Close();
        }
    }
}
