using System;
using Spender.WinPhone.Views.SampleData;
using Telerik.Windows.Controls.DataForm;

namespace Spender.WinPhone.Views.Models
{
	public class ExpenseFormDataModel
	{
		[GenericListEditor(typeof (OptionsInfoProvider))]
		public string Category { get; set; }

		public string Name { get; set; }

		public string Note { get; set; }

		public DateTime? Date { get; set; }

		public decimal Amount { get; set; }
	}
}