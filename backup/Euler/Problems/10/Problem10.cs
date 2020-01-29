using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem10 : Problem{
		public override object Launch()
		{
			DateTime debut = DateTime.Now;
			Console.Out.WriteLine("debut = {0}", debut);
			PrimaryGenerator p = new PrimaryGenerator();
			IEnumerable<int> t = p.Get(2000000);
			long result = t.Sum(x => (long)x);
			Console.Out.WriteLine("result = {0}", result);
			DateTime fin = DateTime.Now;
			Console.Out.WriteLine("fin = {0}", fin);
			Console.Out.WriteLine("execution time = {0}", fin - debut);

			/*DateTime debut = DateTime.Now;
			Console.Out.WriteLine("debut = {0}", debut);
			List<long> Primes = new List<long>();
			Primes.Add(2);
			Primes.Add(3);
			long result = 5;
			long i = Primes[Primes.Count - 1];
			while (i < 2000000)
			{
				bool b = true;
				long max_step = (long)Math.Floor(Math.Sqrt(i));
				foreach (long premier in Primes)
				{
					b &= ((i % premier) != 0);
					if (!b)
					{
						break;
					}
					if (premier > max_step)
					{
						break;
					}
				}
				if (b && !Primes.Contains(i))
				{
					result += i;
					Primes.Add(i);
				}
				i += 2;
			}
			Console.Out.WriteLine("result = {0}", result);
			DateTime fin = DateTime.Now;
			Console.Out.WriteLine("fin = {0}", fin);
			Console.Out.WriteLine("execution time = {0}", fin - debut);*/
			return result;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
