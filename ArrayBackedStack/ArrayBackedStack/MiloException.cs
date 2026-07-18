using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayBackedStack
{
	public class MiloException : Exception
	{
		public MiloException()
		{
		}

		public MiloException(string message)
			: base (message)
		{ 
		}

		public MiloException(string message, Exception innerException) 
			: base(message, innerException)
		{
		}
	}
}
