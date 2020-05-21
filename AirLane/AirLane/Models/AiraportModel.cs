using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AirLane.Models
{
    class AiraportModel : INotifyPropertyChanged
    {
        private string _nameAirport;
        public string nameAirport
        {
            get { return _nameAirport; }
            set
            {
                _nameAirport = value;
                OnPropertyChanged("nameAirport");

            }
        }

        private string _country;
        public string country
        {
            get { return _country; }
            set
            {
                _country = value;
                OnPropertyChanged("country");
            }
        }

        private string _town;
        public string town
        {
            get { return _town; }
            set
            {
                _town = value;
                OnPropertyChanged("town");
            }
        }

        public void Add()
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
                    MessageBox.Show("Данный аэропорт уже существует");
                    flag = false;
                    reader.Close();
                    break;
                }

            }
            if (flag)
            {
                reader.Close();
                sqlCommand.CommandText = $"insert into airport values('{nameAirport}','{country}','{town}')";
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Аэропорт успешно добавлен");

            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
