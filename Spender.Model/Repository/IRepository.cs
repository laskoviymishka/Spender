// // -----------------------------------------------------------------------
// // <copyright file="IRepository.cs"  company="One Call Care Management, Inc.">
// // Copyright (c) One Call Care Management, Inc. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

namespace Spender.Model.Repository
{
	#region Using

	using System.Linq;

	#endregion

	public interface IRepository<T>
	{
		void Add(T item);
		void Remove(T item);
		IQueryable<T> Query();
	}
}