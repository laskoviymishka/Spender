using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spender.Shared.Contracts;

namespace Spender.Shared.Controllers
{
	public class PaymentTransactionController : BaseController<PaymentTransaction>
	{
		private readonly ITransactionHolderController _transactionHolderController;

		public PaymentTransactionController(ITransactionHolderController transactionHolderController) : base()
		{
			_transactionHolderController = transactionHolderController;
		}

		public async Task<IEnumerable<PaymentTransaction>> GetTransactionsByCategory(Category category)
		{
			return await base.QueryItem(t => t.Recipient.Categories.Contains(category));
		}

		public async Task<IEnumerable<PaymentTransaction>> GetMyTransactions()
		{
			return await base.QueryItem(t => t.Sender.Title == this.CurrentUserId);
		}

		public async Task<IEnumerable<PaymentTransaction>> GetTrasactionBySender(string senderId)
		{
			return await base.QueryItem(t => t.Sender.Id == senderId);
		}

		public async Task<IEnumerable<PaymentTransaction>> GetTrasactionByRecipient(string recipientId)
		{
			return await base.QueryItem(t => t.Recipient.Id == recipientId);
		}

		public async Task<IEnumerable<PaymentTransaction>> GetTrasactionByDateRange(DateTime startDate, DateTime endDate)
		{
			return await base.QueryItem(t => t.Date >= startDate && t.Date <= endDate);
		}

		public override void InsertItem(PaymentTransaction item)
		{
			item.UserID = this.CurrentUserId;
			base.InsertItem(item);
		}
	}
}