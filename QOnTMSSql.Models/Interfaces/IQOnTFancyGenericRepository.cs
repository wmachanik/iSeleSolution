using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

/* a Fancy Genericy Repository from:
 * https://ngohungphuc.wordpress.com/2018/05/01/generic-repository-pattern-in-asp-net-core/
 */
namespace QOnTMSSql.Models.Interfaces
{
    public interface IQOnTFancyGenericRepository<T> where T : class
    {
        IQueryable<T> Query();
        ICollection<T> GetAll();
        Task<ICollection<T>> GetAllAsync();
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        T GetByUniqueId(string id);
        Task<T> GetByUniqueIdAsync(string id);
        T Find(Expression<Func<T, bool>> match);
        Task<T> FindAsync(Expression<Func<T, bool>> match);
        ICollection<T> FindAll(Expression<Func<T, bool>> match);
        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);
        T Add(T entity);
        T AddWithIDOn(T entity, string TableName);
        Task<T> AddAsync(T entity);
        Task<T> AddWithIDOnAsync(T entity, string TableName);
        T Update(T updated);
        Task<T> UpdateAsync(T updated);
        void Delete(T t);
        Task<int> DeleteAsync(T t);
        int Count();
        Task<int> CountAsync();
        IEnumerable<T> Filter(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "",
            int? page = null,
            int? pageSize = null);

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        bool Exist(Expression<Func<T, bool>> predicate);
    }

}
