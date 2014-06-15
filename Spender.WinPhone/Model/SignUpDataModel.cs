
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

namespace Spender.WinPhone.Views.Models
{
	public class SignUpDataModel
	{
		public string Name
		{
			get;
			set;
		}

		public string Email
		{
			get;
			set;
		}

		public string Password
		{
			get;
			set;
		}
	}
}
