using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem32 : Problem{
		List<int> list = new List<int>();
		List<int> stockGreatest = new List<int>();
		private char[] through = new char[9];

		public static bool IsPandigital(IEnumerable<char> through, int sizeThrough, string s)
		{
			return (s.Intersect(through).Count() == sizeThrough);
		}

		public override object Launch()
		{
			for (int i = 1; i < 10; i++)
			{
				through[i - 1] = i.ToString()[0];
			}
			
			for (int a = 1; a < 20000; a++)
			{
				int size = 0;
				for (int b = 1; b < 20000 && size <= 9; b++)
				{
					int p = a * b;
					size = p.ToString().Length + a.ToString().Length + b.ToString().Length;
					if (size == 9)
					{
						if (IsPandigital(through, through.Length, a.ToString() + b.ToString() + p.ToString()))
						{
							int greatest = (a > b) ? a : b;
							if (!stockGreatest.Contains(greatest))
							{
								list.Add(p);
								stockGreatest.Add(greatest);
							}
						}
					}
				}
				
			}
			int sumProduct = list.Distinct().Sum();
			Console.Out.WriteLine("sumProduct = {0}", sumProduct);
			return sumProduct;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
