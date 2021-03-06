﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AirLane.Models
{
    class OrderModel : INotifyPropertyChanged
    {
        public static BindingList<OrderModel> allOrders = new BindingList<OrderModel>();


        private int _idTicket;
        public int IdTicket
        {
            get { return _idTicket; }
            set
            {
                _idTicket = value;
                OnPropertyChanged("IdTicket");

            }
        }

        private string _userLogName;
        public string userLogName
        {
            get { return _userLogName; }
            set
            {
                _userLogName = value;
                OnPropertyChanged("userLogName");

            }
        }

        private string _surName;
        public string surName
        {
            get { return _surName; }
            set
            {
                _surName = value;
                OnPropertyChanged("surName");
            }
        }

        private string _name;
        public string name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("name");
            }
        }
        private string _date_from;
        public string date_from
        {
            get { return _date_from; }
            set
            {
                _date_from = value;
                OnPropertyChanged("date_from");
            }
        }

        private string _date_to;
        public string date_to
        {
            get { return _date_to; }
            set
            {
                _date_to = value;
                OnPropertyChanged("date_to");
            }
        }

        private string _town_from;
        public string town_from
        {
            get { return _town_from; }
            set
            {
                _town_from = value;
                OnPropertyChanged("town_from");
            }
        }

        private string _town_to;
        public string town_to
        {
            get { return _town_to; }
            set
            {
                _town_to = value;
                OnPropertyChanged("town_to");
            }
        }

        private int _price;
        public int price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged("price");
            }
        }

        public OrderModel()
        {

        }

        public OrderModel(string UserLogName, string SurName, string Name, string dateFrom, string dateTo, string townFrom, string townTo,int Price, int idTicket )
        {
            userLogName = UserLogName;
            surName = SurName;
            name = Name;
            date_from = dateFrom;
            date_to = dateTo;
            town_from = townFrom;
            town_to = townTo;
            price = Price;
            IdTicket = idTicket;

        }
        public void Delete_click(DataGrid dataGrid)
        {
            if (dataGrid.SelectedIndex != -1)
            {
                BindingList<OrderModel> t = new BindingList<OrderModel>();
                foreach (var x in allOrders)
                {
                    t.Add(x);
                }
                
                int i = dataGrid.SelectedIndex;
                

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = $"delete from tickets where {allOrders[i].IdTicket} = tickets.id_ticket";
                sqlCommand.Connection = DBConnection.DBConnection.SqlConnection;
                sqlCommand.ExecuteNonQuery();

                allOrders.RemoveAt(i);



            }
            else
            {
                MessageBox.Show("Выберите заказ для удаления");
            }
        }

        public void ShowAllOrders(DataGrid dataGrid)
        {
            bool flag = true;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"select userLogName, Surname,Name, date_from,date_to, s1.town,s2.town, id_ticket,price from  tickets inner join users on tickets.id_customer = users.userId " +
                "inner join flights on tickets.id_flight = flights.id_flight inner join route on flights.route = route.id_route  inner join airport s1  on s1.nameAirport = route.id_airport_from " +
                " inner join  airport s2 on s2.nameAirport = route.id_airport_to";
            sqlCommand.Connection = DBConnection.DBConnection.SqlConnection;
            SqlDataReader reader = sqlCommand.ExecuteReader();

            allOrders.Clear();
            foreach (var i in reader)
            {
                allOrders.Add(new OrderModel(Convert.ToString(reader.GetSqlString(0)),Convert.ToString(reader.GetSqlString(1)), Convert.ToString(reader.GetSqlString(2)), Convert.ToString(reader.GetDateTime(3).Date).Substring(0,10), Convert.ToString(reader.GetDateTime(4).Date).Substring(0, 10), Convert.ToString(reader.GetSqlString(5)), Convert.ToString(reader.GetSqlString(6)),reader.GetInt32(8), Convert.ToInt32(reader.GetInt32(7))));
            }
            dataGrid.ItemsSource = allOrders;

            reader.Close();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
