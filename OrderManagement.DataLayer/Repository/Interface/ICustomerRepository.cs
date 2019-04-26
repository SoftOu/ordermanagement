using System;

namespace OrderManagement.DataLayer.Repository.Interface
{
    public interface ICustomerRepository
    {
        Customer GetCustomerById(Guid id);
        //bool SaveCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
    }
}
