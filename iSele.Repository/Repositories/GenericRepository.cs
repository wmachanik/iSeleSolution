using iSele.Repository.Interfaces;
using iSele.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace iSele.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<T> GetById(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<T> Find(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(match);
        }
        public async Task<T> Add(T entity)
        {
            var result = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<T> Update(T updated)
        {
            if (updated == null)
            {
                return null;
            }

            _context.Set<T>().Attach(updated);
            _context.Entry(updated).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return updated;

            //return updated; var result = await _context.Set<T>().FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);

            //if (result != null)
            //{
            //    result.FirstName = employee.FirstName;
            //    result.LastName = employee.LastName;
            //    result.Email = employee.Email;
            //    result.DateOfBrith = employee.DateOfBrith;
            //    result.Gender = employee.Gender;
            //    result.DepartmentId = employee.DepartmentId;
            //    result.PhotoPath = employee.PhotoPath;

            //    await appDbContext.SaveChangesAsync();

            //    return result;
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }


        public async Task<int> Delete(T obj)
        {
            _context.Set<T>().Remove(obj);
            return await _context.SaveChangesAsync();
        }
    }
}
