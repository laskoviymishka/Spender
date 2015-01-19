#region usings

using System;
using System.Collections.Generic;
using System.Data.Entity;
using AutoMapper;
using Spender.Service.DataObjects;
using Spender.Service.Models;

#endregion

namespace Spender.Service
{
	public class MobileServiceInitializer : DropCreateDatabaseIfModelChanges<MobileServiceContext>
	{
		public override void InitializeDatabase(MobileServiceContext context)
		{
			AutoMapper.Mapper.Initialize(config =>
			{
			});
			base.InitializeDatabase(context);
		}

		protected override void Seed(MobileServiceContext context)
		{
			List<TodoItem> todoItems = new List<TodoItem>
			{
				new TodoItem {Id = Guid.NewGuid().ToString(), Text = "First item", Complete = false},
				new TodoItem {Id = Guid.NewGuid().ToString(), Text = "Second item", Complete = false}
			};

			foreach (TodoItem todoItem in todoItems)
			{
				context.Set<TodoItem>().Add(todoItem);
			}

			base.Seed(context);
		}
	}
}