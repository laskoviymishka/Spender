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
			base.InitializeDatabase(context);
		}
	}
}