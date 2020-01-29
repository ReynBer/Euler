using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem6 : Problem
	{
		public override object Launch()
		{
			int n = 100;
			int np1 = n + 1;
			int sum = 0;
			for (int k = 1; k < np1; k++)
			{
				sum += k * k;
			}
			int result = n * np1 * n * np1 / 4 - sum;
			Console.Out.WriteLine("result = {0}", result);
			return result;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
