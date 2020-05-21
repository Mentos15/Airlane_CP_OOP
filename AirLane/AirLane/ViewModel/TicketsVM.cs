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
    class TicketsVM : INotifyPropertyChanged
    {

        private DataGrid _dataGrid;

        private TicketsModel models;
        public TicketsModel Models
        {
            get { return models; }
            set
            {
                models = value;
                OnPropertyChanged("Models");
            }

        }

        private RelayCommand bueTicket;
        public RelayCommand BuyTicket
        {
            get
            {
                return bueTicket ??
                  (bueTicket = new RelayCommand(obj =>
                  {


                      models.BuyTiket();

                  }));
            }
        }
        private RelayCommand _search;
        public RelayCommand Search
        {
            get
            {
                return _search ??
                  (_search = new RelayCommand(obj =>
                  {


                      models.SearchFlight(_dataGrid);

                  }));
            }
        }

        private RelayCommand _reset;
        public RelayCommand Reset
        {
            get
            {
                return _reset ??
                  (_reset = new RelayCommand(obj =>
                  {


                      models.ShowAllFlights(_dataGrid);

                  }));
            }
        }

        public TicketsVM(DataGrid dataGrid)
        {
            models = new TicketsModel();
            _dataGrid = dataGrid;
            models.ShowAllFlights(dataGrid);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
