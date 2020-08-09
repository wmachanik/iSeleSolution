using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace iSele.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(object id);
        Task<T> Find(Expression<Func<T, bool>> match);
        Task<T> Add(T obj);
        Task<T> Update(T obj);
        Task<int> Delete(T obj);
        Task<int> Save();
    }
}
