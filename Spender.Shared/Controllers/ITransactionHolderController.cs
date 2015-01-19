#region usings

using System.Collections.Generic;
using System.Threading.Tasks;
using Spender.Shared.Contracts;

#endregion

namespace Spender.Shared.Controllers
{
	public interface ITransactionHolderController
	{
		TransactionHolder GeOwnTransactionHolder();
		Task<IEnumerable<TransactionHolder>> GetMyTransactionHolders();
	}
}