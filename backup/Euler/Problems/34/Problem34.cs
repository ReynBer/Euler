using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems
{
	public class Problem34 : Problem
	{
		public override object Launch()
		{
			List<int> okNumbers = new List<int>();
			int[] factoriels = new int[10];
			for (int i = 0; i < factoriels.Length; i++)
			{
				factoriels[i] = Problem24.Factoriel(i);
			}
			for (int i = 10; i < 1000000; i++)
			{
				char[] t = i.ToString().ToCharArray();
				int sum = 0;
				for (int j = 0; j < t.Length && sum <= i; j++)
				{
					sum += factoriels[int.Parse(t[j].ToString())];
				}
				if (sum == i)
				{
					okNumbers.Add(i);
				}
			}
			int result = okNumbers.Sum();
			Console.Out.WriteLine("result = {0}", result);
			return result;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
