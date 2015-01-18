#region usings

using Microsoft.WindowsAzure.Mobile.Service;

#endregion

namespace Spender.Service.DataObjects
{
	public class Location : EntityData
	{
		public float Lat { get; set; }
		public float Lng { get; set; }
	}
}