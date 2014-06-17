namespace Spender.WinPhone.DataService.Interfaces
{
	public interface IAtuthorizationService
	{
		bool Authorize(string username, string password);
		bool Register(string username, string password);
	}
}