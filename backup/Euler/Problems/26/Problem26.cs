using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems
{
	public class Problem26 : Problem
	{
		public List<int> Division(List<int> restesMultiple, int numerateur, int denominateur)
		{
			int n = numerateur * 10;
			int reste = n % denominateur;
			if (reste == 0)
			{
				restesMultiple.Clear();
				return restesMultiple;
			}
			//int multiplicateur = (n - reste) / denominateur;
			if (!restesMultiple.Contains(reste))
			{
				restesMultiple.Add(reste);
				return Division(restesMultiple, reste, denominateur);
			}
			else
			{
				int index = restesMultiple.IndexOf(reste);
				for (int i = 0; i < index; i++)
				{
					restesMultiple.RemoveAt(0);
				}
				return restesMultiple;
			}
		}


		public override object Launch()
		{
			int dSave = 2;
			int max = 0;
			for (int d = dSave; d < 1000; d++)
			{
				List<int> t = Division(new List<int>(), 1, d);
				if (max < t.Count)
				{
					max = t.Count;
					dSave = d;
				}
			}
			Console.Out.WriteLine("dSave = {0}", dSave);
			return dSave;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
