//using iSele.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using QOnTMSSql.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QOnTMSSql.Models.Repositories
{
    public class QOnTFancyGenericRepository<T> : IQOnTFancyGenericRepository<T> where T : class
    {
        private readonly QOnTDbContext _QOnTContext;
        private readonly QOnTUnitOfWork _QOnTUnitOfWork;

        public QOnTFancyGenericRepository(QOnTDbContext context)
        {
            _QOnTContext = context;
            _QOnTUnitOfWork = new QOnTUnitOfWork(context);
        }

        public IQueryable<T> Query()
        {
            return _QOnTContext.Set<T>().AsQueryable();
        }

        public ICollection<T> GetAll()
        {
            return _QOnTContext.Set<T>().ToList();
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await _QOnTContext.Set<T>().ToListAsync();
        }

        public T GetById(int id)
        {
            return _QOnTContext.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _QOnTContext.Set<T>().FindAsync(id);
        }

        public T GetByUniqueId(string id)
        {
            return _QOnTContext.Set<T>().Find(id);
        }

        public async Task<T> GetByUniqueIdAsync(string id)
        {
            return await _QOnTContext.Set<T>().FindAsync(id);
        }

        public T Find(Expression<Func<T, bool>> match)
        {
            return _QOnTContext.Set<T>().SingleOrDefault(match);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await _QOnTContext.Set<T>().SingleOrDefaultAsync(match);
        }

        public ICollection<T> FindAll(Expression<Func<T, bool>> match)
        {
            return _QOnTContext.Set<T>().Where(match).ToList();
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await _QOnTContext.Set<T>().Where(match).ToListAsync();
        }

        public T Add(T entity)
        {
            // Does not cater of identity perhaps we should do a create?
            _QOnTContext.Set<T>().Add(entity);
            _QOnTContext.SaveChanges();
            return entity;
        }

        public T AddWithIDOn(T entity, string TableName)
        {
            _QOnTContext.Database.OpenConnection();
            try
            {
                _QOnTContext.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT {TableName} ON");
                _QOnTContext.Set<T>().Add(entity);
                _QOnTContext.SaveChanges();
                _QOnTContext.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT {TableName} OFF");
            }
            finally
            {
                _QOnTContext.Database.CloseConnection();
            }
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _QOnTContext.Set<T>().AddAsync(entity);
            await _QOnTUnitOfWork.Commit();
            return entity;
        }

        public async Task<T> AddWithIDOnAsync(T entity, string TableName)
        {
            await _QOnTContext.Database.OpenConnectionAsync();
            try
            {
                await _QOnTContext.Database.ExecuteSqlRawAsync($"SET IDENTITY_INSERT {TableName} ON");
                await _QOnTContext.Set<T>().AddAsync(entity);
                await _QOnTUnitOfWork.Commit();
                await _QOnTContext.Database.ExecuteSqlRawAsync($"SET IDENTITY_INSERT {TableName} OFF");
            }
            finally
            {
                await _QOnTContext.Database.CloseConnectionAsync();
            }
            return entity;
        }
        public T Update(T updated)
        {
            if (updated == null)
            {
                return null;
            }

            _QOnTContext.Set<T>().Attach(updated);
            _QOnTContext.Entry(updated).State = EntityState.Modified;
            _QOnTContext.SaveChanges();

            return updated;
        }

        public async Task<T> UpdateAsync(T updated)
        {
            if (updated == null)
            {
                return null;
            }

            try
            {
                _QOnTContext.Set<T>().Attach(updated);
                _QOnTContext.Entry(updated).State = EntityState.Modified;
                await _QOnTUnitOfWork.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return updated;
        }

        public void Delete(T t)
        {
            _QOnTContext.Set<T>().Remove(t);
            _QOnTContext.SaveChanges();
        }

        public async Task<int> DeleteAsync(T t)
        {
            _QOnTContext.Set<T>().Remove(t);
            return await _QOnTUnitOfWork.Commit();
        }

        public int Count()
        {
            return _QOnTContext.Set<T>().Count();
        }

        public async Task<int> CountAsync()
        {
            return await _QOnTContext.Set<T>().CountAsync();
        }

        public IEnumerable<T> Filter(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "", int? page = null,
            int? pageSize = null)
        {
            IQueryable<T> query = _QOnTContext.Set<T>();
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (includeProperties != null)
            {
                foreach (
                    var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (page != null && pageSize != null)
            {
                query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }

            return query.ToList();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _QOnTContext.Set<T>().Where(predicate);
        }

        public bool Exist(Expression<Func<T, bool>> predicate)
        {
            var exist = _QOnTContext.Set<T>().Where(predicate);
            return exist.Any() ? true : false;
        }
    }
}
