
using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.DataForm;
using Spender.WinPhone.Views.SampleData;
using Spender.Model.Entities;

namespace Spender.WinPhone.Views.Models
{
	public class ExpenseFormDataModel
	{
		[GenericListEditor(typeof(OptionsInfoProvider))]
		public string Category
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public DateTime? Date
		{
			get;
			set;
		}

		public decimal Amount
		{
			get;
			set;
		}
	}
}
