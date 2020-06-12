using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace iSele.Services
{
    public interface IDatabaseContext : IDisposable
    {
        DbEntityEntry Entry(object entity);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbSet Set(int SaveChanges);    // (System.Type entityType);
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}