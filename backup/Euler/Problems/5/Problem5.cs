using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem5 : Problem
	{
		public override object Launch()
		{
			long i = 2520;
            bool isDivisible = false;
			while (!isDivisible)
			{
				isDivisible = true;
				for (long j = 2; j < 20 && isDivisible; j++)
				{
					isDivisible = (i % j == 0);
				}
				if (!isDivisible)
				{
					i += 2;
				}
			}
			Console.Out.WriteLine("i = {0}", i);
			return i;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
