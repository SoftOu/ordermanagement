using log4net;
using OrderManagement.DataLayer.Services;
using OrderManagement.DataLayer.Services.Interface;
using OrderManagement.Models;
using System;
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
            BindOrders();
        }

        /// <summary>
        /// Bind order and display data on screen.
        /// </summary>
        private void BindOrders()
        {
            try
            {
                log.Info("Calling BindOrders...");
                gridOrder.ShowLoadingPanel = true;
                gridOrder.ItemsSource = _orderService.GetOrders();
                gridOrder.ShowLoadingPanel = false;
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
    }
}
