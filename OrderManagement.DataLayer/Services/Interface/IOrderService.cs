using OrderManagement.Models;
using System.Collections.Generic;

namespace OrderManagement.DataLayer.Services.Interface
{
    public interface IOrderService
    {
        List<OrderViewModel> GetOrders();        
    }
}
