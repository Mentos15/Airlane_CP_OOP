using AirLane.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLane.Models
{
    class UserModel
    {

        public void Exit(MainWindow mainWindow, UserView userView)
        {
            userView.Hide();
            mainWindow.ShowDialog();

        }
    }
}
