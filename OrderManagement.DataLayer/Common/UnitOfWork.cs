using System;
using System.Data.Entity;

namespace OrderManagement.DataLayer.Commmon
{
    public interface IUnitOfWork
    {
        int SaveChanges();
        void Dispose();
    }
    public abstract class UnitOfWork : IUnitOfWork
    {
        public abstract DbContext Context { get; }
        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }
    }
}
