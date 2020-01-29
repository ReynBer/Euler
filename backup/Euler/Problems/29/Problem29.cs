using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem29 : Problem {
		public class myComparerBigInt : IEqualityComparer<BigInt> {
			public bool Equals(BigInt x, BigInt y)
			{
				return ((x == null && y == null) || x != null && x.Equals(y));
			}

			public int GetHashCode(BigInt obj)
			{
				throw new NotImplementedException();
			}
		}


		public override object Launch()
		{
			/*
			List<double> used = new List<double>();
			int max = 100;
			for (int a = 2; a <= max; a++)
			{
				for (int b = 2; b <= max; b++)
				{
					double p = Math.Pow(a, b);
					if (!used.Contains(p))
					{
						used.Add(p);
					}
					//else
					//{
					//	Console.Out.WriteLine("p = {0}", p);
					//}
				}
			}
			int resultat = used.Count;
			*/
			int max = 1000;
			int maxM1 = max - 1;
			int resultat = maxM1 * maxM1;
			List<int> powers = new List<int>();
			List<int> numbers = new List<int>();
			for (int a = 2; a <= max; a++)
			{
				powers.Add(a);
				numbers.Add(a);
			}
			for (int i = 0; i < numbers.Count; i++)
			{
				int a = numbers[i];
				int aSquare = a * a;
				if (aSquare <= max)
				{
					int power = 2;
					List<int> powersRepresented = new List<int>(powers);
					for (int j = aSquare; j <= max; j = j * a)
					{
						numbers.Remove(j);
						int count = 0;
						int limit = max * power;
						for (int powerCurrent = 2 * power; powerCurrent <= limit; powerCurrent += power)
						{
							if (powersRepresented.Contains(powerCurrent))
							{
								count++;
							}
							else
							{
								powersRepresented.Add(powerCurrent);
							}
						}
						resultat-=count;
						power++;
					}
				}
			}
			Console.Out.WriteLine("resultat = {0}", resultat);
			return resultat;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
