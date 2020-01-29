using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler {
	public class PrimeLong
	{
		public List<long> Primes { get; set; }
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
					Primes.Add(i);
				}
				i += 2;
			}
			return Primes;
		}

		public bool IsPrime(long n)
		{
			GetPrime(0);
			int i = 0;
			foreach (long l in Primes)
			{
				if (n % l == 0) return false;
				i++;
			}
			long max_step = (long)Math.Floor(Math.Sqrt(n));
			GetPrime(max_step);
			for (; i < Primes.Count; i++)
			{
				if (n % Primes[i] == 0) return false;
			}
			return true;
		}

	}

	public class PrimeInt {
		public List<int> Primes { get; set; }
		public List<int> GetPrime(int number)
		{
			if (Primes == null)
			{
				Primes = new List<int>();
				Primes.Add(2);
				Primes.Add(3);
			}
			int i = Primes[Primes.Count - 1];
			//while (listPremier.Count != 10001)
			while (i < number)
			{
				bool b = true;
				int max_step = (int)Math.Floor(Math.Sqrt(i));
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
					Primes.Add(i);
				}
				i += 2;
			}
			return Primes;
		}
		public bool IsPrime(int n)
		{
			GetPrime(0);
			int i = 0;
			foreach (long l in Primes)
			{
				if (n % l == 0) return false;
				i++;
			}
			int max_step = (int)Math.Floor(Math.Sqrt(n));
			GetPrime(max_step);
			for (; i < Primes.Count; i++)
			{
				if (n % Primes[i] == 0) return false;
			}
			return true;
		}

	}
}
