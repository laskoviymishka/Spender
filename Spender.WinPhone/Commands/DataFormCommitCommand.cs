
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
using Microsoft.Phone.Tasks;
using Telerik.Windows.Controls;

namespace Spender.WinPhone.Views.Commands
{
	public class DataFormCommitCommand : ICommand
	{
		public bool CanExecute(object parameter)
		{
			return parameter != null;
		}

		public event EventHandler CanExecuteChanged;

		public void Execute(object parameter)
		{
			RadDataForm dataForm = parameter as RadDataForm;
			if (dataForm == null)
			{
				return;
			}
			dataForm.Commit();
		}
	}
}
