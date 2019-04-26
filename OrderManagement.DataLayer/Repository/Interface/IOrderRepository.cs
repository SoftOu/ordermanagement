using System.Collections.Generic;

namespace OrderManagement.DataLayer.Repository.Interface
{
    public interface IOrderRepository
    {
        List<Order> GetOrders();        
    }
}
