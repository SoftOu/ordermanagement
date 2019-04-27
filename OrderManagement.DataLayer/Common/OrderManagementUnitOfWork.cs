
using System.Data.Entity;

namespace OrderManagement.DataLayer.Commmon
{
    public interface IOrderManagementUnitOfWork : IUnitOfWork
    {
        IGenericRepository<Customer> Customers { get; }
        IGenericRepository<Order> Orders { get; }
    }

    public class OrderManagementUnitOfWork : UnitOfWork, IOrderManagementUnitOfWork
    {
        private DbContext _contaxt;
        private GenericRepository<Customer> _customers;
        private GenericRepository<Order> _orders;

        public override DbContext Context => _contaxt ?? (_contaxt = new OrdersEntities());
        public IGenericRepository<Customer> Customers => _customers ?? (_customers = new GenericRepository<Customer>(Context));
        public IGenericRepository<Order> Orders => _orders ?? (_orders = new GenericRepository<Order>(Context));
    }
}
