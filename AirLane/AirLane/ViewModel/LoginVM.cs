using AirLane.Command;
using AirLane.Models;
using AirLane.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AirLane.ViewModel
{
    class LoginVM : INotifyPropertyChanged
    {
        private MainWindow _mainWindow;
        private LoginForm _loginform;


        private LoginModel log;
        public LoginModel Log
        {
            get { return log; }
            set
            {
                log = value;
                OnPropertyChanged("Log");
            }

        }

        private RelayCommand _exit;
        public RelayCommand Exit
        {
            get
            {
                return _exit ??
                  (_exit = new RelayCommand(obj =>
                  {


                      log.Exit(_mainWindow, _loginform);

                      

                  }));
            }
        }




        private RelayCommand _sendPassword;
        public RelayCommand SendPassword
        {
            get
            {
                return _sendPassword ??
                  (_sendPassword = new RelayCommand(obj =>
                  {
                      log.SendNewPassword();
                  }));
            }
        }

        private RelayCommand login;
        public RelayCommand Login
        {
            get
            {
                return login ??
                  (login = new RelayCommand(obj =>
                  {
                      
                      var passwordBox = obj as PasswordBox;
                      string passwordEnter = log.GetHashString(passwordBox.Password);

                      if (log.Check(passwordEnter) == 0)
                      {
                          UserView userView = new UserView(_mainWindow);
                          _loginform.Hide();
                          userView.ShowDialog();
                      }
                      else if(log.Check(passwordEnter) == 1)
                      {
                          AdminView adminView = new AdminView(_mainWindow);
                          _loginform.Hide();
                          adminView.ShowDialog();
                      }
                      else
                      {                      
                              MessageBox.Show("Неверно введен логи или пароль!");
                      }

                  }));
            }
        }
        public LoginVM( LoginForm loginForm, MainWindow mainWindow)
        {
            _loginform = loginForm;
            _mainWindow = mainWindow;
            log = new LoginModel();
        }
        public LoginVM()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
