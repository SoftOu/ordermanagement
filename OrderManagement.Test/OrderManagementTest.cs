using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderManagement.Models;
using OrderManagement.DataLayer.Services;

namespace OrderManagement.Test
{
    /// <summary>
    /// Test case for checking orders count returned from service
    /// method GetOrders().
    /// </summary>
    [TestClass]
    public class OrderManagementTest
    {
        [TestMethod]
        public void Test_GetOrders()
        {
            var orderService = new OrderService();
            var orders = orderService.GetOrders();
            var totalOrders = orders.Count > 0 ? true : false;
            Assert.AreEqual(true, totalOrders);
        }

        /// <summary>
        /// Test case for updating customer information into database.
        /// </summary>
        [TestMethod]
        public void Test_UpdateCustomer()
        {
            CustomerViewModel customer = new CustomerViewModel()
            {
                Id= Guid.Parse("88A96958-A302-4913-9ADC-1997B49C7571"),
                FirstName="Peter",
                LastName="Lee"
            };
            
            var customerService = new CustomerService();
            var res = customerService.UpdateCustomer(customer);
            Assert.AreEqual(true, res);
        }
        /// <summary>
        /// Failed Test case for updating customer information without entering first name.
        /// </summary>
        [TestMethod]
        public void Test_UpdateCustomerWithoutFirstName()
        {
            CustomerViewModel customer = new Models.CustomerViewModel()
            {
                Id = Guid.Parse("88A96958-A302-4913-9ADC-1997B49C7571"),
                FirstName = "",
                LastName = "Lee"
            };

            var customerService = new CustomerService();
            var res = customerService.UpdateCustomer(customer);
            Assert.AreEqual(true, res);
        }
        /// <summary>
        /// Failed Test case for updating customer information without entering last name.
        /// </summary>
        [TestMethod]
        public void Test_UpdateCustomerWithoutLastName()
        {
            Models.CustomerViewModel customer = new Models.CustomerViewModel()
            {
                Id = Guid.Parse("88A96958-A302-4913-9ADC-1997B49C7571"),
                FirstName = "Peter",
                LastName = ""
            };

            var customerService = new CustomerService();
            var res = customerService.UpdateCustomer(customer);
            Assert.AreEqual(true, res);
        }
    }
}
