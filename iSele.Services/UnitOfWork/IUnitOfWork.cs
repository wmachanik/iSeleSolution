using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iSele.Services
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository Repository();
        Task CommitAsync();
    }
}
