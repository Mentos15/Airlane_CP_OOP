using AirLane.Command;
using AirLane.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AirLane.ViewModel
{
    class FlightsVM : INotifyPropertyChanged
    {
        

        private FlightsModel models;
        public FlightsModel Models
        {
            get { return models; }
            set
            {
                models = value;
                OnPropertyChanged("Models");
            }

        }

        private RelayCommand addFlights;
        public RelayCommand AddFlights
        {
            get
            {
                return addFlights ??
                  (addFlights = new RelayCommand(obj =>
                  {
                      
                      models.Add();

                  }));
            }
        }
        public FlightsVM()
        {
            models = new FlightsModel();
            models.TakeAllRouts();
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
