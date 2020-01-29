using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems
{
	public class Problem21 : Problem
	{
		PrimeLong p = new PrimeLong();

		public IEnumerable<long> D(long n)
		{
			IEnumerable<long> t = p.Primes.Where(u => u < n);
			List<long> divisors = new List<long>();
			List<long> primes = new List<long>();
			foreach (long l in t)
			{
				if (n % l == 0)
				{
					primes.Add(l);
					divisors.Add(n / l);
				}
			}
			for (int i = 0; i < divisors.Count; i++)
			{
				foreach (long l in primes)
				{
					if (divisors[i] % l == 0)
					{
						long v = divisors[i] / l;
						if (!primes.Contains(v) && !divisors.Contains(v))
							divisors.Add(v);
					}
				}
			}
			divisors.AddRange(primes);
			divisors.Add(1);
			return divisors;
		}

		public override object Launch()
		{
			p.GetPrime(10000);
			long t = D(220).Sum();
			t = D(t).Sum();
			List<long> amicaux = new List<long>();
			for (long i = 1; i < 10001; i++)
			{
				if (!p.Primes.Contains(i) && !amicaux.Contains(i))
				{
					long sum = D(i).Distinct().Sum();
					if (sum < 10000 && i != sum && D(sum).Distinct().Sum() == i)
					{
						amicaux.Add(i);
						amicaux.Add(sum);
					}
				}
			}
			long value = amicaux.Sum();
			Console.Out.WriteLine("value = {0}", value);
			return value;
			//throw new NotImplementedException();
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
