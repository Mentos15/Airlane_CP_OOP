using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AirLane.Models
{
    class FlightsModel : INotifyPropertyChanged
    {
        public static ObservableCollection<RouteModel> Routs { get; set; } = new ObservableCollection<RouteModel>();
        public ObservableCollection<FlightsModel> Classes { get; set; } = new ObservableCollection<FlightsModel>();



        private RouteModel _selectedRouts;
        public RouteModel SelectedRouts
        {
            get
            {
                return _selectedRouts;
            }
            set
            {
                _selectedRouts = value;
                OnPropertyChanged("SelectedRouts");
            }
        }
        private FlightsModel _selectedClass;
        public FlightsModel SelectedClass
        {
            get
            {
                return _selectedClass;
            }
            set
            {
                _selectedClass = value;
                OnPropertyChanged("SelectedClass");
            }
        }



        private DateTime _date_from=DateTime.Now;
        public DateTime date_from
        {
            get { return _date_from; }
            set
            {
                _date_from = value;
                OnPropertyChanged("date_from");

            }
        }

        private DateTime _date_to = DateTime.Now;
        public DateTime date_to
        {
            get { return _date_to; }
            set
            {
                _date_to = value;
                OnPropertyChanged("date_to");

            }
        }


      


        private int _route;
        public int route
        {
            get { return _route; }
            set
            {
                _route = value;
                OnPropertyChanged("route");
            }
        }

        private string _company;
        public string company
        {
            get { return _company; }
            set
            {
                _company = value;
                OnPropertyChanged("company");
            }
        }

        private string _aircraft;
        public string aircraft
        {
            get { return _aircraft; }
            set
            {
                _aircraft = value;
                OnPropertyChanged("aircraft");
            }
        }

        private int _count_of_customers;
        public int count_of_customers
        {
            get { return _count_of_customers; }
            set
            {
                _count_of_customers = value;
                OnPropertyChanged("count_of_customers");
            }
        }

        private string _clas;
        public string clas
        {
            get { return _clas; }
            set
            {
                _clas = value;
                OnPropertyChanged("clas");
            }
        }

        

        public void TakeAllRouts()
        {
            Classes.Add(new FlightsModel { clas = "Бизнес" });
            Classes.Add(new FlightsModel { clas = "Эконом" });

            Routs.Clear();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"select id_route,s1.town,s2.town,length_of_route from route   inner join airport s1  on s1.nameAirport = route.id_airport_from 
                 inner join  airport s2 on s2.nameAirport = route.id_airport_to";
            sqlCommand.Connection = DBConnection.DBConnection.SqlConnection;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            foreach (var i in reader)
            {
                Routs.Add(new RouteModel { IdRoute = reader.GetInt32(0) ,airport_From_To = $"{reader.GetString(1)} - {reader.GetString(2)}", length_of_route = Convert.ToString(reader.GetInt32(3)) });
            }
            reader.Close();
        }

        public int Add()
        {
            bool flag = true; // для проверки есть ли уже аткая запись
            bool aircraftFlag = false; //для првоерки есть ли такой самолет
            bool companyFlag = false;
            SqlCommand sqlCommand = new SqlCommand();


            sqlCommand.CommandText = "select * from company";
            sqlCommand.Connection = DBConnection.DBConnection.SqlConnection;
            SqlDataReader reader2 = sqlCommand.ExecuteReader();
            foreach (var i in reader2)
            {
                if (reader2.GetSqlString(0) == company)
                {
                    reader2.Close();
                    companyFlag = true;
                    break;
                }
            }
            reader2.Close();
            sqlCommand.CommandText = "select * from aircrafts";
            sqlCommand.Connection = DBConnection.DBConnection.SqlConnection;
            SqlDataReader reader3 = sqlCommand.ExecuteReader();
            foreach (var i in reader3)
            {
                if (reader3.GetSqlString(0) == aircraft)
                {
                    reader3.Close();
                    aircraftFlag = true;
                    break;
                }
            }
            reader3.Close();

            sqlCommand.CommandText = "select * from flights";
            sqlCommand.Connection = DBConnection.DBConnection.SqlConnection;
            SqlDataReader reader = sqlCommand.ExecuteReader();

            if (date_from>date_to || date_from < DateTime.Now || date_to < DateTime.Now)
            {
                MessageBox.Show("Неправильно указаны даты");
                return 1;
            }
           
            foreach (var i in reader)
            {      
                if (reader.GetSqlString(4) == company && reader.GetSqlString(5) == aircraft && reader.GetDateTime(1)==date_from && reader.GetDateTime(2)==date_to)
                {
                    MessageBox.Show("Данный рейс уже существует");
                    flag = false;
                    reader.Close();
                    break;
                }

            }

            if (!aircraftFlag)
            {
                MessageBox.Show("Данного самолета нет");
                flag = false;
            }
            if(!companyFlag)
            {
                MessageBox.Show("Компания с таким названием не найдена");
                flag = false;
            }


            if (flag)
            {
                reader.Close();
                sqlCommand.CommandText = $"insert into flights values('{date_from}','{date_to}','{SelectedRouts.IdRoute}','{company}','{aircraft}','{0}','{SelectedClass.clas}')";
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Рейс успешно добавлена");
                return 0;
            }
            return 0;
        }



        public FlightsModel(DataGrid dataGrid)
        {

        }
        public FlightsModel()
        {

        }


        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
