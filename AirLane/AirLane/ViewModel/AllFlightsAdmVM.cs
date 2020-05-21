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
    class AllFlightsAdmVM : INotifyPropertyChanged
    {
        private DataGrid _dataGrid;

        private AllFlightsAdmModel models;
        public AllFlightsAdmModel Models
        {
            get { return models; }
            set
            {
                models = value;
                OnPropertyChanged("Models");
            }

        }


        private RelayCommand _delete;
        public RelayCommand Delete
        {
            get
            {
                return _delete ??
                  (_delete = new RelayCommand(obj =>
                  {


                      models.Delete(_dataGrid);

                  }));
            }
        }

        private RelayCommand reload;
        public RelayCommand Reload
        {
            get
            {
                return reload ??
                  (reload = new RelayCommand(obj =>
                  {


                      models.ShowAllFlights(_dataGrid);

                  }));
            }
        }

        public AllFlightsAdmVM(DataGrid dataGrid)
        {
            _dataGrid = dataGrid;
            models = new AllFlightsAdmModel(dataGrid);
            models.ShowAllFlights(dataGrid);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
