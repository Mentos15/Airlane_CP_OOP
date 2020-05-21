using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AirLane.Models
{
    class RouteModel : INotifyPropertyChanged
    {

        private string _airport_From_To;
        public string airport_From_To
        {
            get { return _airport_From_To; }
            set
            {
                _airport_From_To = value;
                OnPropertyChanged("airport_name_from");
            }
        }

        private int _IdRoute;
        public int IdRoute
        {
            get { return _IdRoute; }
            set
            {
                _IdRoute = value;
                OnPropertyChanged("IdRoute");
            }
        }



        private string _airport_name_from;
        public string airport_name_from
        {
            get { return _airport_name_from; }
            set
            {
                _airport_name_from = value;
                OnPropertyChanged("airport_name_from");
            }
        }

        private string _airport_name_to;
        public string airport_name_to
        {
            get { return _airport_name_to; }
            set
            {
                _airport_name_to = value;
                OnPropertyChanged("airport_name_to");
            }
        }

        private string _length_of_route;
        public string length_of_route
        {
            get { return _length_of_route; }
            set
            {
                _length_of_route = value;
                OnPropertyChanged("length_of_route");
            }
        }

        public void Add()
        {
            bool flag = true;

            CheckAllTablesModel check = new CheckAllTablesModel();

            if(check.CheckAllAirport(airport_name_from) == 1)
            {
                MessageBox.Show("Аэропорта от куда вылет с таким именем нет");
               
            }
            else if(check.CheckAllAirport(airport_name_to) == 1)
            {
                MessageBox.Show("Аэропорта куда прилет с таким именем нет");
               
            }
            else
            {
                int len;
                if (Int32.TryParse(length_of_route, out len))
                {
                    if (len < 100)
                    {
                        MessageBox.Show("маршрут слишком мал");
                        flag = false;

                    }

                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = "select * from route";
                    sqlCommand.Connection = DBConnection.DBConnection.SqlConnection;
                    SqlDataReader reader = sqlCommand.ExecuteReader();


                    foreach (var i in reader)
                    {

                        if (reader.GetSqlString(1) == airport_name_from && reader.GetSqlString(2) == airport_name_to)
                        {
                            MessageBox.Show("Данный маршрут уже существует");
                            flag = false;
                            reader.Close();
                            break;
                        }

                    }
                    if (flag)
                    {
                        reader.Close();
                        sqlCommand.CommandText = $"insert into route values('{airport_name_from}','{airport_name_to}','{length_of_route}')";
                        sqlCommand.Connection = DBConnection.DBConnection.SqlConnection;
                        sqlCommand.ExecuteNonQuery();

                        FlightsModel.Routs.Clear();
                        sqlCommand.CommandText = "select * from route";
                        sqlCommand.Connection = DBConnection.DBConnection.SqlConnection;
                        SqlDataReader reader2 = sqlCommand.ExecuteReader();
                        foreach (var i in reader2)
                        {
                            FlightsModel.Routs.Add(new RouteModel { IdRoute = reader2.GetInt32(0), airport_From_To = $"{reader2.GetString(1)} - {reader2.GetString(2)}", length_of_route = Convert.ToString(reader2.GetInt32(3)) });
                        }
                        reader.Close();
                        MessageBox.Show("Маршрут успешно добавлен");

                    }
                }
                else
                {
                    MessageBox.Show("Введенный путь не корректный");
                }
            }
            

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }

}
