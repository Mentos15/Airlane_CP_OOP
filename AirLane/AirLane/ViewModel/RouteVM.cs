using AirLane.Command;
using AirLane.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLane.ViewModel
{
    class RouteVM : INotifyPropertyChanged
    {


        private RouteModel models;
        public RouteModel Models
        {
            get { return models; }
            set
            {
                models = value;
                OnPropertyChanged("Models");
            }

        }

        private RelayCommand addRoute;
        public RelayCommand AddRoute
        {
            get
            {
                return addRoute ??
                  (addRoute = new RelayCommand(obj =>
                  {
                     
                      models.Add();


                  }));
            }
        }

        public RouteVM()
        {
            models = new RouteModel();
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
