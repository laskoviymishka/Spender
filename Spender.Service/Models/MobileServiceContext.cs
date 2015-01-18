using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Tables;
using Spender.Service.DataObjects;

namespace Spender.Service.Models
{

	public class MobileServiceContext : DbContext
	{
		private const string connectionStringName = "Name=MS_TableConnectionString";

		public MobileServiceContext() : base(connectionStringName)
		{
		}

		public DbSet<TodoItem> TodoItems { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Bill> Bills { get; set; }
		public DbSet<Location> Locations { get; set; }
		public DbSet<PaymentTransaction> Transactions { get; set; }
		public DbSet<TransactionHolder> TransactionHolders { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			string schema = ServiceSettingsDictionary.GetSchemaName();
			if (!string.IsNullOrEmpty(schema))
			{
				modelBuilder.HasDefaultSchema(schema);
			}

			modelBuilder.Conventions.Add(
				new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
					"ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));
		}

		public System.Data.Entity.DbSet<Spender.Service.DataObjects.PaymentTransaction> PaymentTransactions { get; set; }
	}

}
