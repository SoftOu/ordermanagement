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
        public IOrderService _orderService;
        /// <summary>
        /// Order window constructor.
        /// </summary>
        public OrderList()
        {
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
                gridOrder.ShowLoadingPanel = true;
                gridOrder.ItemsSource = _orderService.GetOrders();
                gridOrder.ShowLoadingPanel = false;
            }
            catch (Exception e)
            {
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
