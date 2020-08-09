using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QOnTMSSql.Models.Interfaces
{
    public interface IQOnTUnitOfWork
    {
		IQOnTFancyGenericRepository<T> Repository<T>() where T : class;
        Task<int> Commit();
        void Rollback();
    }
}
