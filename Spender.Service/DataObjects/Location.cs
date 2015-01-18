using Microsoft.WindowsAzure.Mobile.Service;

namespace Spender.Service.DataObjects
{
	public class Location : EntityData
	{
		public float Lat { get; set; }
		public float Lng { get; set; }
	}
}