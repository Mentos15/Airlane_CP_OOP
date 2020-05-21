using AirLane.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Net;

namespace AirLane.Models
{

    class LoginModel : INotifyPropertyChanged
    {
        

        private string _logname;
        public string LogName
        {
            get { return _logname; }
            set
            {
                _logname = value;
                OnPropertyChanged("LogName");
            }
        }

        private string _user_email;
        public string userMail
        {
            get { return _user_email; }
            set { _user_email = value; }
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

        public void ChangePassword(string password)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = $"update users set userPassword = '{password}' where '{LogName}'=users.userLogName";
            sqlCommand.Connection = DBConnection.DBConnection.SqlConnection;
            sqlCommand.ExecuteNonQuery();
        }

        public void Exit(MainWindow mainWindow, LoginForm loginform)
        {
            loginform.Hide();
            mainWindow.ShowDialog();

        }
        public void SendNewPassword()
        {
            
            if (LogName != null)
            {
                //Создание объекта для генерации чисел
                Random rnd = new Random();
                //Получить случайное число (в диапазоне от 0 до 10)
                string randpass = Convert.ToString(rnd.Next(10000, 99999));

                bool flag = false;
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "select * from users";
                sqlCommand.Connection = DBConnection.DBConnection.SqlConnection;
                SqlDataReader reader = sqlCommand.ExecuteReader();

                foreach (var i in reader)
                {
                    if (reader.GetSqlString(1) == LogName)
                    {
                        userMail = Convert.ToString(reader.GetSqlString(4));
                        flag = true;
                    }

                }
                reader.Close();
                if (flag)
                {
                    try
                    {
                        // отправитель - устанавливаем адрес и отображаемое в письме имя
                        MailAddress from = new MailAddress("mentos1510@gmail.com", "Airlane");
                        // кому отправляем
                        MailAddress to = new MailAddress($"{userMail}");
                        // создаем объект сообщения
                        MailMessage m = new MailMessage(from, to);
                        // тема письма
                        m.Subject = "Ваш временный пароль";
                        // текст письма
                        m.Body = $"<h1>{randpass}</h1>";
                        m.IsBodyHtml = true;

                        // адрес smtp-сервера и порт, с которого будем отправлять письмо
                        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                        // логин и пароль
                        smtp.Credentials = new NetworkCredential("mentos1510@gmail.com", "vital2014");
                        smtp.EnableSsl = true;
                        smtp.Send(m);
                        
                        sqlCommand.CommandText = $"update users set userPassword = '{GetHashString(randpass)}' where '{LogName}'=users.userLogName";
                        sqlCommand.Connection = DBConnection.DBConnection.SqlConnection;
                        sqlCommand.ExecuteNonQuery();

                        MessageBox.Show("Сообщение отправлено на почту");
                    }
                    catch
                    {
                    MessageBox.Show("Какие то проблеммы с соединением");
                    }
                }
                else
                    MessageBox.Show("Пользователь с атким именем не найден");
            }
            else
                MessageBox.Show("Введите ваш логин в поле");
        }
        public int Check(string password)
        {
            bool flag = true;

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "select * from users";
            sqlCommand.Connection = DBConnection.DBConnection.SqlConnection;
            SqlDataReader reader = sqlCommand.ExecuteReader();

            foreach (var i in reader)
            {
                if (reader.GetSqlString(1) == LogName)
                {

                    if(reader.GetSqlString(2) == password)
                    {
                        if (reader.GetSqlInt32(5) == 0)
                        {
                            TicketsModel.IdUser = reader.GetInt32(0);
                            UpdatePasswordModel.IdUser = reader.GetInt32(0);
                            HistoryModel.UserId = reader.GetInt32(0);
                            reader.Close();
                            return 0;
                        }
                        else
                        {
                            
                            reader.Close();
                            return 1;
                        }
                    }

                }

            }
            reader.Close();
            return 3;

        }
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
