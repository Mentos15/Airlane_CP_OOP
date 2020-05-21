using AirLane.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirLane.Models;
using System.Windows.Controls;

namespace AirLane.ViewModel
{
    class OrdersVM : INotifyPropertyChanged
    {

        private DataGrid _dataGrid;

        private OrderModel models;
        public OrderModel Models
        {
            get { return models; }
            set
            {
                models = value;
                OnPropertyChanged("Models");
            }

        }
        private RelayCommand _deleteOrder;
        public RelayCommand DeleteOrder
        {
            get
            {
                return _deleteOrder ??
                  (_deleteOrder = new RelayCommand(obj =>
                  {
                      models.Delete_click(_dataGrid);


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


                      models.ShowAllOrders(_dataGrid);

                  }));
            }
        }

        public OrdersVM(DataGrid dataGrid)
        {
            models = new OrderModel();
            models.ShowAllOrders(dataGrid);
            _dataGrid = dataGrid;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
