using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iSele.Repository.Interfaces
{
    public interface IUnitOfWork
    {
		IFancyGenericRepository<T> Repository<T>() where T : class;
        Task<int> Commit();
        void Rollback();
    }
}
