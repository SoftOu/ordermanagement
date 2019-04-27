using OrderManagement.DataLayer.Services.Interface;
using OrderManagement.Models;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using OrderManagement.DataLayer.Commmon;

namespace OrderManagement.DataLayer.Services
{
    public class OrderService : IOrderService
    {
        private IOrderManagementUnitOfWork _unitOfWork;

        /// <summary>
        /// Service call cunstructor.
        /// </summary>
        public OrderService()
        {
            _unitOfWork = new OrderManagementUnitOfWork();
        }

        /// <summary>
        /// Get all orders.
        /// </summary>
        /// <returns></returns>
        public List<OrderViewModel> GetOrders()
        {
            var ordersVm = new List<OrderViewModel>();
            var orders = _unitOfWork.Orders.Get();
            if (orders != null && orders.Count() > 0)
            {
                ordersVm = orders.Select(GetOrderVm).ToList();
            }
            return ordersVm;
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
