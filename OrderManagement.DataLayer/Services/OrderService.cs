using OrderManagement.DataLayer.Repository.Interface;
using OrderManagement.DataLayer.Repository;
using OrderManagement.DataLayer.Services.Interface;
using OrderManagement.Models;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace OrderManagement.DataLayer.Services
{
    public class OrderService : IOrderService
    {
        IOrderRepository _orderRepository;
        ICustomerRepository _customerRepository;

        /// <summary>
        /// Service call cunstructor.
        /// </summary>
        public OrderService()
        {
            _orderRepository = new OrderRepository();
            _customerRepository = new CustomerRepository();
        }

        /// <summary>
        /// Get all orders.
        /// </summary>
        /// <returns></returns>
        public List<OrderViewModel> GetOrders()
        {
            List<OrderViewModel> listOrders = new List<OrderViewModel>();
            var orders = _orderRepository.GetOrders();
            if (orders != null && orders.Count > 0)
            {
                listOrders = orders.Select(GetOrderVm).ToList();
            }
            return listOrders;
        }

        /// <summary>
        /// Mapping with view model from the database model of Order.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        private OrderViewModel GetOrderVm(Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                ReferenceNumber = order.ReferenceNumber,
                OrderDate = order.OrderDate,
                OrderValue = order.OrderValue,
                OrderValueString = order.OrderValue.ToString("C", CultureInfo.CurrentCulture),
                OrderDateString = order.OrderDate.ToString("dd-MMM-yyyy"),
                CustomerName = string.Format("{0} {1}", order.Customer.FirstName, order.Customer.LastName)
            };
        }
    }
}
