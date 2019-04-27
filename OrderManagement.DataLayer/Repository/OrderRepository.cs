using OrderManagement.DataLayer.Commmon;
using OrderManagement.DataLayer.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagement.DataLayer.Repository
{
    public class OrderRepository : IOrderRepository
    {
        /// <summary>
        /// Get order by order id from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Order GetOrderById(Guid id)
        {
            var unitOfWork = new OrderManagementUnitOfWork();
            return unitOfWork.Orders.GetById(id);
            //using (OrdersEntities context = new OrdersEntities())
            //{
            //    // Do some work with the dragon.
            //    // Check business rules.
            //    return context.Orders.FirstOrDefault(x => x.Id == id);
            //}

        }

        /// <summary>
        /// Get all orders with customer from database.
        /// </summary>
        /// <returns></returns>
        public List<Order> GetOrders()
        {
            using (OrdersEntities context = new OrdersEntities())
            {
                return context.Orders.Include("Customer").ToList();
            }
        }
    }
}
