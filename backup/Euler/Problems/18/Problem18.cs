using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems
{
	public class Problem18 : Problem
	{
		public override object Launch()
		{
			string[] splitted = Resource.problem18.Split(new string[1] { "\r\n" }, StringSplitOptions.None);
			long[] step_n = null;
			long[] step_nm1 = null;
			for (int i = 0; i < splitted.Length; i++)
			{
				string[] ts = splitted[i].Split(new string[1] { " " }, StringSplitOptions.None);
				step_n = new long[ts.Length];
				for (int j = 0; j < ts.Length; j++)
				{
					step_n[j] = long.Parse(ts[j]);
					if (step_nm1 != null)
					{
						if (j == 0 || j == step_nm1.Length)
						{
							if (j == 0)
							{
								step_n[j] += step_nm1[j];
							}
							else
							{
								step_n[j] += step_nm1[j - 1];
							}
						}
						else
						{
							if (step_nm1[j - 1] > step_nm1[j])
							{
								step_n[j] += step_nm1[j - 1];
							}
							else
							{
								step_n[j] += step_nm1[j];
							}
						}
					}
				}
				step_nm1 = step_n;
			}
			long max = step_n.Max();
			Console.Out.WriteLine("Max = {0}", max);
			return max;
			//throw new NotImplementedException();
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
