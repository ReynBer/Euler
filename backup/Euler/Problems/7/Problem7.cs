using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem7 : Problem {
		public override object Launch()
		{
			PrimeInt p = new PrimeInt();
			int max = 10000;
			int n = 10000;
			while (p.GetPrime(n).Count <= max)
			{
				n *= 2;
			}
			int result = p.Primes[max];
			Console.Out.WriteLine("result = {0}", result);
			return result;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
