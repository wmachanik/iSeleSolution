using iSele.Repository.Interfaces;
using iSele.Services;
using iSele.Services.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSele.Repository.Repositories
{
    class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _dbContext;
		private readonly ILoggerManager _loggerManager;
		private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

		public Dictionary<Type, object> Repositories
		{
			get { return _repositories; }
			set { Repositories = value; }
		}

		public UnitOfWork(ApplicationDbContext dbContext, ILoggerManager LoggerManager)
		{
			_dbContext = dbContext;
			_loggerManager = LoggerManager;
		}

		public IFancyGenericRepository<T> Repository<T>() where T : class
		{
			if (Repositories.Keys.Contains(typeof(T)))
			{
				return Repositories[typeof(T)] as IFancyGenericRepository<T>;
			}

			IFancyGenericRepository<T> repo = new FancyGenericRepository<T>(_dbContext, _loggerManager);
			Repositories.Add(typeof(T), repo);
			return repo;
		}

		public async Task<int> Commit()
		{
			return await _dbContext.SaveChangesAsync();
		}

		public void Rollback()
		{
			_dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
		}
	}
}
