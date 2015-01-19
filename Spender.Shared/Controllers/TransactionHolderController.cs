using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spender.Shared.Contracts;

namespace Spender.Shared.Controllers
{
	public class TransactionHolderController : BaseController<TransactionHolder>, ITransactionHolderController
	{
		public TransactionHolderController() : base()
		{
		}

		public TransactionHolder GeOwnTransactionHolder()
		{
			return this.QueryItem(t => t.Title == this.CurrentUserId).Result.First();
		}

		public async Task<IEnumerable<TransactionHolder>> GetMyTransactionHolders()
		{
			return await this.QueryItem(t => t.UserId == this.CurrentUserId);
		}
	}
}