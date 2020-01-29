using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem2 : Problem {
		public override object Launch()
		{
			List<long> Fib = new List<long>();
			Fib.Add(1);
			Fib.Add(2);
			int index = 1;
			while (Fib[index] < 4000000)
			{
				Fib.Add(Fib[index] + Fib[index - 1]);
				index++;
			}
			long sum = Fib.Where(p=>p%2==0).Sum();
			Console.Out.WriteLine("sum = {0}", sum);
			return sum;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
