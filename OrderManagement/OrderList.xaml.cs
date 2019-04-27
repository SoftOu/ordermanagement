using log4net;
using OrderManagement.DataLayer.Services;
using OrderManagement.DataLayer.Services.Interface;
using OrderManagement.Models;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;

namespace OrderManagement
{
    /// <summary>
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderList : Window
    {
        private readonly ILog log = LogManager.GetLogger("Order");
        public IOrderService _orderService;
        /// <summary>
        /// Order window constructor.
        /// </summary>
        public OrderList()
        {
            log4net.Config.XmlConfigurator.Configure();
            _orderService = new OrderService();
            InitializeComponent();
            if (gridOrder.IsLoaded == false)
            {
                gridOrder.ShowLoadingPanel = true;
            }
        }

        /// <summary>
        /// Bind order and display data on screen.
        /// </summary>
        private void BindOrders()
        {
            try
            {
                log.Info("Calling BindOrders...");
                Thread t = new Thread(() =>
                {
                    gridOrder.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() =>
                    {
                        gridOrder.ItemsSource = _orderService.GetOrders();
                    }));
                });
                t.Start();
            }
            catch (Exception e)
            {
                log.ErrorFormat("Error in binding orders. Error : {0}", e.Message);
                MessageBox.Show(e.ToString());
            }
        }

        /// <summary>
        /// Go to customer view base on selected row.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCustomerView_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OrderViewModel selectedOrder = null;
                if (gridOrder.SelectedItem != null)
                {
                    selectedOrder = (OrderViewModel)gridOrder.SelectedItems[0];
                }
                if (selectedOrder != null)
                {
                    var customerView = new CustomerView(selectedOrder.CustomerId);
                    customerView.Show();
                    this.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        /// <summary>
        /// After page constructor method finished then this will work for show data with rendaring. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_ContentRendered(object sender, EventArgs e)
        {
            BeforeLoadData();
        }
        /// <summary>
        /// Before load data in grid that time show progress or loader bar.
        /// </summary>
        private void BeforeLoadData()
        {
            BusyIndicator.IsBusy = true;
            BusyIndicator.BusyContent = "Initializing...";
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, a) =>
            {
                BindOrders();
            };
            worker.RunWorkerCompleted += (o, a) =>
            {
                if (gridOrder.IsLoaded == true)
                {
                    gridOrder.ShowLoadingPanel = false;
                }
                BusyIndicator.IsBusy = false;
            };
            worker.RunWorkerAsync();
        }
    }
}
