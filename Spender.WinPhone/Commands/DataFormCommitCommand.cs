using System;
using System.Windows.Input;
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
			var dataForm = parameter as RadDataForm;
			if (dataForm == null)
			{
				return;
			}
			dataForm.Commit();
		}
	}
}