using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spender.WinPhone.DataService.Interfaces
{
	public interface IAtuthorizationService
	{
		bool Authorize(string username, string password);
		bool Register(string username, string password);
	}
}
