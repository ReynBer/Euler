using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem23 : Problem {
		IEnumerable<int> Primes { get; set; }

		public IEnumerable<int> D(int n)
		{
			IEnumerable<int> t = Primes.Where(u => u < n);
			List<int> divisors = new List<int>();
			List<int> primes = new List<int>();
			foreach (int l in t)
			{
				if (n % l == 0)
				{
					primes.Add(l);
					divisors.Add(n / l);
				}
			}
			for (int i = 0; i < divisors.Count; i++)
			{
				foreach (int l in primes)
				{
					if (divisors[i] % l == 0)
					{
						int v = divisors[i] / l;
						if (!primes.Contains(v) && !divisors.Contains(v))
							divisors.Add(v);
					}
				}
			}
			divisors.AddRange(primes);
			divisors.Add(1);
			return divisors.Distinct();
		}

		public override object Launch()
		{
			int n = 28123;
			PrimaryGenerator p = new PrimaryGenerator();
			Primes = p.Get(n);
			//Dictionary<int, IEnumerable<int>> abondant = new Dictionary<int, IEnumerable<int>>();
			List<int> abondants = new List<int>();
			for (int i = 1; i < n; i++)
			{
				IEnumerable<int> di = D(i);
				if (di.Sum() > i)
				{
					//abondant.Add(i, di);
					abondants.Add(i);
				}
			}
			List<int> list = new List<int>();
			bool[] isSumAbondant = new bool[n];
			for (int i = 0; i < abondants.Count; i++)
			{
				for (int j = i; j < abondants.Count; j++)
				{
					int tmp = abondants[i] + abondants[j];
					if (tmp < n)
					{
						isSumAbondant[tmp] = true;
					}
				}
			}
			for (int i = 1; i < n; i++)
			{
				if (!isSumAbondant[i])
				{
					list.Add(i);
				}
			}
			int sum = list.Sum();
			Console.Out.WriteLine("sum = {0}", sum);
			return sum;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
