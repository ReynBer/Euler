using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem41 : Problem
	{
		private char[] through = new char[9];
		private List<bool[]> isPrimary = new List<bool[]>();
		private List<int> listPrime = new List<int>();
		private int max = (int)(Math.Sqrt(987654321)) + 1;
		public PrimaryGenerator primaryGenerator = new PrimaryGenerator();
		public bool IsPrimary(int n)
		{
			if (n <= max) return primaryGenerator.IsPrimary(n);
			int limit = (int)(Math.Sqrt(n)) + 1;
			bool isFinished = false;
			for (int k = 0; k < listPrime.Count && !isFinished; k++)
			{
				if (n % listPrime[k] == 0)
					return false;
				isFinished = listPrime[k] >= limit;
			}
			return true;
		}

		public static bool IsPandigital(IEnumerable<char> through, int sizeThrough, string s)
		{
			return (s.Intersect(through).Count() == sizeThrough);
		}

		public static IEnumerable<int> BasicPandigital(int n)
		{
			List<int> list = new List<int>();
			for (int i = 1; i <= n; i++)
			{
				list.Add(i);
			}
			return list;
		}

		public static IEnumerable<int> ListEven(int n)
		{
			List<int> list = new List<int>();
			for (int i = 0; i <= n; i+=2)
			{
				list.Add(i);
			}
			return list;
		}
		public static IEnumerable<int> ListOdd(int n)
		{
			List<int> list = new List<int>();
			for (int i = 1; i <= n; i += 2)
			{
				list.Add(i);
			}
			return list;
		}

		public List<int> GeneratePandigital(int nMax, int n, IEnumerable<int> list, IEnumerable<int> exclusion, List<int> pandigitals)
		{
			IEnumerable<int> enumerable = list.Except(exclusion);
			foreach (int i in enumerable)
			{
				if (n == 1)
				{
					pandigitals.Add(i);
					return pandigitals;
				}
				int r = pandigitals.Count;
				GeneratePandigital(nMax, n - 1, list.Except(new int[1] { i }), new List<int>(), pandigitals);
				for (int j = r; j < pandigitals.Count; j++)
				{
					pandigitals[j] = pandigitals[j] * 10 + i;
				}
			}
			return pandigitals;
		}

		public override object Launch()
		{
			for (int i = 1; i < 10; i++)
			{
				through[i - 1] = i.ToString()[0];
			}
			primaryGenerator.IsPrimary(max);
			for (int i = 0; i < max; i++)
			{
				if (primaryGenerator.IsPrimary(i))
				{
					listPrime.Add(i);
				}
			}
			List<int> primePandigitals = new List<int>();
			for (int i = 2; i < 10; i++)
			{
				List<int> pandigitals = new List<int>();
				GeneratePandigital(i, i, BasicPandigital(i), ListEven(i), pandigitals);
				foreach (int pandigital in pandigitals)
				{
					if (IsPrimary(pandigital))
					{
						primePandigitals.Add(pandigital);
					}
				}
			}
			int resultat = primePandigitals.Max();
			Console.Out.WriteLine("resultat = {0}", resultat);
			return resultat;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
