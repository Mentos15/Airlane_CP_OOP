  using System;
using AirLane;
using AirLane.DBConnection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using AirLane.View;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Net;

namespace AirLane.Models
{
    class RegFormModel : INotifyPropertyChanged
    {
        private string EmailCode;
        
        public int userId { get; set; }

        private string _user_log_name;
        public string userLogName
        {
            get { return _user_log_name; }
            set
            {
                _user_log_name = value;
                OnPropertyChanged("userLogName");

            }
        }
        
        public int count_of_orders { get; set; }

        private string _user_email;
        public string userMail
        {
            get { return _user_email; }
            set
            {
                _user_email = value;
                OnPropertyChanged("userMail");
            }
        }

        public int bit { get; set; }

        private string _code;
        public string Code
        {
            get { return _code; }
            set
            {
                _code = value;
                OnPropertyChanged("Code");
            }
        }


        public string GetHashString(string s)
        {
            //переводим строку в байт-массим  
            byte[] bytes = Encoding.Unicode.GetBytes(s);

            //создаем объект для получения средст шифрования  
            MD5CryptoServiceProvider CSP =
                new MD5CryptoServiceProvider();

            //вычисляем хеш-представление в байтах  
            byte[] byteHash = CSP.ComputeHash(bytes);

            string hash = string.Empty;

            //формируем одну цельную строку из массива  
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            return hash;
        }
        public void SendCode()
        {
            if (userMail != null)
            {
                //Создание объекта для генерации чисел
                Random rnd = new Random();
                //Получить случайное число (в диапазоне от 0 до 10)
                EmailCode =Convert.ToString(rnd.Next(10000, 99999));

                try
                {
                    // отправитель - устанавливаем адрес и отображаемое в письме имя
                    MailAddress from = new MailAddress("mentos1510@gmail.com", "Airlane");
                    // кому отправляем
                    MailAddress to = new MailAddress($"{userMail}");
                    // создаем объект сообщения
                    MailMessage m = new MailMessage(from, to);
                    // тема письма
                    m.Subject = "Код авторизации";
                    // текст письма
                    m.Body = $"<h1>{EmailCode}</h1>";
                    m.IsBodyHtml = true;

                    // адрес smtp-сервера и порт, с которого будем отправлять письмо
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    // логин и пароль
                    smtp.Credentials = new NetworkCredential("mentos1510@gmail.com", "vital2014");
                    smtp.EnableSsl = true;
                    smtp.Send(m);
                    MessageBox.Show("Сообщение отправлено на почту");
                }
                catch
                {
                    MessageBox.Show("Какие то проблеммы с соединением");
                }
            }
            else
                MessageBox.Show("Запоните поле Email");
            
            
           
        }
    
        public void Exit(MainWindow mainWindow, RegistrationForm regform)
        {
                regform.Hide();
                mainWindow.ShowDialog();
            
        }
        public void Add(string password, RegistrationForm regform, MainWindow mainWindow)
        {
           
                if (Code == EmailCode)
                {

                    if (userLogName == null || password == null || userMail == null)
                    {
                    MessageBox.Show("Заполните все поля!");
                    }
                    else
                    {
                        bool flag = true;
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.CommandText = "select * from users";
                        sqlCommand.Connection = DBConnection.DBConnection.SqlConnection;
                        SqlDataReader reader = sqlCommand.ExecuteReader();



                        foreach (var i in reader)
                        {
                            if (reader.GetSqlString(1) == userLogName)
                            {
                                MessageBox.Show("Данный логин уже занят");
                                flag = false;
                                reader.Close();
                                break;
                            }

                        }
                        if (flag)
                        {
                            reader.Close();
                            sqlCommand.CommandText = $"insert into users values('{userLogName}','{password}',{count_of_orders},'{userMail}',{bit})";
                            sqlCommand.ExecuteNonQuery();
                            regform.Hide();
                            mainWindow.Show();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Неверный код, попробуйте еще раз или другую почту");
                }
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
