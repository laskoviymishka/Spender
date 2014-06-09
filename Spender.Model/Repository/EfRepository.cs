// // -----------------------------------------------------------------------
// // <copyright file="EfRepository.cs"  company="One Call Care Management, Inc.">
// // Copyright (c) One Call Care Management, Inc. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

namespace Spender.Model.Repository
{
	#region Using

	using System.Data.Entity;
	using System.Linq;

	#endregion

	public class EfRepository<T> : IRepository<T>
		where T : class
	{
		private readonly DbContext _context;
		private readonly IDbSet<T> _dbSet;

		public EfRepository(DbContext context, IDbSet<T> dbSet)
		{
			_dbSet = dbSet;
			_context = context;
		}

		public void Add(T item)
		{
			_dbSet.Add(item);
			_context.SaveChanges();
		}

		public void Remove(T item)
		{
			_dbSet.Remove(item);
			_context.SaveChanges();
		}

		public IQueryable<T> Query()
		{
			return _dbSet;
		}
	}
}