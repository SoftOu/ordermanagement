using OrderManagement.Models;
using OrderManagement.DataLayer.Services;
using OrderManagement.DataLayer.Services.Interface;
using System;
using System.Linq;
using System.Windows;
using System.ComponentModel;
using System.Threading;

namespace OrderManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CustomerView : Window
    {
        public ICustomerService _customerService;

        public Guid CustomerId { get; set; }

        /// <summary>
        /// Customer window constructor.
        /// </summary>
        /// <param name="customerId"></param>
        public CustomerView(Guid customerId)
        {
            _customerService = new CustomerService();
            InitializeComponent();
            CustomerId = customerId;
            LoadData();
        }

        /// <summary>
        /// Get customer and display data on screen.
        /// </summary>
        private void LoadData()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            if (CustomerId != null)
            {
                var customer = _customerService.GetCustomerById(CustomerId);
                txtFirstName.Text = customer.FirstName.Trim();
                txtLastName.Text = customer.LastName.Trim();
            }
        }

        /// <summary>
        /// Closed customer window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closed(object sender, EventArgs e)
        {
            var orderlist = new OrderList();
            orderlist.Show();
        }

        /// <summary>
        /// Saves customer detail to database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //BeforeUpdateRecords();

            bool isUpdated;
            updateCustomer.IsSplashScreenShown = true;
            
            isUpdated = UpdateData();
            //Thread.Sleep(2000);
            if (isUpdated)
            {
                updateCustomer.IsSplashScreenShown = false;
                var orderlist = new OrderList();
                orderlist.Show();
                this.Close();
            }
            else
            {
                updateCustomer.IsSplashScreenShown = false;
            }
        }

        /// <summary>
        /// Customer cancel window. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            var orderlist = new OrderList();
            orderlist.Show();
            this.Close();

        }
        /// <summary>
        /// Validate user inputs
        /// </summary>
        /// <returns></returns>
        private bool Validate()
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(txtFirstName.Text.Trim()))
            {
                isValid = false;
                MessageBox.Show("Please enter first name.");
                txtFirstName.Focus();
                return isValid;
            }

            if (string.IsNullOrEmpty(txtLastName.Text.Trim()))
            {
                isValid = false;
                MessageBox.Show("Please enter last name.");
                txtLastName.Focus();
                return isValid;
            }

            return isValid;
        }
        /// <summary>
        /// Before update records then show progress bar.
        /// </summary>
        private void BeforeUpdateRecords()
        {
            CustomerBusyIndicator.IsBusy = true;
            CustomerBusyIndicator.BusyContent = "Updating...";
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, a) =>
            {
                UpdateData();
            };
            worker.RunWorkerCompleted += (o, a) =>
            {
                CustomerBusyIndicator.IsBusy = false;
            };
            worker.RunWorkerAsync();
        }

        /// <summary>
        /// update data of customer.
        /// </summary>
        private bool UpdateData()
        {
            bool isUpdated = false;
            if (Validate())
            {
                var customer = new CustomerViewModel
                {
                    Id = CustomerId,
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim()
                };
                isUpdated = _customerService.UpdateCustomer(customer);
                if (isUpdated)
                {
                    //var orderlist = new OrderList();
                    //orderlist.Show();
                    //this.Close();
                    return true;
                }
                else
                {
                    return false;
                }
                
                
            }
            else
            {
                return false;
            }
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            
        }
        
    }
}
