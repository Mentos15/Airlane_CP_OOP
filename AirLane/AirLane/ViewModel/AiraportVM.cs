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
    class AiraportVM : INotifyPropertyChanged
    {


        private AiraportModel models;
        public AiraportModel Models
        {
            get { return models; }
            set
            {
                models = value;
                OnPropertyChanged("Models");
            }

        }

        private RelayCommand addAiraport;
        public RelayCommand AddAiraport
        {
            get
            {
                return addAiraport ??
                  (addAiraport = new RelayCommand(obj =>
                  {
                      models.Add();
                 

                  }));
            }
        }

        public AiraportVM()
        {
            models = new AiraportModel();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
