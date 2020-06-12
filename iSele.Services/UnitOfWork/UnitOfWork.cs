using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iSele.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseContext _databaseContext;

        public UnitOfWork(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IGenericRepository Repository()
        {
            return new GenericRepository(_databaseContext);
        }

        public void Dispose()
        {
            _databaseContext.Dispose();
        }

        public Task CommitAsync()
        {
            return _databaseContext.SaveChangesAsync();
        }
    }
}
