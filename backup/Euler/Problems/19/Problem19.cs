using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems
{
	public class Problem19 : Problem 
	{
		public override object Launch()
		{
			DateTime currentDate = new DateTime(1900, 01, 01).AddDays(-1);
			DateTime debut = new DateTime(1901, 01, 01);
			DateTime fin = new DateTime(2000, 12, 31);
			int i = 0;
			while (currentDate < fin)
			{
				if (currentDate >= debut && currentDate.Day == 1)
					i++;
				currentDate = currentDate.AddDays(7);
			}
			Console.Out.WriteLine("i = {0}", i);
			return null;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
