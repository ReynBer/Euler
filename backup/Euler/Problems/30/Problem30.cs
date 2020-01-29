using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems
{
	public class Problem30 : Problem
	{
		public override object Launch()
		{
			List<int> okNumbers = new List<int>();
			int[] powers5 = new int[10];
			powers5[0] = 0;
			for (int i = 1; i < powers5.Length; i++)
			{
				powers5[i] = i * i * i * i * i;
			}
			int nbDigitsMax = 2;
			while ((nbDigitsMax * powers5[9]).ToString().Length > nbDigitsMax)
			{
				nbDigitsMax++;
			}
			int max = nbDigitsMax * powers5[9];
			for (int i = 10; i < max; i++)
			{
				char[] t = i.ToString().ToCharArray();
				int sum = 0;
				for (int j = 0; j < t.Length && sum <= i; j++)
				{
					sum += powers5[int.Parse(t[j].ToString())];
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
