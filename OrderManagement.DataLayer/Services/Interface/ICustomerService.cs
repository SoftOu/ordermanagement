using OrderManagement.Models;
using System;

namespace OrderManagement.DataLayer.Services.Interface
{
    public interface ICustomerService
    {
        Customer GetCustomerById(Guid id);
        bool UpdateCustomer(CustomerViewModel customer);
    }
}
