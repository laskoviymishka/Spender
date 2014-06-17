using System;
using Telerik.Windows.Controls;

namespace Spender.WinPhone.Views.Helpers
{
	public class NonEmptyDateValidator : DataFormValidator
	{
		public override void Validate(ValidatingDataFieldEventArgs args)
		{
			args.IsInputValid = (args.AssociatedDataField.Value as DateTime?) != null;
		}
	}
}