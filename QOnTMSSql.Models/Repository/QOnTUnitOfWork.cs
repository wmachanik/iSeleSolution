//using iSele.Repository.Interfaces;
//using iSele.Services;
//using iSele.Repository.Interfaces;
using QOnTMSSql.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QOnTMSSql.Models.Repositories
{
    class QOnTUnitOfWork : IQOnTUnitOfWork
	{
		private readonly QOnTDbContext _QOnTDbContext;
		private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

		public Dictionary<Type, object> Repositories
		{
			get { return _repositories; }
			set { Repositories = value; }
		}

		public QOnTUnitOfWork(QOnTDbContext dbContext)
		{
			_QOnTDbContext = dbContext;
		}

		public IQOnTFancyGenericRepository<T> Repository<T>() where T : class
		{
			if (Repositories.Keys.Contains(typeof(T)))
			{
				return Repositories[typeof(T)] as IQOnTFancyGenericRepository<T>;
			}

            IQOnTFancyGenericRepository<T> repo = new QOnTFancyGenericRepository<T>(_QOnTDbContext);
			Repositories.Add(typeof(T), repo);
			return repo;
		}

		public async Task<int> Commit()
		{
			return await _QOnTDbContext.SaveChangesAsync();
		}

		public void Rollback()
		{
			_QOnTDbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
		}
	}
}
