using OrderManagement.DataLayer.Repository.Interface;
using System;
using System.Data.Entity;
using System.Linq;

namespace OrderManagement.DataLayer.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        /// <summary>
        /// Get customer detail by customer id from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Customer GetCustomerById(Guid id)
        {
            using (OrdersEntities context = new OrdersEntities())
            {
                return context.Customers.FirstOrDefault(x => x.Id == id);
            }
        }

        /// <summary>
        /// Update customer records in database.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public bool UpdateCustomer(Customer customer)
        {
            using (OrdersEntities context = new OrdersEntities())
            {
                var entry = context.Entry(customer);
                entry.State = EntityState.Modified;
                var result = context.SaveChanges();
                return result > 0;
            }
        }
    }
}
