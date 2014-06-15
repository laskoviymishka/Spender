
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

namespace Spender.WinPhone.Views.Helpers
{
	public class MinLengthValidator : DataFormValidator
	{
		const string PasswordValidationMessage = "Password must be at least 6 characters.";
		const int MinLength = 6;

		public override void Validate(ValidatingDataFieldEventArgs args)
		{
			string passwordValue = (string)args.AssociatedDataField.Value;
			if (passwordValue.Length < MinLength)
			{
				args.IsInputValid = false;
				args.ValidationMessage = PasswordValidationMessage;
			}
		}
	}
}
