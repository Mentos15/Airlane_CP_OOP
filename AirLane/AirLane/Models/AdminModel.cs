using AirLane.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLane.Models
{
    class AdminModel
    {

        public void Exit(MainWindow mainWindow, AdminView adminView)
        {
            adminView.Hide();
            mainWindow.ShowDialog();

        }
    }
}
