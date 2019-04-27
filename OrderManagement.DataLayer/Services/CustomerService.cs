using OrderManagement.DataLayer.Commmon;
using OrderManagement.DataLayer.Services.Interface;
using OrderManagement.Models;
using System;

namespace OrderManagement.DataLayer.Services
{
    public class CustomerService : ICustomerService
    {
        private IOrderManagementUnitOfWork _unitOfWork;

        /// <summary>
        /// Service call cunstructor.
        /// </summary>
        public CustomerService()
        {
            _unitOfWork = new OrderManagementUnitOfWork();
        }

        /// <summary>
        /// Get customer by customer id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Customer GetCustomerById(Guid id)
        {
            return _unitOfWork.Customers.GetById(id);
        }

        /// <summary>
        /// Update customer data.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public bool UpdateCustomer(CustomerViewModel customer)
        {
            if (!string.IsNullOrEmpty(customer.FirstName) && !string.IsNullOrEmpty(customer.LastName))
            {
                //var dbCustomer = _unitOfWork.Customers.GetById(Guid.Parse("88a96958-a302-4913-9adc-1997b49c7571"));
                var dbCustomer = _unitOfWork.Customers.GetById(customer.Id);
                dbCustomer.FirstName = customer.FirstName;
                dbCustomer.LastName = customer.LastName;
                _unitOfWork.Customers.Update(dbCustomer);
                var affectedRows = _unitOfWork.SaveChanges();
                return affectedRows > 0;
            }
            else
            {
                return false;
            }
        }
    }
}
