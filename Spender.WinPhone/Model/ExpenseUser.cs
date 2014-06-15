using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spender.Common.Entities;

namespace Spender.WinPhone.DataService
{
	public class ExpenseUser : IPclUser
	{
		public string Id { get; set; }

		public string UserName { get; set; }
	}
}
