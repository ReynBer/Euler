using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem1 : Problem {
		public override object Launch()
		{
			var s = from e in Enumerable.Range(1, 1000)
					where e % 3 == 0 || e % 5 == 0
					select e;
			int sum = s.Distinct().Sum();
			Console.Out.WriteLine("sum = {0}", sum);
			return sum;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
