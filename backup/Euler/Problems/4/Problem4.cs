using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem4 : Problem{
		public override object Launch()
		{
			List<int> results = new List<int>();
			for (int i = 100; i < 999; i++)
			{
				for (int j = 100; j < 999; j++)
				{
					int r = i * j;
					if (Problem36.IsPalyndrom(r.ToString()))
					{
						results.Add(r);
					}
				}
			}
			int result = results.Max();
			Console.Out.WriteLine("result = {0}", result);
			return result;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
