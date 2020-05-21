using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AirLane.Models
{
    class CheckAllTablesModel
    {
        public int CheckAllAirport(string nameAirport)
        {
            bool flag = true;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "select * from airport";
            sqlCommand.Connection = DBConnection.DBConnection.SqlConnection;
            SqlDataReader reader = sqlCommand.ExecuteReader();



            foreach (var i in reader)
            {
                if (reader.GetSqlString(0) == nameAirport)
                {   
                    flag = false;
                    break;   
                }

            }
            if(flag)
            {
                reader.Close();
                return 1;
            }
            reader.Close();
            return 0;

        }

        public int CheckAllRoute(string nameAirport)
        {
            bool flag = true;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "select * from airport";
            sqlCommand.Connection = DBConnection.DBConnection.SqlConnection;
            SqlDataReader reader = sqlCommand.ExecuteReader();



            foreach (var i in reader)
            {
                if (reader.GetSqlString(0) == nameAirport)
                {
                    flag = false;
                    break;
                }

            }
            if (flag)
            {
                reader.Close();
                return 1;
            }
            reader.Close();
            return 0;

        }


    }
}
