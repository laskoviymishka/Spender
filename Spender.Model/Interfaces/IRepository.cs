// // -----------------------------------------------------------------------
// // <copyright file="IRepository.cs"  company="One Call Care Management, Inc.">
// // Copyright (c) One Call Care Management, Inc. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

using System.Linq;

namespace Spender.Model.Repository
{
	#region Using

	

	#endregion

	public interface IRepository<T>
	{
		void Add(T item);
		void Remove(T item);
		IQueryable<T> Query();
	}
}