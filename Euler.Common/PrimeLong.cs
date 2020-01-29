using System;
using System.Collections.Generic;

namespace Euler.Common
{
    public class PrimeLong
	{
		public List<long> Primes { get; private set; }
		public List<long> GetPrime(long number)
		{
			if (Primes == null)
			{
				Primes = new List<long>();
				Primes.Add(2);
				Primes.Add(3);
			}
			long i = Primes[Primes.Count - 1];
			while (i < number)
			{
				bool b = true;
				long max_step = (long)Math.Floor(Math.Sqrt(i));
				foreach (long prime in Primes)
				{
					b &= ((i % prime) != 0);
					if (!b || prime > max_step)
						break;
				}
				if (b && !Primes.Contains(i))
					Primes.Add(i);
				i += 2;
			}
			return Primes;
		}

		public bool IsPrime(long n)
		{
			GetPrime(0L);
			int i = 0;
			foreach (long l in Primes)
			{
				if (n % l == 0) 
					return false;
				i++;
			}
			long max_step = (long)Math.Floor(Math.Sqrt(n));
			GetPrime(max_step);
			for (; i < Primes.Count; i++)
			{
				if (n % Primes[i] == 0) 
					return false;
			}
			return true;
		}

	}

}
