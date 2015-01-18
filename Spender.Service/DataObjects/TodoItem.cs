#region usings

using Microsoft.WindowsAzure.Mobile.Service;

#endregion

namespace Spender.Service.DataObjects
{
	public class TodoItem : EntityData
	{
		public string Text { get; set; }
		public bool Complete { get; set; }
	}
}