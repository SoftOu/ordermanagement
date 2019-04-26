using OrderManagement.DataLayer.Repository;
using OrderManagement.DataLayer.Repository.Interface;
using OrderManagement.DataLayer.Services.Interface;
using OrderManagement.Models;
using System;

namespace OrderManagement.DataLayer.Services
{
    public class CustomerService : ICustomerService
    {
        ICustomerRepository _customerRepository;
        /// <summary>
        /// Service call cunstructor.
        /// </summary>
        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
        }

        /// <summary>
        /// Get customer by customer id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Customer GetCustomerById(Guid id)
        {
            return _customerRepository.GetCustomerById(id);
        }

        /// <summary>
        /// Update customer data.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public bool UpdateCustomer(CustomerViewModel customer)
        {
            Customer dbCustomer = new Customer()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Id = customer.Id
            };
           
            if (!string.IsNullOrEmpty(customer.FirstName) && !string.IsNullOrEmpty(customer.LastName))
                return _customerRepository.UpdateCustomer(dbCustomer);
            else
                return false;

        }
    }
}
