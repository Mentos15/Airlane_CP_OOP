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
    class CompanyModel : INotifyPropertyChanged
    {

        private string _company_name;
        public string company_name
        {
            get { return _company_name; }
            set
            {
                _company_name = value;
                OnPropertyChanged("company_name");

            }
        }

        private string _cost_of_1km;
        public string cost_of_1km
        {
            get { return _cost_of_1km; }
            set
            {
                _cost_of_1km = value;
                OnPropertyChanged("cost_of_1km");
            }
        }

        private string _cost_of_business;
        public string cost_of_business
        {
            get { return _cost_of_business; }
            set
            {
                _cost_of_business = value;
                OnPropertyChanged("cost_of_business");
            }
        }

        private string _cost_of_econom;
        public string cost_of_econom
        {
            get { return _cost_of_econom; }
            set
            {
                _cost_of_econom = value;
                OnPropertyChanged("cost_of_econom");
            }
        }

        public void Add()
        {
            int price;

            if (Int32.TryParse(cost_of_1km , out price) && Int32.TryParse(cost_of_business, out price) && Int32.TryParse(cost_of_econom, out price))
            {


                bool flag = true;
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "select * from company";
                sqlCommand.Connection = DBConnection.DBConnection.SqlConnection;
                SqlDataReader reader = sqlCommand.ExecuteReader();



                foreach (var i in reader)
                {
                    if (reader.GetSqlString(0) == company_name)
                    {
                        MessageBox.Show("Данное имя компании уже занято");
                        flag = false;
                        reader.Close();
                        break;
                    }

                }
                if (flag)
                {
                    reader.Close();
                    sqlCommand.CommandText = $"insert into company values('{company_name}','{Convert.ToInt32(cost_of_1km)}','{Convert.ToInt32(cost_of_business)}','{Convert.ToInt32(cost_of_econom)}')";
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Компания успешно добавлена");

                }
            }
            else
            {
                MessageBox.Show("Введены не корректные данные");
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
