using iSele.Repository.Interfaces;
using iSele.Services;
using iSele.Services.Tools;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace iSele.Repository.Repositories
{
    public class FancyGenericRepository<T> : IFancyGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly ILoggerManager _loggerManager;
        private readonly IUnitOfWork _unitOfWork;

        public FancyGenericRepository(ApplicationDbContext context, ILoggerManager LoggerManager)
        {
            _context = context;
            _loggerManager = LoggerManager;
            _unitOfWork = new UnitOfWork(context, _loggerManager);
        }

        public IQueryable<T> Query()
        {
            return _context.Set<T>().AsQueryable();
        }

        public ICollection<T> GetAll()
        {
            _loggerManager.LogInfo($"FancyRepo -> GetAll of {typeof(T)}");
            return _context.Set<T>().ToList();
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            _loggerManager.LogInfo($"FancyRepo -> GetAllAsyn of {typeof(T)}");
            return await _context.Set<T>().ToListAsync();
        }

        public T GetById(int id)
        {
            _loggerManager.LogInfo($"FancyRepo -> GetById of {typeof(T)} id {id}");
            return _context.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            _loggerManager.LogInfo($"FancyRepo -> GetByIdAsync of {typeof(T)} id {id}");
            return await _context.Set<T>().FindAsync(id);
        }

        public T GetByUniqueId(string id)
        {
            _loggerManager.LogInfo($"FancyRepo -> GetByUniqueId of {typeof(T)} id {id}");
            return _context.Set<T>().Find(id);
        }

        public async Task<T> GetByUniqueIdAsync(string id)
        {
            _loggerManager.LogInfo($"FancyRepo -> GetByUniqueIdAsync of {typeof(T)} id {id}");
            return await _context.Set<T>().FindAsync(id);
        }

        public T Find(Expression<Func<T, bool>> match)
        {
            _loggerManager.LogInfo($"FancyRepo -> Find {typeof(T)} matchby {match.ToString()}");
            return _context.Set<T>().SingleOrDefault(match);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            _loggerManager.LogInfo($"FancyRepo -> FindAsync {typeof(T)} matchby {match.ToString()}");
            return await _context.Set<T>().SingleOrDefaultAsync(match);
        }

        public ICollection<T> FindAll(Expression<Func<T, bool>> match)
        {
            _loggerManager.LogInfo($"FancyRepo -> FindAll {typeof(T)} matchby {match.ToString()}");
            return _context.Set<T>().Where(match).ToList();
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            _loggerManager.LogInfo($"FancyRepo -> FindAllAsync {typeof(T)} matchby {match.ToString()}");
            return await _context.Set<T>().Where(match).ToListAsync();
        }

        public T Add(T entity)
        {
            // Does not cater of identity perhaps we should do a create?
            _loggerManager.LogInfo($"FancyRepo -> Add {typeof(T)} enttity {entity.ToString()}");
            try
            {
                _context.Set<T>().Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _loggerManager.LogDebug($"Error FancyRepo -> Add error: {ex.Message}");
            }
            return entity;
        }

        public T AddWithIDOn(T entity, string TableName)
        {
            _loggerManager.LogInfo($"FancyRepo -> AddWithIDOn {typeof(T)}, enttity {entity.ToString()}, Table: {TableName} ");
            _context.Database.OpenConnection();
            try
            {
                _context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT {TableName} ON");
                _context.Set<T>().Add(entity);
                _context.SaveChanges();
                _context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT {TableName} OFF");
            }
            catch (Exception ex)
            {
                _loggerManager.LogDebug($"Error FancyRepo -> AddWithIDOn error: {ex.Message}");
            }
            finally
            {
                _context.Database.CloseConnection();
            }
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            _loggerManager.LogInfo($"FancyRepo -> AddAsync {typeof(T)}, enttity {entity.ToString()} ");
            try
            {
                await _context.Set<T>().AddAsync(entity);
                await _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _loggerManager.LogDebug($"Error FancyRepo -> AddAsync error: {ex.Message}");
            }
            return entity;
        }

        public async Task<T> AddWithIDOnAsync(T entity, string TableName)
        {
            _loggerManager.LogInfo($"FancyRepo -> AddWithIDOnAsync {typeof(T)}, enttity {entity.ToString()}, Table: {TableName} ");
            await _context.Database.OpenConnectionAsync();
            try
            {
                await _context.Database.ExecuteSqlRawAsync($"SET IDENTITY_INSERT {TableName} ON");
                await _context.Set<T>().AddAsync(entity);
                await _unitOfWork.Commit();
                await _context.Database.ExecuteSqlRawAsync($"SET IDENTITY_INSERT {TableName} OFF");
            }
            catch (Exception ex)
            {
                _loggerManager.LogDebug($"Error FancyRepo -> AddAsync error: {ex.Message}");
            }
            finally
            {
                await _context.Database.CloseConnectionAsync();
            }
            return entity;
        }
        public T Update(T updated)
        {
            _loggerManager.LogInfo($"FancyRepo -> Update {typeof(T)}, updated {updated.ToString()} ");
            if (updated == null)
            {
                return null;
            }
            try
            {
                _context.Set<T>().Attach(updated);
                _context.Entry(updated).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _loggerManager.LogDebug($"Error FancyRepo -> Update error: {ex.Message}");
            }
            return updated;
        }

        public async Task<T> UpdateAsync(T updated)
        {
            _loggerManager.LogInfo($"FancyRepo -> UpdateAsync {typeof(T)}, updated {updated.ToString()} ");
            if (updated == null)
            {
                return null;
            }

            try
            {
                _context.Set<T>().Attach(updated);
                _context.Entry(updated).State = EntityState.Modified;
                await _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _loggerManager.LogDebug($"Error FancyRepo -> UpdateAsync error: {ex.Message}");
            }
            return updated;
        }

        public void Delete(T t)
        {
            _context.Set<T>().Remove(t);
            _context.SaveChanges();
        }

        public async Task<int> DeleteAsync(T t)
        {
            _context.Set<T>().Remove(t);
            return await _unitOfWork.Commit();
        }

        public int Count()
        {
            return _context.Set<T>().Count();
        }

        public async Task<int> CountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }

        public IEnumerable<T> Filter(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "", int? page = null,
            int? pageSize = null)
        {
            IQueryable<T> query = _context.Set<T>();
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
            return _context.Set<T>().Where(predicate);
        }

        public bool Exist(Expression<Func<T, bool>> predicate)
        {
            var exist = _context.Set<T>().Where(predicate);
            return exist.Any() ? true : false;
        }
    }
}
