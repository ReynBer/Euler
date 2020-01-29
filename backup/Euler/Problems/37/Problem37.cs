using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem37 : Problem {
		public bool IsPrimaryFromLeftToRight(int n, PrimaryGenerator p)
		{
			string sN = n.ToString();
			int length = sN.Length - 1;
			int i = 1;
			while (length != 0)
			{
				if (!p.IsPrimary(int.Parse(sN.Substring(i, length)))) return false;
				i++;
				length--;
			}
			return true;
		}

		public bool IsPrimaryFromRightToLeft(int n, PrimaryGenerator p)
		{
			string sN = n.ToString();
			int length = sN.Length - 1;
			while (length != 0)
			{
				if (!p.IsPrimary(int.Parse(sN.Substring(0, length)))) return false;
				length--;
			}
			return true;
		}

		public override object Launch()
		{
			List<int> list = new List<int>();
			int nbFound = 0;
			int n = 10;
			int step = 10;
			PrimaryGenerator primaryGenerator = new PrimaryGenerator();
			int max = 11;
			while (nbFound < max)
			{
				int nBak = n;
				primaryGenerator.IsPrimary(n *= step);
				for (int i = nBak; i < n && nbFound < max; i++)
				{
					if (primaryGenerator.IsPrimary(i) && IsPrimaryFromRightToLeft(i, primaryGenerator) && IsPrimaryFromLeftToRight(i, primaryGenerator))
					{
						list.Add(i);
						nbFound++;
					}
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
