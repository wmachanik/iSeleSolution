using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace iSele.Services
{
    public class GenericRepository : IGenericRepository
    {
        private readonly IDatabaseContext _dbContext;


        public GenericRepository(IDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<T>> FindAsync<T>
            (Expression<Func<T, bool>> expression) where T : class
        {
            return await DbContext.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> SingleOrDefaultAsync<T>
            (Expression<Func<T, bool>> expression) where T : class
        {
            return await DbContext.Set<T>().SingleOrDefaultAsync(expression);
        }

        public void Add<T>(T entity) where T : class
        {
            DbContext.Set<T>().Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete<T>(T entity) where T : class
        {
            DbContext.Set<T>().Remove(entity);
        }
    }
}
