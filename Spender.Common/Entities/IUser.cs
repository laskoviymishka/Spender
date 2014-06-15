using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spender.Common.Entities
{
	public interface IPclUser
	{
		string Id { get; }
		string UserName { get; set; }
	}
}
