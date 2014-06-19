namespace Spender.WinPhone.DataService.Interfaces
{
	public interface IAtuthorizationService
	{
		string Authorize(string username, string password);
		bool Register(string username, string password);
	}
}