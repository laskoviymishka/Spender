#region usings

using System.Data.Entity;
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